using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace _2DMiningGameMG
{
    internal interface IGamestate
    {
        public void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {

        }
        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {

        }
    }
}
