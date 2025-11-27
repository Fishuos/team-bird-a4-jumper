using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Game
    {
        // Place your variables here:
        Player player = new Player();
        Coin coin = new Coin();

        public void Setup()
        {
            Window.SetSize(600, 1000);
            Window.SetTitle("Jumper");
            player.Setup();
        }

        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);            
            coin.Update();
            player.Update();
        }
    }

}
