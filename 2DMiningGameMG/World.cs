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
        private static List<Resource> resources;
        
        public bool mouseClicked = false;
        private Random randomOreGenerator;
        private int drawStartLayer;
        
        private BuildingUI buildingUI;

        public World(GraphicsDeviceManager graphics, BuildingUI buildingUI) 
        {
            this.randomOreGenerator = new Random();
            this.drawStartLayer = 0;

            resources = new List<Resource>();

            WorldGrid = new WorldGrid(this);

            CameraOffset = new Vector2(0, 0);
            World.resources.Clear();
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

        public static void AddResource(Resource resource)
        {
            resources.Add(resource);
        }

        public static void RemoveResource(Resource resource)
        {
            resources.Remove(resource);
        }
    }
}
