using _2DMiningGameMG.UIs.Playstate;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _2DMiningGameMG
{
    internal class Playstate : IGamestate
    {
        World world;
        float cameraSpeed = 1f;
        InputHelper inputHelper;
        BuildingUI buildingUI;

        public Playstate()
        {
            
        }

        public void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            inputHelper = new InputHelper();
            buildingUI = new BuildingUI(new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));
            world = new World(graphics, buildingUI);
            buildingUI.LoadContent(content);

            world.LoadContent(content);
        }

        public void Update(GameTime gameTime)
        {
            inputHelper.UpdatePlayState(gameTime, world);
            world.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            world.Draw(spriteBatch);
            buildingUI.Draw(spriteBatch, new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));
        }

    }
}
