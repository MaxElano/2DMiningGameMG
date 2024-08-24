using _2DMiningGameMG;
using _2DMiningGameMG.Tiles.Buildings;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using System;

namespace _2DMiningGameMG
{
    internal class Playstate : IGamestate
    {
        World world;
        float cameraSpeed = 1f;
        InputHelper inputHelper;
        BuildingUI buildingUI;
        IBuildable selectedBuildable;
        int buildLayer;

        public Playstate(InputHelper inputHelper = null)
        {
            if (inputHelper == null)
                this.inputHelper = new InputHelper();
            else
                this.inputHelper = inputHelper;

            buildLayer = 4;
        }

        public void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            inputHelper = new InputHelper();
            buildingUI = new BuildingUI(new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));
            world = new World(graphics, buildingUI);
        }

        public void Update(GameTime gameTime)
        {
            UpdateControls(gameTime);
            inputHelper.Update();
            world.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            world.Draw(spriteBatch);
            buildingUI.Draw(spriteBatch, new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));
        }

        public void UpdateControls(GameTime gameTime)
        {
            world.CameraOffset += inputHelper.CameraMovement(gameTime);

            (bool placeBuild, Vector2 placeLoc) = inputHelper.PlaceBuilding();
            if (selectedBuildable is not null && placeBuild && selectedBuildable is Tile)
            {
                Vector2 gridLoc = world.ScreenToGridLocation(placeLoc);
                world.WorldGrid.PlaceTile(new Vector3(gridLoc.X, gridLoc.Y, buildLayer), (Tile)selectedBuildable);
            }
        }
    }
}
