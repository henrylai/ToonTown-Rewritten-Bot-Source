﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using ToonTown_Rewritten_Bot.Properties;
using WindowsInput;

namespace ToonTown_Rewritten_Bot
{
    public partial class Form1 : Form
    {
        public bool fishVariance = false;
        public Process TTR;

        public Form1()
        {
            //File.SetAttributes(Path.GetFullPath("InputSimulator.dll"), FileAttributes.Hidden);
            isTTRRunning();
            InitializeComponent();
            BotFunctions.readTextFile();
            createDataFileMap();
            loadCoordsIntoResetBox();
        }

        //important functions for bot
        private void startSpamButton_Click(object sender, EventArgs e)//spam message on screen
        {
            Misc.sendMessage(messageToType.Text, Convert.ToInt32(numericUpDown2.Value), checkBox1.Checked, label2);
        }//fix one message

        private int timeLeft;
        private void keepToonAwakeButton_Click(object sender, EventArgs e)//keep toon 
        {
            timeLeft = Convert.ToInt32(numericUpDown1.Value) * 60;
            MessageBox.Show("Press OK when ready to begin!");
            Thread.Sleep(2000);
            timer1.Start();
            Misc.keepToonAwake(Convert.ToInt32(numericUpDown1.Value));
        }

        private void button1_Click(object sender, EventArgs e)//open the flower manager
        {
            Plants plantsForm = new Plants();
            try
            {
                string selected = (string)comboBox2.SelectedItem;
                plantsForm.loadFlowers(selected);
                plantsForm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Unable to perform this action", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            plantsForm.comboBox1.Items.Clear();
        }

        //misc functions for bot
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                numericUpDown2.Visible = true;
            else
                numericUpDown2.Visible = false;
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                this.TopMost = true;
            else
                this.TopMost = false;
        }
        private void isTTRRunning()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("Toontown Rewritten [BETA]");
            while (!(Process.GetProcessesByName("TTREngine").Length > 0))
            {
                MessageBox.Show("ToonTown Rewritten is not running!\nPress OK once running.");
            }
            TTR = Process.GetProcessesByName("TTREngine")[0];
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            MessageBox.Show("Make sure your ToonTown Rewritten window is maximized!");
        }

        public static Dictionary<string, string> dataFileMap = new Dictionary<string, string>();
        private void createDataFileMap()
        {
            //Gardening Coords
            dataFileMap.Add("1", "Plant Flower/Remove Button");
            dataFileMap.Add("2", "Red Jellybean Button");
            dataFileMap.Add("3", "Green Jellybean Button");
            dataFileMap.Add("4", "Orange Jellybean Button");
            dataFileMap.Add("5", "Purple Jellybean Button");
            dataFileMap.Add("6", "Blue Jellybean Button");
            dataFileMap.Add("7", "Pink Jellybean Button");
            dataFileMap.Add("8", "Yellow Jellybean Button");
            dataFileMap.Add("9", "Cyan Jellybean Button");
            dataFileMap.Add("10", "Silver Jellybean Button");
            dataFileMap.Add("11", "Blue Plant Button");
            dataFileMap.Add("12", "Blue Ok Button");
            dataFileMap.Add("13", "Watering Can Button");
            dataFileMap.Add("14", "Blue Yes Button");
            //Fishing Coords
            dataFileMap.Add("15", "Red Fishing Button");
            dataFileMap.Add("16", "Exit Fishing Button");
            dataFileMap.Add("17", "Blue Sell All Button");
            //Racing Coords

        }

