using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;

namespace ToonTown_Rewritten_Bot
{
    class Fishing
    {
        private static int x, y;
        private static Random rand = new Random();
        public static void startFishing(String location, int numberOfCasts, int numberOfTimesToMeetFisherman)
        {
            if (numberOfTimesToMeetFisherman != 0)
            {
                Thread.Sleep(3000);
                if (!BotFunctions.checkCoordinates("15"))//if they're 0,0, enter. Checks the red fishing button
                    locateRedFishingButton();
                //start fishing
                startFishing(numberOfCasts);
                //walking to fisherman
                switch (location)
                {
                    case "TOONTOWN CENTRAL PUNCHLINE PLACE":
                        fishTTCPunchlinePlace();//goes to fisherman and back to dock
                        startFishing(location, numberOfCasts, numberOfTimesToMeetFisherman - 1);
                        break;
                    case "DONALD DREAM LAND LULLABY LANE":
                        fishDDLLullabyLane();
                        startFishing(location, numberOfCasts, numberOfTimesToMeetFisherman - 1);
                        break;
                    case "BRRRGH POLAR PLACE":
                        fishBrrrghPolarPlace();
                        startFishing(location, numberOfCasts, numberOfTimesToMeetFisherman - 1);
                        break;
                    case "BRRRGH WALRUS WAY":
                        fishBrrrghWalrusWay();
                        startFishing(location, numberOfCasts, numberOfTimesToMeetFisherman - 1);
                        break;
                    case "BRRRGH SLEET STREET":
                        fishBrrrghSleetSt();
                        startFishing(location, numberOfCasts, numberOfTimesToMeetFisherman - 1);
                        break;
                    case "MINNIE'S MELODYLAND TENOR TERRACE":
                        fishMMTenorTerrace();
                        startFishing(location, numberOfCasts, numberOfTimesToMeetFisherman - 1);
                        break;
                    case "DONALD DOCK LIGHTHOUSE LANE":
                        fishDDLighthouseLane();
                        startFishing(location, numberOfCasts, numberOfTimesToMeetFisherman - 1);
                        break;
                    case "DAISY'S GARDEN ELM STREET":
                        fishDaisyGardenElmSt();
                        startFishing(location, numberOfCasts, numberOfTimesToMeetFisherman - 1);
                        break;
                    case "FISH ANYWHERE":
                        MessageBox.Show("Done!");
                        break;
                }
            }
        }

