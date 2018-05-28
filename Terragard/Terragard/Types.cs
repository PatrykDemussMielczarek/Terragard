using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terragard
{ 

    //[System.Serializable]
    class Types
    {
        /*-------constatnts------------------*/
        public const int CANVAS_X = 720;
        public const int CANVAS_Y = 480;
        public const int WINDOW_X = CANVAS_X + 16;
        public const int WINDOW_Y = CANVAS_Y + 38;
        public const int CAM_VIEW_X = 36;
        public const int CAM_VIEW_Y = 24;
        public const int WORLD_X = 36;
        public const int WORLD_Y = 24;
        public const int BLOCKS_SIDE_LENGTH = CANVAS_X / CAM_VIEW_X;
        public const int CHARACTER_SIDE_X = 40;
        public const int CHARACTER_SIDE_Y = 60;

        public struct Vector2
        {
            public float x, y;

            public Vector2(float x_, float y_)
            {
                x = x_;
                y = y_;
            }
        }
         
        public enum TextureID
        {
            airBlock,
            nullBlock
        }
    }
}
