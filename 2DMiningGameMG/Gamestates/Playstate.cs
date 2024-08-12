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
    internal class Playstate : Gamestate
    {
        World world;
        public Playstate() : base()
        {
            world = new World();
        }
        public override void LoadContent(ContentManager content)
        {
            world.LoadContent(content);
            base.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            world.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            world.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}
