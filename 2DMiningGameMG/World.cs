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

namespace _2DMiningGameMG
{
    internal class World
    {
        enum TextureName { grass, stone}

        private Dictionary<TextureName, Texture2D> textures;

        private Tile[,,] worldGrid;
        private Vector2 cameraOffset;
        public World(Tile[,,] grid = null) 
        {
            this.worldGrid = grid;

            textures = new Dictionary<TextureName, Texture2D>();
            cameraOffset = new Vector2(0, 0);
        }

        public void LoadContent(ContentManager content)
        {
            textures.Add(TextureName.grass, content.Load<Texture2D>("Sprites\\Tiles\\GrassTest"));
            textures.Add(TextureName.stone, content.Load<Texture2D>("Sprites\\Tiles\\StoneTest"));
        }

        private Tile[,,] CreateNewWorldGrid(int width, int height, int depth)
        {
            Tile[,,] grid = new Tile[width, height, depth];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    for (int k = 0; k < depth; k++)
                    {
                        if (k == 0)
                            grid[i, j, k] = new GrassTile(i, j, k, textures[TextureName.grass]);
                        else
                            grid[i, j, k] = new StoneTile(i, j, k, textures[TextureName.stone]);
                    }
            return grid;
        }

        public void Update(GameTime gameTime)
        {
            if (worldGrid is null)
                worldGrid = CreateNewWorldGrid(25, 25, 25);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawTiles(spriteBatch);
        }

        protected void DrawTiles(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < worldGrid.GetLength(0); i++)
                for (int j = 0; j < worldGrid.GetLength(1); j++)
                    for (int k = 0; k < worldGrid.GetLength(2); k++)
                    {
                        if (worldGrid[i, j, k] is null)
                            continue;
                        else
                        {
                            worldGrid[i, j, k].Draw(spriteBatch, cameraOffset);
                            break;
                        }
                        
                    }
        }
    }
}
