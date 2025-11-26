// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;
using team_bird_a4_jumper;

// The namespace your code is in.
namespace MohawkGame2D
{
    public class Game
    {
        // Place your variables here:
        Player player = new Player();
        public void Setup()
        {
            Window.SetSize(600, 1000);
            Window.SetTitle("Jumper");
            player.Setup();
        }

        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);
            player.Update();
        }
    }

}
