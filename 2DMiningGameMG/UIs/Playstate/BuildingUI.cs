using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMiningGameMG.UIs.Playstate
{
    internal class BuildingUI : IUI
    {
        private Texture2D buildingBarBackground;

        public BuildingUI(Vector2 screenSize)
        {
 
        }

        public void LoadContent(ContentManager content)
        {
            buildingBarBackground = content.Load<Texture2D>("Sprites\\UIs\\Playstate\\BuildingBarBackground");
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 screenSize)
        {
            spriteBatch.Draw(buildingBarBackground, new Vector2(screenSize.X / 2 - buildingBarBackground.Width / 2, screenSize.Y - buildingBarBackground.Height), Color.White);
        }
    }
}
