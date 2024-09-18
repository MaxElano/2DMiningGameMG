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
        private float distanceBetweenBuildables = 40f;
        private Vector2 screenSize;
        private UIItem selectedRing;

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
            selectedRing.Draw(spriteBatch);
        }

        private void InitializeIcons()
        {
            AddBuildable(new UIItem(UIItem.BuildableName.Miner));
            AddBuildable(new UIItem(UIItem.BuildableName.Conveyer));
            AddBuildable(new UIItem(UIItem.BuildableName.Chest));


            selectedRing = new UIItem(UIItem.BuildableName.SelectedRing);

            for (int i = 0; i < buildables.Count; i++)
            {
                buildables[i].SetLocation(screenSize, buildables.Count, i, buildingBarBackground.Height, distanceBetweenBuildables);
            }
        }

        public UIItem CheckForClickOnIcon(Vector2 clickLocation)
        {
            foreach (UIItem item in buildables)
                if (item.rectangle.Contains(clickLocation.X, clickLocation.Y))
                {
                    selectedRing.ManualSetLocation(item.centrePosition, 1f);
                    return item;
                }
            return null;
        }

        public void AddBuildable(UIItem buildable)
        {
            buildables.Add(buildable);
        }
    }
}
