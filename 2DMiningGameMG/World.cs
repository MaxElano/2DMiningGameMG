using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Reflection.Metadata;
using SharpDX.Direct3D9;
using SharpDX.DirectWrite;
using System.Diagnostics;
using System.Security.Cryptography.Xml;
using static _2DMiningGameMG.UIItem;
using Microsoft.Xna.Framework.Content;


namespace _2DMiningGameMG
{
    internal class World
    {
        public Vector2 CameraOffset { get; set; }

        public WorldGrid WorldGrid { get; private set; }
        private List<Resource> resources;
        
        public bool mouseClicked = false;
        private Random randomOreGenerator;
        private int drawStartLayer;
        
        private BuildingUI buildingUI;

        public World(GraphicsDeviceManager graphics, BuildingUI buildingUI) 
        {
            this.randomOreGenerator = new Random();
            this.drawStartLayer = 0;

            resources = new List<Resource>();

            WorldGrid = new WorldGrid();

            CameraOffset = new Vector2(0, 0);
        }

        public void Update(GameTime gameTime)
        {
            WorldGrid.Update(gameTime, CameraOffset);
            resources.ForEach(r => r.Update(gameTime, CameraOffset));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            WorldGrid.Draw(spriteBatch, drawStartLayer);
            resources.ForEach(r => r.Draw(spriteBatch));
        }


        //public void HandleMouseClick(MouseState mouseState)
        //{
        //    Vector2 pos = mouseState.Position.ToVector2();
        //    Vector2 gpos = (pos - CameraOffset + originalHalfGridSize * squareSize + new Vector2(squareSize / 2, squareSize / 2)) / squareSize;
        //    gpos = new Vector2((float)Math.Floor(gpos.X), (float)Math.Floor(gpos.Y));

        //    if (0 <= (int)gpos.X && (int)gpos.X < WorldGrid.GetLength(0) && 0 <= (int)gpos.Y && (int)gpos.Y < WorldGrid.GetLength(1))
        //        PlaceBuilding(gpos, new Miner(WorldGrid, (int)gpos.X, (int)gpos.Y, topLayer - 1, textures[TextureName.miner]));
        //}

        public Vector2 ScreenToGridLocation(Vector2 screenLocation)
        {
            screenLocation -= CameraOffset;
            screenLocation /= WorldGrid.SquareSize;
            screenLocation.Floor();

            return screenLocation;
        }
        
        public Vector2 GridToScreenLocation(Vector2 gridLocation)
        {
            gridLocation *= WorldGrid.SquareSize;
            gridLocation += CameraOffset;

            return gridLocation;
        }

        public void DrawTemp(UIItem temp, SpriteBatch spritebatch, Vector2 mouseLocation)
        {
            Vector2 location = ScreenToGridLocation(mouseLocation);
            if (WorldGrid.CheckInGrid(new Vector3(location.X, location.Y, 0)))
            {
                location = GridToScreenLocation(location);
                temp.DrawTemp(spritebatch, location);
            }
        }
    }
}
