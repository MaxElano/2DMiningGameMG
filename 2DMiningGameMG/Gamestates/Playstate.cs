using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _2DMiningGameMG
{
    internal class Playstate : Gamestate
    {
        World world;
        float cameraSpeed = 1f;
        InputHelper inputHelper;
        public Playstate() : base()
        {
            
        }
        public override void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            inputHelper = new InputHelper();
            world = new World(graphics);
            world.LoadContent(content);
            base.LoadContent(content, graphics);
        }

        public override void Update(GameTime gameTime)
        {
            inputHelper.UpdatePlayState(gameTime, world);
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
