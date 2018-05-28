using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Thread
using System.Threading;

namespace Terragard
{
    class Time : Types
    {
        //Thread for TickCounter
        private Thread timeThread;

        private static long deltaTimeStart;
        private static float output;

        //initialization of new Thread which stands for time;
        public void InitThread()
        {
            //starting new thread for TickCounter function
            timeThread = new Thread(new ThreadStart(TickCounter)); 
            timeThread.Start();
        }

        public void StopTimeThread()
        {
            timeThread.Abort();
        }

        //counts ticks between framse
        public static void TickCounter()
        {
            deltaTimeStart = Environment.TickCount;
            Console.WriteLine("Time.TickCounter: Starts running"); 
            while (true) {  
                if (GameController.frameReady)
                {
                    GameController.frameReady = false;
                    GameController.timeReady = true;
                    long deltaTimeStop = Environment.TickCount; 
                    output = deltaTimeStop - deltaTimeStart;
                    deltaTimeStart = deltaTimeStop;  
                }
            }
        }
         
        //return time between frames as an fraction of a second
        public static float DeltaTime()
        { 
            return output / 1000;
        }
    }
}
