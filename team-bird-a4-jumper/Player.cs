using MohawkGame2D;
using System;
using System.Numerics;

namespace team_bird_a4_jumper
{
    internal class Player
    {
        public bool isInAir;
        public Vector2 velocity;

        Vector2 player = new Vector2(300, 900);
        float playerWidth = 50;
        float playerHeight = 100;
        public bool isColliding;
        bool isMoving;
        float cameraY = 0f;

        private float speed = 5f;
        private float minX = 100f;
        private float maxX = 400f;

        float blockWidth = 160;
        float blockHeight = 40;
        Vector2[] platforms = new Vector2[5];
        int[] platformDirections = new int[5];

        public void Setup()
        {
            for (int i = 0; i < platforms.Length; i++)
            {
                float x = MohawkGame2D.Random.Integer(50, 450);
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

            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space) && !isInAir)
            {
                velocity.Y = -8;
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
                    }
                }
            }
        }

        void KeepPlayerOnScreen()
        {
            if (player.Y + playerHeight >= Window.Height)
            {
                velocity.Y = 0;
                player.Y = Window.Height - playerHeight;
            }

            if (player.X < -45)
                player.X = 625;

            if (player.X > 625)
                player.X = -45;
        }

        void WorldMove()
        {
            float screenFollowAt = Window.Height * 0.7f;

            if (player.Y + cameraY < screenFollowAt)
            {
                float difference = screenFollowAt - (player.Y + cameraY);
                cameraY += difference;
            }
        }

        void SpawnPlatforms()
        {
            for (int i = 0; i < platforms.Length; i++)
            {
                if (player.Y + 200 < platforms[i].Y)
                {
                    platforms[i].X = MohawkGame2D.Random.Integer(50, 450);
                    platforms[i].Y -= 800;
                }
            }
        }

        void UpdatePlatforms()
        {
            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i].X += speed * platformDirections[i];

                if (platforms[i].X >= maxX || platforms[i].X <= minX)
                    platformDirections[i] *= -1;

                Draw.Rectangle(platforms[i].X, platforms[i].Y + cameraY, blockWidth, blockHeight);
            }
        }

        public void DrawPlayer()
        {
            Draw.Rectangle(player.X, player.Y + cameraY, playerWidth, playerHeight);
        }
    }
}
