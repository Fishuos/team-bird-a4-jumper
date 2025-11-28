
using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Coin
    {
        bool isColliding;

        Vector2 coinPosition = new Vector2(200, 880);
        Vector2[] coinHitbox = new Vector2[4];
        float coinWidth = 20;
        float coinHeight = 20;

        Vector2 playerPos = new Vector2(0, 0);


        public void Setup()
        {
            for (int i = 0; i < coinHitbox.Length; i++)
            {
                float x = MohawkGame2D.Random.Integer(50, 550);
                float y = 900 - i * 200;
                coinHitbox[i] = new Vector2(x, y);
            }
        }

        public void Update()
        {           
            DrawCoinHitbox();
            DrawCoin(); 
            Collision(playerPos, 0, 0);
        }       
        public void DrawCoin()
        {
            //draw coin
            Draw.FillColor = Color.Yellow;
            Draw.Circle(coinPosition, 20);
        }

        void DrawCoinHitbox()
        {
            //draw temporary hitbox
            Draw.FillColor = Color.Black;
            Draw.Square(coinPosition.X - 20, coinPosition.Y - 20, 40);
        }

       public void Collision(Vector2 playerPos, float x, float y)
        {
            isColliding = false;

            for (int i = 0; i < coinHitbox.Length; i++)
            {
                Vector2 coin = coinHitbox[i];

                //bounds for collision
                bool colliding =
                    playerPos.X < coin.X + coinWidth &&
                    playerPos.X + coinWidth > coin.X &&
                    playerPos.Y < coin.Y + coinHeight &&
                    playerPos.Y + coinHeight > coin.Y;

                if (colliding)
                {
                    isColliding = true;
                    coinHitbox[i].Y -= 800;
                }
            }
        }
    }
}
