using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct3D9;
using Microsoft.Xna.Framework.Content;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework.Input;
using System.CodeDom;


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

            CameraOffset = new Vector2(0, 0);
        }

        public void Update(GameTime gameTime)
        {
            WorldGrid.Update(gameTime);
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
            return screenLocation;
        }
    }
}