        private static void fishTTCPunchlinePlace()
        {
            //Go to fisherman
            InputSimulator.SimulateKeyDown(VirtualKeyCode.DOWN);
            Thread.Sleep(2000);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.DOWN);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.RIGHT);
            Thread.Sleep(800);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.RIGHT);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.UP);
            Thread.Sleep(700);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.UP);
            Thread.Sleep(2000);
            sellFish();//sell fish
            //Go back to dock
            InputSimulator.SimulateKeyDown(VirtualKeyCode.DOWN);
            Thread.Sleep(700);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.DOWN);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.LEFT);
            Thread.Sleep(800);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.LEFT);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.UP);
            Thread.Sleep(2000);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.UP);
        }

        private static void fishDDLLullabyLane()
        {
            InputSimulator.SimulateKeyDown(VirtualKeyCode.UP);
            Thread.Sleep(4000);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.UP);
            sellFish();
            InputSimulator.SimulateKeyDown(VirtualKeyCode.DOWN);
            Thread.Sleep(6500);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.DOWN);
        }

        private static void fishBrrrghPolarPlace()
        {
            InputSimulator.SimulateKeyDown(VirtualKeyCode.RIGHT);
            Thread.Sleep(800);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.RIGHT);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.UP); ;
            Thread.Sleep(2000);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.UP);
            sellFish();
            InputSimulator.SimulateKeyDown(VirtualKeyCode.DOWN);
            Thread.Sleep(2000);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.DOWN);
        }

        private static void fishMMTenorTerrace()
        {
            InputSimulator.SimulateKeyDown(VirtualKeyCode.LEFT);
            Thread.Sleep(1090);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.LEFT);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.UP); ;
            Thread.Sleep(2200);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.UP);
            sellFish();
            InputSimulator.SimulateKeyDown(VirtualKeyCode.DOWN);
            Thread.Sleep(3000);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.DOWN);
        }

        private static void fishBrrrghWalrusWay()
        {
            InputSimulator.SimulateKeyDown(VirtualKeyCode.UP); ;
            Thread.Sleep(100);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.UP);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.LEFT);
            Thread.Sleep(730);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.LEFT);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.UP); ;
            Thread.Sleep(2000);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.UP);
            sellFish();
            InputSimulator.SimulateKeyDown(VirtualKeyCode.DOWN);
            Thread.Sleep(2100);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.DOWN);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.RIGHT);
            Thread.Sleep(700);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.RIGHT);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.DOWN);
            Thread.Sleep(1000);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.DOWN);
        }

        private static void fishBrrrghSleetSt()
        {
            InputSimulator.SimulateKeyDown(VirtualKeyCode.DOWN);
            Thread.Sleep(600);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.DOWN);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.RIGHT);
            Thread.Sleep(850);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.RIGHT);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.UP); ;
            Thread.Sleep(1000);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.UP);
            sellFish();
            InputSimulator.SimulateKeyDown(VirtualKeyCode.DOWN);
            Thread.Sleep(1700);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.DOWN);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.LEFT);
            Thread.Sleep(850);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.LEFT);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.UP); ;
            Thread.Sleep(600);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.UP);
        }

        private static void fishDaisyGardenElmSt()
        {
            InputSimulator.SimulateKeyDown(VirtualKeyCode.LEFT);
            Thread.Sleep(80);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.LEFT);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.UP); ;
            Thread.Sleep(2000);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.UP);
            sellFish();
            InputSimulator.SimulateKeyDown(VirtualKeyCode.DOWN);
            Thread.Sleep(4500);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.DOWN);
        }

        private static void fishDDLighthouseLane()
        {
            InputSimulator.SimulateKeyDown(VirtualKeyCode.RIGHT);
            Thread.Sleep(330);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.RIGHT);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.UP); ;
            Thread.Sleep(2200);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.UP);
            sellFish();
            InputSimulator.SimulateKeyDown(VirtualKeyCode.DOWN);
            Thread.Sleep(4500);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.DOWN);
        }

        private static void startFishing(int numberOfCasts)
        {
            Stopwatch stopwatch = new Stopwatch();
            while (numberOfCasts != 0)
            {
                castLine();
                stopwatch.Start();
                while (stopwatch.Elapsed.Seconds < 30 && !checkIfFishCaught())
                {
                    checkIfFishCaught();
                }
                stopwatch.Stop();
                stopwatch.Reset();
                numberOfCasts--;
                Thread.Sleep(1000);
            }
            exitFishing();
            Thread.Sleep(2000);
        }

        private static void sellFish()
        {
            if (BotFunctions.checkCoordinates("17"))//returns true if they are not 0,0
            {
                Thread.Sleep(2100);
                getCoords("17");
                BotFunctions.MoveCursor(x, y);
                BotFunctions.DoMouseClick();
            }
            else
            {
                BotFunctions.updateCoordinates("17");
                sellFish();
            }
            Thread.Sleep(2000);
        }

        private static void exitFishing()
        {
            if (BotFunctions.checkCoordinates("16"))//returns true if they are not 0,0
            {
                getCoords("16");
                BotFunctions.MoveCursor(x, y);
                BotFunctions.DoMouseClick();
            }
            else
            {
                BotFunctions.updateCoordinates("16");
                exitFishing();
            }
        }

        private static void castLine()
        {
            getCoords("15");
            int randX = rand.Next(-25, 26);
            int ranyY = rand.Next(-25, 26);
            BotFunctions.MoveCursor(x + randX, y + ranyY);
            Debug.WriteLine("X variance: " + randX + " \nY Variance: " + ranyY);
            BotFunctions.DoFishingClick();
        }

        private static bool checkIfFishCaught()
        {
            getCoords("15");
            String color = BotFunctions.HexConverter(BotFunctions.GetColorAt(x, y - 600));
            if (color.Equals("#FFFFBE") || color.Equals("#FFFFBF"))
                return true;//fish caught
            return false;
        }

        private static void locateRedFishingButton()
        {
            BotFunctions.updateCoordinates("15");//update the red fishing button coords
        }

        private static void getCoords(String item)
        {
            int[] coordinates = BotFunctions.getCoordinates(item);
            x = coordinates[0];
            y = coordinates[1];
        }
    }
}
