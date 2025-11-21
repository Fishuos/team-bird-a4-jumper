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
        public Vector2 velocity;
        Vector2 player = new  Vector2(300, 900);
        int playerSize = 50;
        public void Setup()
        {

        }

        public void Update()
        {
            Draw.Rectangle(player.X, player.Y,playerSize,100);
            Movement();
            ApplyGravity();
            KeepPlayerOnScreen();
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

            if ( Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                player.X += speed;
            }
            if ( Input.IsKeyboardKeyDown(KeyboardInput.A))
            {
                player.X -= speed;
            }
            if ( Input.IsKeyboardKeyPressed(KeyboardInput.Space))
            {
                velocity.Y -= 8;
            }
        }
    }
}
