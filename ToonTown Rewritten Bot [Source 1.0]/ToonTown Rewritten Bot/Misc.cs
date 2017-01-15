using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using System.Threading;
using System.Windows.Forms;

namespace ToonTown_Rewritten_Bot
{
    class Misc
    {
        public static void sendMessage(String message, int spamCount, bool spam, Label label2)
        {
            Console.WriteLine("Spam? : " + spam);
            if (!message.Equals(""))
            {
                MessageBox.Show("Press OK to send!");
                if (spam)//spam checkbox check
                {
                    label2.Visible = true;
                    while (spamCount != 0)
                    {
                        label2.Text = Convert.ToString(spamCount);
                        send(message);
                        spamCount--;
                    }
                    label2.Visible = false;
                }
                else if(!spam)
                {
                    send(message);
                }
            }
            else
                MessageBox.Show("You must enter a message to send!");
        }
        private static void send(String text)
        {
            BotFunctions.DoMouseClick();
            Thread.Sleep(500);
            InputSimulator.SimulateTextEntry(text);
            Thread.Sleep(500);
            SendKeys.SendWait("{ENTER}");
        }

        public static void keepToonAwake(int min)
        {
            DateTime endTime = DateTime.Now.AddMinutes(min);
            BotFunctions.DoMouseClick();
            while (endTime > DateTime.Now)
            {
                SendKeys.SendWait("^");
            }
        }
    }
}
