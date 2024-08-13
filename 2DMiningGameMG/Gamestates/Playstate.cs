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

        public Playstate() : base()
        {
            
        }
        public override void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            world = new World(graphics);
            world.LoadContent(content);
            base.LoadContent(content, graphics);
        }

        public override void Update(GameTime gameTime)
        {
            InputHelper(gameTime);
            world.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            world.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }

        public void InputHelper(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                world.cameraOffset += new Vector2(0, cameraSpeed * gameTime.ElapsedGameTime.Milliseconds);
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                world.cameraOffset -= new Vector2(0, cameraSpeed * gameTime.ElapsedGameTime.Milliseconds);
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                world.cameraOffset += new Vector2(cameraSpeed * gameTime.ElapsedGameTime.Milliseconds, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                world.cameraOffset -= new Vector2(cameraSpeed * gameTime.ElapsedGameTime.Milliseconds, 0);
        }
    }
}
