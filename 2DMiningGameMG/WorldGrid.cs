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
using SharpDX.Direct2D1.Effects;
using System.Reflection;


namespace _2DMiningGameMG
{
    internal class WorldGrid
    {
        private Tile[,,] grid;
        public float SquareSize { get; private set; }
        private int topLayer;
        private Random randomOreGenerator;
        private Vector2 position;
        private Vector2 globalPosition;
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int Depth { get; private set; }

        public WorldGrid()
        {
            this.Height = 25;
            this.Width = 25;
            this.Depth = 25;

            randomOreGenerator = new Random();

            grid = CreateNewWorldGrid(Height, Width, Depth);
            
            SquareSize = 64;
            topLayer = 5;
        }

        private Tile[,,] CreateNewWorldGrid(int width, int height, int depth)
        {
            Tile[,,] grid = new Tile[width, height, depth];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    for (int k = topLayer; k < depth; k++)
                    {
                        if (k == topLayer)
                            grid[i, j, k] = new GrassTile(new Vector3(i, j, k));
                        else
                            grid[i, j, k] = GenerateRandomUndergroundTile(i, j, k);
                    }
            return grid;
        }

        private Tile GenerateRandomUndergroundTile(int x, int y, int z)
        {
            int r = randomOreGenerator.Next(10);
            switch (r)
            {
                case < 1:
                    return new GoldTile(new Vector3(x, y, z));
                default:
                    return new StoneTile(new Vector3(x, y, z));
            }
        }


        public void PlaceTile(Vector3 gridLocation, Tile tile)
        {
            if (0 <= (int)gridLocation.X && (int)gridLocation.X < grid.GetLength(0) && 0 <= (int)gridLocation.Y && (int)gridLocation.Y < grid.GetLength(1) && 0 <= (int)gridLocation.Z && (int)gridLocation.Z < grid.GetLength(2))
                grid[(int)tile.GridPosition.X, (int)tile.GridPosition.Y, (int)tile.GridPosition.Z] = tile;
        }
        public void RemoveTile(Vector3 gridLocation)
        {
            PlaceTile(gridLocation, null);
        }
        public Tile ReturnTileAtIndex(Vector3 index)
        {
            if (0 <= (int)index.X && (int)index.X < grid.GetLength(0) && 0 <= (int)index.Y && (int)index.Y < grid.GetLength(1) && 0 <= (int)index.Z && (int)index.Z < grid.GetLength(2))
                return grid[(int)index.X, (int)index.Y, (int)index.Z];
            else
                return null;
        }

        public void Update(GameTime gameTime, Vector2 globalOffset)
        {
            globalPosition = position + globalOffset;
            foreach (Tile t in grid)
            {
                if (t is not null)
                    t.Update(gameTime, globalPosition);
            }
        }

        public void Draw(SpriteBatch spriteBatch, int drawStartLayer)
        {
            DrawTiles(spriteBatch, drawStartLayer, grid);
        }

        protected void DrawTiles(SpriteBatch spriteBatch, int startLayer, Tile[,,] worldGrid)
        {
            int iMax = worldGrid.GetLength(0);
            int jMax = worldGrid.GetLength(1);

            for (int i = 0; i < iMax; i++)
                for (int j = 0; j < jMax; j++)
                    DrawTileColumn(spriteBatch, i, j, startLayer, worldGrid);
        }
        private void DrawTileColumn(SpriteBatch spriteBatch, int x, int y, int startLayer, Tile[,,] worldGrid)
        {
            int kMax = worldGrid.GetLength(2);
            for (int k = startLayer; k < kMax; k++)
            {
                Tile tile = worldGrid[x, y, k];
                if (tile is null)
                    continue;
                if (tile.IsTransparent)
                {
                    DrawTileColumn(spriteBatch, x, y, k + 1, worldGrid);
                }

                tile.Draw(spriteBatch);
                break;
            }
        }
    }
}
