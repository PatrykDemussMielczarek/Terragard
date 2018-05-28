using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Terragard
{
    class GameController : Types
    {   

        /*-------------Global variables-----------------*/
        public static bool worldChanged;
        public static int worldFPS;
        public static bool frameReady;
        public static bool timeReady;

        /*-----------------Game variables--------------*/
        public const float gravity = 1;


        /*----------------units and objects--------------*/

        public static Player player;


        /*----------------else for now------------------*/
        private GEngine gEngine;
        private Time time; 

        //Starts the graphics engine
        public void StartGraphisc(Graphics g)
        {
            gEngine = new GEngine(g);
            gEngine.InitThread();
        }
        
        public void StartTime()
        {
            time = new Time();
            time.InitThread();
        } 
        public static void StartPlayer(string name)
        {
            player = new Player(name, 100, 20);
            player.InitThread();
        }

        //loads world from NOT_YET file
        public static void LoadWorld()
        { 
            //World.InitBlocksDebug();
            World.InitBlocksFromFile();
        }

        public static void SaveWorld()
        {
            IOscript.WriteFile("D:\\Other\\Terragard\\DebugWorld.txt");
        }

        public static void ClickBlock(int x, int y)
        {
            double d = x / BLOCKS_SIDE_LENGTH; 
            int x_ = (int)Math.Round(d);
            d = y / BLOCKS_SIDE_LENGTH;
            int y_ = (int)Math.Round(d);
            if (World.blocks[x_, y_] == TextureID.airBlock) {
                World.BlockChange(x_, y_, TextureID.nullBlock);
            }
            else if(World.blocks[x_, y_] == TextureID.nullBlock) {
                World.BlockChange(x_, y_, TextureID.airBlock);
            }
        }

        public void StopGame()
        { 
            gEngine.StopRenderThread();
            time.StopTimeThread();
            player.StopPlayerThread();
        } 
    }
}
