using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace _2DMiningGameMG
{
    internal class UIItem
    {
        public enum BuildableName { Miner, Conveyer}
        public BuildableName name;
        public bool Usable { get; private set; }
        public bool Visible { get; private set; }
        private Vector2 centrePosition;
        public Texture2D Texture { get; private set; }
        public Rectangle rectangle { get; private set; }

        public float buildableScaling { get; private set; }
        public UIItem(BuildableName name) 
        { 
            Usable = true;
            Visible = true;
            this.name = name;
            this.buildableScaling = 0.9f;
            SetTexture();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, centrePosition, new Rectangle(0, 0, Texture.Width, Texture.Height), Color.White, 0f, new Vector2(Texture.Width, Texture.Height), buildableScaling, SpriteEffects.None, 1);
        }

        private void SetTexture()
        {
            switch (name)
            {
                case BuildableName.Miner:
                    (this.Texture, _) = TextureDictionary.Textures[TextureDictionary.TextureName.minerIcon];
                    break;
                case BuildableName.Conveyer:
                    (this.Texture, _) = TextureDictionary.Textures[TextureDictionary.TextureName.conveyerIcon];
                    break;
            }
        }

        public void SetLocation(Vector2 screenSize, int buildablesCount, int index, float buildingBarBackgroundHeight, float distanceBetweenBuildables)
        {
            float xCoord = screenSize.X / 2 + (index - buildablesCount / 2) * (Texture.Width * buildableScaling + distanceBetweenBuildables);
            float yCoord = screenSize.Y - buildingBarBackgroundHeight / 2 + (Texture.Height / 2) * buildableScaling;
            centrePosition = new Vector2(xCoord, yCoord);
            rectangle = new Rectangle((int)(centrePosition.X - (Texture.Width * buildableScaling)), (int)(centrePosition.Y - (Texture.Height * buildableScaling)), (int)(Texture.Width * buildableScaling), (int)(Texture.Height * buildableScaling));
        }
        
    }
}
