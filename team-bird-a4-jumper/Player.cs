using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace team_bird_a4_jumper
{
    internal class Player
    {
        public bool isInAir;
        public Vector2 velocity;

        //block variables
        float blockX = 100;
        float blockY = 900;
        float blockWidth = 160;
        float blockHeight = 40;

        //player variables
        Vector2 player = new(300, 900);
        //float playerX = 300;
        //float playerY = 900;
        float playerWidth = 50;
        float playerHeight = 100;

        public void Setup()
        {

        }

        public void Update()
        {
            DrawPlayer();
            Movement();
            ApplyGravity();
            KeepPlayerOnScreen();
            DrawPlatform();
            Collision();
        }

       public void Movement()
        {
            int speed = 5;

            if (Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                player.X += speed;
            }

            if (Input.IsKeyboardKeyDown(KeyboardInput.A))
            {
                player.X -= speed;
            }

            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
            {
                if (isInAir == false)
                {
                    velocity.Y -= 8;
                }
            }
        } 

        void ApplyGravity()
        {
            //apply gravity to velocity
            velocity += new Vector2(0, 10) * Time.DeltaTime;

            //apply velocity to postion
            player += velocity;

        }

        void Collision()
        {
            bool isColliding =
                player.X < blockX + blockWidth &&
                player.X + playerWidth > blockX &&
                player.Y < blockY + blockHeight &&
                player.Y + playerHeight > blockY;

            if (isColliding)
            {
                if (velocity.Y > 0 && player.Y + playerHeight <= blockY + 10) 
                { 
                    player.Y = blockY - playerHeight;
                    velocity.Y = 0;
                    isInAir = false;
                }
            }
        }

        void KeepPlayerOnScreen()
        {
            if (player.Y + 100 >= Window.Height)
            {
                velocity.Y = -velocity.Y;
                velocity *= 0f;

                player.Y = Window.Height - 100;
            }

            if (player.X < -45)
            {
                player.X = 625;

            }

            if (player.X > 625)
            {
                player.X = -45;
            }
        }

        void DrawPlatform()
        {
            Draw.Rectangle(blockX, blockY, blockWidth, blockHeight);
        }

        public void DrawPlayer()
        {
            Draw.Rectangle(player.X, player.Y, playerWidth, playerHeight);
        }
    }
}