        /*private void button4_Click(object sender, EventArgs e)
        {
            //Thread.Sleep(4000);
            //textBox1.Text = BotFunctions.HexConverter(BotFunctions.GetColorAt(BotFunctions.getCursorLocation().X, BotFunctions.getCursorLocation().Y));
        }*/

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Visible = true;
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                label1.Text = timeLeft + " seconds";
            }
            else
            {
                timer1.Stop();
                label1.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Gardening.waterPlant();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Gardening.removePlant();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BotFunctions.resetAllCoordinates();
            MessageBox.Show("All coordinates reset!");
        }

        private void loadCoordsIntoResetBox()
        {
            comboBox1.Items.Clear();
            words = new String[dataFileMap.Count];
            for (int i = 0; i < dataFileMap.Count; i++)
            {
                words[i] = dataFileMap[Convert.ToString(i + 1)];
            }
            comboBox1.Items.AddRange(words);
        }

        private static String[] words;
        private void button6_Click(object sender, EventArgs e)
        {
            string selected = (string)comboBox1.SelectedItem;
            try
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Equals(selected))
                        BotFunctions.updateCoordinates(Convert.ToString(i + 1));
                }
            }
            catch
            {
                MessageBox.Show("Unable to perform this action", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            MessageBox.Show("Coordinate's updated for " + selected);
        }

        private void startFishing_Click(object sender, EventArgs e)
        {
            string selected = (string)comboBox3.SelectedItem;
            int numberOfCasts = Convert.ToInt32(numericUpDown3.Value);
            int numberOfSells = Convert.ToInt32(numericUpDown4.Value);
            BotFunctions.tellFishingLocation(selected);
            MessageBox.Show("Make sure you're in the fishing dock before pressing OK!");
            Fishing.startFishing(selected, numberOfCasts, numberOfSells, fishVariance);
            MessageBox.Show("Done!");
        }

        private void smartFishing_CheckedChanged(object sender, EventArgs e)
        {
            if (smartFishing.Checked)
            {
                MessageBox.Show("Will be added later!");
                smartFishing.Checked = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Press OK when ready to begin!");
            Thread.Sleep(2000);
            BotFunctions.DoMouseClick();
            Racing.startRacing();

            Rectangle bounds = Screen.GetWorkingArea(Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }
                int x = 950;
                int y = 755;
                while (y <= 780 && x <= 970)
                {
                    richTextBox1.AppendText(BotFunctions.HexConverter(bitmap.GetPixel(x, y)) + "\n");
                    x++;
                    y++;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            try
            {
                aboutBox.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Unable to perform this action", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Help helpBox = new Help();
            try
            {
                helpBox.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Unable to perform this action", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void randomFishing_CheckedChanged(object sender, EventArgs e)
        {
            if (randomFishing.Checked)
            {
                MessageBox.Show("This will add randomness to the line casting!");
                fishVariance = true;
            } else
            {
                fishVariance = false;
            }
        }

        // Maximizes and Focuces TTR
        private void maximizeAndFocus()
        {
            IntPtr hwnd = FindWindowByCaption(IntPtr.Zero, "Toontown Rewritten [BETA]");
            ShowWindow(hwnd, 6);
            ShowWindow(hwnd, 3);
        }

        // GOLF- Afternoon Tee
        private void golfAfternoonTee_Click(object sender, EventArgs e)
        {
            maximizeAndFocus();
            Thread.Sleep(100);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.UP);
            Thread.Sleep(50);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.UP);
            Thread.Sleep(50);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.CONTROL);
            Thread.Sleep(2120);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL);
        }

        // GOLF - Holey Mackeral
        private void golfHoleyMackeral(object sender, EventArgs e)
        {
            maximizeAndFocus();
            Thread.Sleep(100);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.UP);
            Thread.Sleep(50);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.UP);
            Thread.Sleep(50);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.CONTROL);
            Thread.Sleep(1000);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL);
        }

        // GOLF - Hole on the Range
        private void golfHoleOnTheRange(object sender, EventArgs e)
        {
            maximizeAndFocus();
            Thread.Sleep(100);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.UP);
            Thread.Sleep(50);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.UP);
            Thread.Sleep(50);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.CONTROL);
            Thread.Sleep(1735);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL);
        }

        // GOLF - Seeing green
        private void golfSeeingGreen(object sender, EventArgs e)
        {
            maximizeAndFocus();
            Thread.Sleep(100);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.UP);
            Thread.Sleep(50);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.UP);
            Thread.Sleep(50);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.CONTROL);
            Thread.Sleep(1790); // 67%
            InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL);
        }

        // GOLF - Hot Links
        private void golfHotLinks(object sender, EventArgs e)
        {
            maximizeAndFocus();
            Thread.Sleep(100);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.RIGHT);
            Thread.Sleep(250);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.RIGHT);
            Thread.Sleep(50);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.CONTROL);
            Thread.Sleep(1950); // 
            InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL);

            /*Thread.Sleep(2000);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.UP);
            Thread.Sleep(50);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.UP);
            Thread.Sleep(50);

            InputSimulator.SimulateKeyDown(VirtualKeyCode.RIGHT);
            //            Thread.Sleep(150);
            Thread.Sleep(320);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.RIGHT);
            Thread.Sleep(50);

            InputSimulator.SimulateKeyDown(VirtualKeyCode.CONTROL);
            Thread.Sleep(1200);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL); */
        }

        // GOLF - Peanut Putter
        private void golfPeanutPutter(object sender, EventArgs e)
        {
            maximizeAndFocus();
            Thread.Sleep(100);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.UP);
            Thread.Sleep(50);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.UP);
            Thread.Sleep(50);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.CONTROL);
            Thread.Sleep(1920); // 71
            InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL);
        }

        // GOLF - Down the Hatch
        private void golfDownTheHatch(object sender, EventArgs e)
        {
            maximizeAndFocus();
            Thread.Sleep(100);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.LEFT);
            Thread.Sleep(50);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.LEFT);
            Thread.Sleep(50);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.CONTROL);
            // Thread.Sleep(2350); //82
            Thread.Sleep(2500); 
            InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL);
        }

        // GOLF - Swing Time
        private void golfSwingTime(object sender, EventArgs e)
        {
            maximizeAndFocus();
            Thread.Sleep(100);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.UP);
            Thread.Sleep(50);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.UP);
            Thread.Sleep(50);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.RIGHT);
            Thread.Sleep(600);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.RIGHT);
            Thread.Sleep(50);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.CONTROL);
            Thread.Sleep(1500);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL);
        }

        // GOLF - Hole in fun
        private void golfHoleInFun(object sender, EventArgs e)
        {
            maximizeAndFocus();
            Thread.Sleep(100);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.UP);
            Thread.Sleep(50);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.UP);
            Thread.Sleep(50);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.CONTROL);
            Thread.Sleep(1200);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL);

        }


        // GOLF - Swing A Long
        private void golfSwingAlong(object sender, EventArgs e)
        {
            maximizeAndFocus();
            Thread.Sleep(500);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.LEFT);
            Thread.Sleep(100);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.LEFT);
            Thread.Sleep(50);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.CONTROL);
            Thread.Sleep(2150);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL);
        }

        

        private void button18_Click(object sender, EventArgs e)
        {
            while(true)
            {
                maximizeAndFocus();
                Thread.Sleep(50);
                InputSimulator.SimulateKeyDown(VirtualKeyCode.END);
                Thread.Sleep(50);
                InputSimulator.SimulateKeyUp(VirtualKeyCode.END);
                Thread.Sleep(60000);
            }
        }


        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
        
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        
        }

    
}
