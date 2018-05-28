using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Graphics
using System.Drawing;
//Thread
using System.Threading;
//Timer
using System.Timers;


namespace Terragard
{
    class GEngine : Types
    { 
        /*-----------------Members--------------*/
        private Graphics drawHandle;
        private Thread renderThread;

        private Bitmap texture_theBoi;
        private Bitmap texture_nullBlock; 

        /*-----------------Functions-------------------------*/
        public GEngine(Graphics g)
        {
            drawHandle = g;
        }

        //initialization of Thread(Wątku) which stands for canvas;
        public void InitThread()
        {
            //loading assets
            LoadAssets();

            //starting new thread base on 'Render' function
            renderThread = new Thread(new ThreadStart(Render));
            renderThread.Start();
        }
         
        private void LoadAssets()
        {
            texture_nullBlock = Properties.Resources.nullBlock;   
            texture_theBoi = Properties.Resources.theBoi;
        }

        public void StopRenderThread()
        {
            renderThread.Abort();
        }

        //place where things are drawn
        private void Render()
        {
            
            //------------fos count-------------//
            int fosFramesRendered = 0;
            long fpsStartTime = Environment.TickCount;
            // Create a timer and set a two second interval. 

            //graphics
            Bitmap frame = new Bitmap(CANVAS_X, CANVAS_Y);
            Graphics frameGraphics = Graphics.FromImage(frame);

            //world
            GameController.TextureID[,] textures = World.blocks;
            //saving
            long savingStartTime = Environment.TickCount;

            Console.WriteLine("GEngine.Render: Starts running");

            while (true)
            { 
                /*----------Layer 0--------*/ 

                //background
                frameGraphics.FillRectangle(new SolidBrush(Color.SkyBlue), 0, 0, CANVAS_X, CANVAS_Y);

                /*----------Layer 1--------*/
                /*----------Layer 2--------*/
                if (GameController.worldChanged) textures = World.blocks;

                //blocks
                for (int x = 0; x < CAM_VIEW_X; x++)
                {
                    for (int y = 0; y < CAM_VIEW_Y; y++)
                    {
                        switch(textures[x, y])
                        {
                            case TextureID.airBlock:
                                break;
                            case TextureID.nullBlock:
                                frameGraphics.DrawImage(texture_nullBlock, x * BLOCKS_SIDE_LENGTH, y * BLOCKS_SIDE_LENGTH);
                                break; 
                        }
                    }
                }

                /*----------Layer 3--------*/
                /*----------Layer 4--------*/
                //character
                frameGraphics.DrawImage(texture_theBoi, GameController.player.x, GameController.player.y, CHARACTER_SIDE_X, CHARACTER_SIDE_Y);
                 
                //drawing screen
                drawHandle.DrawImage(frame, 0, 0);

                //Sets 4sec timer after world is changed to save ALL the changes within this time period
                if (GameController.worldChanged)
                { 
                    if( savingStartTime == 0 ) savingStartTime = Environment.TickCount;
                    GameController.worldChanged = false; 
                }
                if( savingStartTime != 0)
                {
                    if( Environment.TickCount > savingStartTime + 4000)
                    {
                        savingStartTime = 0;
                        GameController.SaveWorld();
                    }
                }

                //fpsCount - benchmarking
                fosFramesRendered++;
                GameController.frameReady = true;
                if (Environment.TickCount > fpsStartTime + 1000)
                {
                    Console.WriteLine("GEngine.Display: " + fosFramesRendered + " FPS"); 
                    GameController.worldFPS = fosFramesRendered;
                    fosFramesRendered = 0;
                    fpsStartTime = Environment.TickCount;
                } 
            }
        }

    }
}
