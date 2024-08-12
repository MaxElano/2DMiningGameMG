using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct3D9;

namespace _2DMiningGameMG
{
    internal class World
    {
        private Tile[,,] worldGrid;
        private Vector2 cameraOffset;
        public World(Tile[,,] grid = null) 
        {
            if (grid is null)
                worldGrid = CreateNewWorldGrid(25, 25, 25);
        }

        private Tile[,,] CreateNewWorldGrid(int width, int height, int depth)
        {
            Tile[,,] grid = new Tile[width, height, depth];
            for (int i = 0; i < width; i++)
                for (int j = 0; i < height; j++)
                    for (int k = 0; k < depth; k++)
                    {
                        if (k == 0)
                            grid[i, j, k] = new GrassTile(i, j, k);
                        else
                            grid[i, j, k] = new StoneTile(i, j, k);
                    }
            return grid;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawTiles(spriteBatch);
        }

        protected void DrawTiles(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < worldGrid.GetLength(0); i++)
                for (int j = 0; i < worldGrid.GetLength(1); j++)
                    for (int k = 0; k < worldGrid.GetLength(2); k++)
                    {
                        if (worldGrid[i, j, k] is null)
                            continue;
                        else
                            worldGrid[i, j, k].Draw(spriteBatch, cameraOffset);
                    }
        }
    }
}
