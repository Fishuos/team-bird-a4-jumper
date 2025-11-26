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
        public bool isColliding;
        bool isMoving;

        //move left and right
        private float speed = 5f;
        private float minX = 100f;
        private float maxX = 400f;
        private int direction = 1;
        
        Vector2 block = new Vector2(100, 900);
        

        public void Setup()
        {

        }

        public void Update()
        {
            DrawPlatform();
            DrawPlayer();
            Movement();
            ApplyGravity();
            KeepPlayerOnScreen();
            Collision();
        }

       public void Movement()
        {
            int speed = 5;

            if (Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                player.X += speed;
                isMoving = true;
            }

            if (Input.IsKeyboardKeyDown(KeyboardInput.A))
            {
                player.X -= speed;
                isMoving = true;
            }

            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
            {
                if (isInAir == false)
                {
                    velocity.Y -= 8;
                    isMoving = true;
                }
            }
            else
            {
                isMoving = false;
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
           isColliding =
                player.X < block.X + blockWidth &&
                player.X + playerWidth > block.X &&
                player.Y < block.Y + blockHeight &&
                player.Y + playerHeight > block.Y;

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
            block.X += speed * direction;

            if (block.X >= maxX || block.X <= minX)
            {
                direction *= -1;
            }

            Draw.Rectangle(block.X, block.Y, blockWidth, blockHeight);
        }

        public void DrawPlayer()
        {
            if (isMoving == false)
            {

                if (isColliding)
                {
                    player.X += speed * direction;

                    if (player.X >= maxX || player.X <= minX)
                    {
                        direction *= -1;
                    }

                }
            }
            Draw.Rectangle(player.X, player.Y, playerWidth, playerHeight);
        }
    }
}
