using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terragard
{
    class World : Types
    {
        public static TextureID[,] blocks = new TextureID[WORLD_X, WORLD_Y];
         
        public static void BlockChange(int x, int y, TextureID tex)
        {
            blocks[x, y] = tex;
            GameController.worldChanged = true;
        }

        public static void InitBlocksFromFile()
        {
            //Reading world data...
            IOscript.ReadFile("D:\\Other\\Terragard\\DebugWorld.txt");  
            string[] read = IOscript.worldLevel;
            
            for( int x = 0; x < WORLD_X; x++)
            {
                for (int y = 0; y < WORLD_Y; y++)
                {
                    if( read[x * WORLD_Y + y] == "nullBlock")
                    {
                        blocks[x, y] = TextureID.nullBlock;
                    }
                    else
                    {
                        blocks[x, y] = TextureID.airBlock;
                    }
                }
            } 
            GameController.SaveWorld();
        }

        public static void InitBlocksDebug()
        {  
            for (int x = 0; x < WORLD_X; x++)
            {
                for (int y = 0; y < WORLD_Y; y++)
                {
                    if (y >= 20)
                    {
                        blocks[x, y] = TextureID.nullBlock;
                    }
                    else
                    {
                        blocks[x, y] = TextureID.airBlock;
                    }
                }
            } 
            GameController.SaveWorld();
        }

    }
}
