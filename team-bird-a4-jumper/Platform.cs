using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace team_bird_a4_jumper
{
    internal class Platform
    {
        Vector2 block = new Vector2(100, 900);

        public void Update() 
        {
            Draw.Capsule(block.X, block.Y, block.X + 100, block.Y, 30);
        }
    }
}
