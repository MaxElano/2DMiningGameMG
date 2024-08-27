using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMiningGameMG
{
    internal class BuildingUI : IUI
    {
        private Texture2D buildingBarBackground;
        private List<UIItem> buildables;
        private float buildablesScaling = 0.5f;
        private float distanceBetweenBuildables = 10f;
        private Vector2 screenSize;

        public BuildingUI(Vector2 screenSize)
        {
            this.screenSize = screenSize;

            buildables = new List<UIItem>();
            

            (this.buildingBarBackground, _) = TextureDictionary.Textures[TextureDictionary.TextureName.buildingBarBackground];

            InitializeIcons();
        }


        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 screenSize)
        {
            spriteBatch.Draw(buildingBarBackground, new Vector2(screenSize.X / 2 - buildingBarBackground.Width / 2, screenSize.Y - buildingBarBackground.Height), Color.White);

            buildables.ForEach(b => { if (b.Visible) b.Draw(spriteBatch); });
        }

        private void InitializeIcons()
        {
            AddBuildable(new UIItem(UIItem.BuildableName.Miner));

            for (int i = 0; i < buildables.Count; i++)
            {
                Texture2D texture = buildables[i].Texture;
                float xCoord = screenSize.X / 2 + (i - buildables.Count / 2) * (texture.Width * buildablesScaling + distanceBetweenBuildables);
                float yCoord = screenSize.Y - buildingBarBackground.Height / 2 - texture.Height / 2 * buildablesScaling;
                buildables[i].SetLocation(new Vector2(xCoord, yCoord));
            }
        }

        public void AddBuildable(UIItem buildable)
        {
            buildables.Add(buildable);
        }
    }
}
