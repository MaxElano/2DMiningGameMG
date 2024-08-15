using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace _2DMiningGameMG.UIs
{
    internal class UIItem
    {
        private Vector2 centrePosition;
        private Texture2D texture;
        public UIItem(Vector2 centrePosition, Texture2D texture) 
        { 
            this.centrePosition = centrePosition;
            this.texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, centrePosition, Color.White);
        }
    }
}
