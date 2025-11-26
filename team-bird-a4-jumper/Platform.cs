using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
/*
namespace team_bird_a4_jumper
{
    internal class Platform
    {
        private float speed = 5f;
        private float minX = 100f;
        private float maxX = 400f;
        private int direction = 1;  
        Player player = new Player();
        Vector2 block = new Vector2(100, 900);
        float playerHeight = 50;
      

        public void Update() 
        {
            block.X += speed * direction;
           
            if (block.X >= maxX || block.X <= minX)
            {
                direction *= -1;
            }

            Draw.Capsule(block.X, block.Y, block.X + 100, block.Y, 30);
            player.Update();
        }
        public void Collision()
        {
            if (player.Y + playerHeight > block.Y)
            {
                player.Y = block.Y - playerHeight;
            }
        }
    }
}*/
