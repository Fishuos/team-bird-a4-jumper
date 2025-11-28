// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;
using System.Threading.Tasks.Sources;

// The namespace your code is in.
namespace MohawkGame2D
{
    public class Game
    {
        Texture2D scoreTeller;

        Player player = new Player();
        public void Setup()
        {
            Window.SetSize(600, 1000);
            Window.SetTitle("Jumper");
            player.Setup();
            scoreTeller = Graphics.LoadTexture(.. / .. / .. / .. / assets / graphics / score teller.png);
        }

        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);
            player.Update();
            string score = $"{player.score}";
            Text.Color = Color.Green;
            Text.Draw($"Score: {score}", 450, 25);
        }
    }
}