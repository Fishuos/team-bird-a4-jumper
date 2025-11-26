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
        private float speed = 5f;
        private float minX = 100f;
        private float maxX = 400f;
        private int direction = 1;
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
            //Collision();
            //PlatformMovement();
        }
        void DrawPlatform()
        {
            Draw.Rectangle(blockX, blockY, blockWidth, blockHeight);
        }

       /* void PlatformMovement()
        {
            block.X += speed * direction;

            if (block.X >= maxX || block.X <= minX)
            {
                direction *= -1;
            }
        }*/



        public void DrawPlayer()
        {
            Draw.Rectangle(player.X, player.Y, playerWidth, playerHeight);
        }

        void ApplyGravity()
        {
            //apply gravity to velocity
            velocity += new Vector2(0, 10) * Time.DeltaTime;

            //apply velocity to postion
            player += velocity;
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

            if (velocity.Y == 0)
            {
                isInAir = false;
            }

            else
            {
                isInAir = true;
            }
        } 
    }
}
