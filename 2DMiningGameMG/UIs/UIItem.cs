using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public UIItem(BuildableName name) 
        { 
            Usable = true;
            Visible = true;
            this.name = name;

            SetTexture();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, centrePosition, Color.White);
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

        public void SetLocation(Vector2 location)
        {
            centrePosition = location;
        }
    }
}
