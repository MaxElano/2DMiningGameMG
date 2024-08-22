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
using _2DMiningGameMG.UIs.Playstate;


namespace _2DMiningGameMG
{
    internal class World
    {

        
        
        public Vector2 CameraOffset { get; set; }
        private Vector2 originalHalfGridSize;
        private Vector2 position;

        private WorldGrid worldGrid;
        
        public bool mouseClicked = false;
        private Random randomOreGenerator;
        private int drawStartLayer;
        
        private BuildingUI buildingUI;

        public World(GraphicsDeviceManager graphics, BuildingUI buildingUI) 
        {
            this.randomOreGenerator = new Random();
            this.drawStartLayer = 0;

            CameraOffset = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
        }


        public void Update(GameTime gameTime)
        {
            worldGrid.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            worldGrid.Draw(spriteBatch);
        }


        public void HandleMouseClick(MouseState mouseState)
        {
            Vector2 pos = mouseState.Position.ToVector2();
            Vector2 gpos = (pos - CameraOffset + originalHalfGridSize * squareSize + new Vector2(squareSize / 2, squareSize / 2)) / squareSize;
            gpos = new Vector2((float)Math.Floor(gpos.X), (float)Math.Floor(gpos.Y));

            if (0 <= (int)gpos.X && (int)gpos.X < WorldGrid.GetLength(0) && 0 <= (int)gpos.Y && (int)gpos.Y < WorldGrid.GetLength(1))
                PlaceBuilding(gpos, new Miner(WorldGrid, (int)gpos.X, (int)gpos.Y, topLayer - 1, textures[TextureName.miner]));
        }

    }
}
