using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Terragard
{
    class Player : Types
    { 
        //Thread for TickCounter
        private Thread playerThread;

        //initialization of new Thread which stands for player;
        public void InitThread()
        {
            //starting new thread for TickCounter function
            playerThread = new Thread(new ThreadStart(PlayerThread));
            playerThread.Start();
        }

        public void StopPlayerThread()
        {
            playerThread.Abort();
        }


        public string name;
        public float x, y;

        private Vector2 gravity = new Vector2(0, -BLOCKS_SIDE_LENGTH);

        public Player(string name_, int x_, int y_)
        {
            name = name_;
            x = x_;
            y = y_; 
        }
        public void PositionDeltaTime(Vector2 vec)
        {
            //if hits terrain below
            x += vec.x * Time.DeltaTime();
            y += -vec.y * Time.DeltaTime();
        }

        private void PlayerThread()
        {
            Console.WriteLine("Player.PlayerThread: Starts running"); 
            while (true)
            {
                if (GameController.timeReady)
                {
                    GameController.timeReady = false;
                    CheckFalling();
                    Gravity(); 
                }
            }
        }

        private void Gravity()
        {   
            GameController.player.PositionDeltaTime(gravity);
            gravity.y += -BLOCKS_SIDE_LENGTH * 3 * Time.DeltaTime();
        }
        
        private void CheckFalling()
        {
            int x = (int)Math.Floor(GameController.player.x/BLOCKS_SIDE_LENGTH);
            int y = (int)Math.Floor(GameController.player.y/BLOCKS_SIDE_LENGTH);

            //standing on the edge of the world
            if ( x > 0 && y > 0 && x < WORLD_X-1 && y < WORLD_Y-3 )
            {
                if(World.blocks[x, y + 3] == TextureID.nullBlock || World.blocks[x + 1, y + 3] == TextureID.nullBlock)
                {
                    gravity.y = 0; 
                } 
            }else gravity.y = 0;
        }

    }
}
