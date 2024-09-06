using _2DMiningGameMG;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using SharpDX.DirectWrite;
using System;
using static _2DMiningGameMG.UIItem;

namespace _2DMiningGameMG
{
    internal class Playstate : IGamestate
    {
        World world;
        float cameraSpeed = 1f;
        InputHelper inputHelper;
        BuildingUI buildingUI;
        UIItem selectedBuildable;
        int buildLayer;
        SpriteBatch spriteBatch;
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
            selectedBuildable = new UIItem(BuildableName.Miner);
        }

        public void Update(GameTime gameTime)
        {
            UpdateControls(gameTime);
            inputHelper.Update();
            world.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            this.spriteBatch = spriteBatch;
            world.Draw(spriteBatch);
            buildingUI.Draw(spriteBatch, new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));
        }

        public void UpdateControls(GameTime gameTime)
        {
            world.CameraOffset += inputHelper.CameraMovement(gameTime);

            HandleClick();
        }

        private void HandleRotate()
        {
            if (inputHelper.RotatePressed())
                
        }

        private void HandleClick()
        {
            (bool placeBuild, Vector2 placeLoc) = inputHelper.PlaceBuilding();

            if (selectedBuildable is not null && placeBuild && selectedBuildable.Usable)
            {
                if (ClickOnIcon(placeLoc))
                    return;
                if (ClickOnGrid(placeLoc))
                    return;
            }
        }

        private bool ClickOnIcon(Vector2 placeLoc)
        {
            UIItem newSelect = buildingUI.CheckForClickOnIcon(placeLoc);
            if (newSelect is not null)
            {
                selectedBuildable = newSelect;
                return true;
            }
            return false;
        }

        private bool ClickOnGrid(Vector2 placeLoc)
        {
            Vector2 gridLoc = world.ScreenToGridLocation(placeLoc);
            Vector3 loc = new Vector3(gridLoc.X, gridLoc.Y, buildLayer);
            if (world.WorldGrid.CheckInGrid(loc))
            {
                world.WorldGrid.PlaceTile(loc, CreateCorrectTileFromUI(loc, selectedBuildable.name));
                return true;
            }
            return false;
        }

        private Tile CreateCorrectTileFromUI(Vector3 location, BuildableName name)
        {
            switch (name) 
            { 
                case BuildableName.Miner:
                    return new Miner(world.WorldGrid, location);
                case BuildableName.Conveyer:
                    return new Conveyer(world, 60f, location);
                default:
                    return null;
            }
        }
    }
}
