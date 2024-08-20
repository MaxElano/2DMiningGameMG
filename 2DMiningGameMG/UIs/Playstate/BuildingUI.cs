using _2DMiningGameMG.Tiles.Buildings;
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
        private List<IBuildable> buildables;
        private float buildablesScaling = 0.5f;
        private float distanceBetweenBuildables = 10f;

        public BuildingUI(Vector2 screenSize)
        {
            buildables = new List<IBuildable>();
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

            for (int i = 0; i < buildables.Count; i++) 
            {
                if (buildables[i].Usable)
                {
                    Texture2D texture = (buildables[i] as Tile).Texture;
                    float xCoord = screenSize.X / 2 + (i - buildables.Count / 2) * (texture.Width * buildablesScaling + distanceBetweenBuildables);
                    float yCoord = screenSize.Y - buildingBarBackground.Height / 2 - texture.Height / 2 * buildablesScaling;
                    spriteBatch.Draw(texture, new Vector2(xCoord, yCoord), Color.White);
                }
            }
        }

        public void AddBuildable(IBuildable buildable)
        {
            buildables.Add(buildable);
        }
    }
}
