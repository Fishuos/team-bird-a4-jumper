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
        Vector2 velocity;
        Vector2 player = new  Vector2(300, 900);
        public void Setup()
        {

        }

        public void Update()
        {
            Draw.Rectangle(player.X, player.Y,50,100);
            Movement();
            ApplyGravity();
            ConstrainBallToScreen();
        }
        void ApplyGravity()
        {
            //apply gravity to velocity
            velocity += new Vector2(0, 10) * Time.DeltaTime;

            //apply velocity to postion
            player += velocity;

        }
        void ConstrainBallToScreen()
        {
            // is bottom of ball at or past edge of screen

            if (player.Y + 100 >= Window.Height)
            {
                velocity.Y = -velocity.Y;

                velocity *= 0.8f;


               player.Y = Window.Height - 100;

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
            if ( Input.IsKeyboardKeyDown(KeyboardInput.Space))
            {
                player.Y -= speed;
            }
        }
    }
}
