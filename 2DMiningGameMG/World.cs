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
        enum TileTypes { empty, grass, stone}
        private TileTypes[,,] worldGrid;

        public World() { }

        private TileTypes[,,] CreateNewWorldGrid(int width, int height, int depth)
        {
            TileTypes[,,] grid = new TileTypes[width, height, depth];
            for (int i = 0; i < width; i++)
                for (int j = 0; i < height; j++)
                    for (int k = 0; k < depth; k++)
                    {
                        if (k == 0)
                            grid[i, j, k] = TileTypes.grass;
                        else
                            grid[i, j, k] = TileTypes.stone;
                    }
            return grid;
        }

        protected void Initialize()
        {
            if (worldGrid is null)
                worldGrid = CreateNewWorldGrid(25, 25, 25);
        }

        protected void LoadContent()
        {
           
        }

        protected void Update(GameTime gameTime)
        {

        }

        protected void Draw(SpriteBatch spriteBatch)
        {
            DrawTiles(spriteBatch);
        }

        protected void DrawTiles(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < worldGrid.GetLength(0); i++)
                for (int j = 0; i < worldGrid.GetLength(1); j++)
                    for (int k = 0; k < worldGrid.GetLength(2); k++)
                    {
                        if (worldGrid[i, j, k] == TileTypes.empty)
                            continue;
                        else
                        {
                            switch (worldGrid[i, j, k])
                            {
                                case TileTypes.empty:
                                    spriteBatch.Draw();
                                    break;
                            }
                            break;
                        }
                    }
        }
    }
}
