using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terragard
{
    class Block : Types
    {
        public int x, y;
        public TextureID tex;

        public Block(int x_, int y_, TextureID tex_)
        {
            x = x_;
            y = y_;
            tex = tex_;
        }
    }
}
