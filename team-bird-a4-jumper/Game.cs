// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;
using System.Threading.Tasks.Sources;

// The namespace your code is in.
namespace MohawkGame2D
{
    public class Game
    {
        Texture2D background;

        Player player = new Player();
        public void Setup()
        {
            Window.SetSize(600, 1000);
            Window.SetTitle("Jumper");
            player.Setup();
            background = Graphics.LoadTexture("../../../../assets/graphics/background.png");
        }

        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);       
            Graphics.Draw(background, 6, 0);  
            string score = $"{player.score}";
            Text.Color = Color.Black;
            Text.Draw($"Score: {score}", 20, 20);            
            player.Update();     
        }
    }
}