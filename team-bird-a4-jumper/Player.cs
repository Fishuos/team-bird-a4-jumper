using MohawkGame2D;
using System;
using System.Numerics;

namespace team_bird_a4_jumper
{
    internal class Player
    {
        public bool isInAir;
        public Vector2 velocity;

        //variables
        Vector2 player = new Vector2(300, 900);
        float playerWidth = 50;
        float playerHeight = 100;
        public bool isColliding;
        bool isMoving;
        float cameraY = 0f;
        int standingPlatform = -1;

        //platform move info
        private float speed = 5f;
        private float minX = 50f;
        private float maxX = 550f;

        //Collision variables and platform
        float blockWidth = 160;
        float blockHeight = 40;
        Vector2[] platforms = new Vector2[5];
        int[] platformDirections = new int[5];

        public void Setup()
        {
            for (int i = 0; i < platforms.Length; i++)
            {
                float x = MohawkGame2D.Random.Integer(25, 425);
                float y = 900 - i * 200;
                platforms[i] = new Vector2(x, y);
                platformDirections[i] = 1;
            }
        }

        public void Update()
        {
            Movement();
            ApplyGravity();
            KeepPlayerOnScreen();
            Collision();
            WorldMove();
            SpawnPlatforms();
            UpdatePlatforms();
            DrawPlayer();
        }

        public void Movement()
        {
            isMoving = false;

            //move right
            if (Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                player.X += speed;
                isMoving = true;
            }

            //move left
            if (Input.IsKeyboardKeyDown(KeyboardInput.A))
            {
                player.X -= speed;
                isMoving = true;
            }

            //jump
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space) && !isInAir)
            {
                velocity.Y = -8.2f;
                isMoving = true;
            }

            isInAir = velocity.Y != 0;
        }

        void ApplyGravity()
        {
            velocity += new Vector2(0, 10) * Time.DeltaTime;
            player += velocity;
        }

        void Collision()
        {
            isColliding = false;

            for (int i = 0; i < platforms.Length; i++)
            {
                Vector2 block = platforms[i];

                bool colliding =
                    player.X < block.X + blockWidth &&
                    player.X + playerWidth > block.X &&
                    player.Y < block.Y + blockHeight &&
                    player.Y + playerHeight > block.Y;

                if (colliding)
                {
                    isColliding = true;


                    if (velocity.Y > 0 && player.Y + playerHeight <= block.Y + blockHeight)
                    {
                        player.Y = block.Y - playerHeight;
                        velocity.Y = 0;
                        isInAir = false;
                        standingPlatform = i;
                    }
                }

                else
                {
                    if (standingPlatform == i)
                    {
                        standingPlatform = -1;
                    }
                }
            }
        }

        void KeepPlayerOnScreen()
        {
            //resets everything if you fall off screen
            if (player.Y + playerHeight >= Window.Height + 200)
            {
                Reset();
            }

            //keeps player on screen at the start of the game
            if (isInAir == false)
            {
                if (player.Y + playerHeight >= Window.Height)
                {
                    velocity.Y = 0;
                    player.Y = Window.Height - playerHeight;
                }

                //lets you teleport from one side to the other
                if (player.X < -45)
                    player.X = 625;

                if (player.X > 625)
                    player.X = -45;
            }
        }

        // creates a camera follow effect
        void WorldMove()
        {
            float screenFollowAt = Window.Height * 0.7f; //where camera starts moving

            if (player.Y + cameraY < screenFollowAt)
            {
                float follow = screenFollowAt - (player.Y + cameraY);
                cameraY += follow; // moves camera 
            }
        }

        void SpawnPlatforms()
        {
            //spanws platforms above player
            for (int i = 0; i < platforms.Length; i++)
            {
                if (player.Y + 300 < platforms[i].Y)
                {
                    //spawns at random x, and above 800
                    platforms[i].X = MohawkGame2D.Random.Integer(50, 450);
                    platforms[i].Y -= 800;
                }
            }
        }

        public void Reset()
        {
            //resets everything
            player = new Vector2(300, 900);
            velocity = Vector2.Zero;
            cameraY = 0f;
            isInAir = false;

            for (int i = 0; i < platforms.Length; i++)
            {

                float x = MohawkGame2D.Random.Integer(25, 425);
                float y = 900 - i * 200;
                platforms[i] = new Vector2(x, y);
                platformDirections[i] = 1;
            }
        }

        void UpdatePlatforms()
        {
            for (int i = 0; i < platforms.Length; i++)
            {
                //moves platforms back and forth
                platforms[i].X += speed * platformDirections[i];

                if (platforms[i].X >= maxX || platforms[i].X <= minX)
                    platformDirections[i] *= -1;

                Draw.Rectangle(platforms[i].X, platforms[i].Y + cameraY, blockWidth, blockHeight);

                if (standingPlatform == i)
                {
                    player.X += speed * platformDirections[i]; //moves player with platform
                }
            }
        }

        public void DrawPlayer()
        {
            Draw.Rectangle(player.X, player.Y + cameraY, playerWidth, playerHeight);
        }
    }
}
