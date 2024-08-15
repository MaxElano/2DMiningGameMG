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
    internal interface IUI
    {
        public void LoadContent(ContentManager content);

        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch, Vector2 screenSize);
    }
}
