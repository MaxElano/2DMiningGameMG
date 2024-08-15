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
        enum TextureName { grass, stone, white, miner}
        
        private Dictionary<TextureName, Texture2D> textures;

        private Tile[,,] worldGrid;
        
        public Vector2 CameraOffset { get; set; }
        private Vector2 originalHalfGridSize;
        private Vector2 position;
        
        private float squareSize = 64;
        public bool mouseClicked = false;
        private Random randomOreGenerator;
        private int drawStartLayer;
        private int topLayer;

        public World(GraphicsDeviceManager graphics, Tile[,,] grid = null) 
        {
            this.worldGrid = grid;
            this.randomOreGenerator = new Random();
            this.drawStartLayer = 0;
            this.topLayer = 5;

            textures = new Dictionary<TextureName, Texture2D>();
            CameraOffset = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
        }

        public void LoadContent(ContentManager content)
        {
            textures.Add(TextureName.grass, content.Load<Texture2D>("Sprites\\Tiles\\GrassTest"));
            textures.Add(TextureName.stone, content.Load<Texture2D>("Sprites\\Tiles\\StoneTest"));
            textures.Add(TextureName.white, content.Load<Texture2D>("Sprites\\Tiles\\WhiteTile"));
            textures.Add(TextureName.miner, content.Load<Texture2D>("Sprites\\Tiles\\MinerTile"));
        }

        private Tile[,,] CreateNewWorldGrid(int width, int height, int depth)
        {
            Tile[,,] grid = new Tile[width, height, depth];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    for (int k = topLayer; k < depth; k++)
                    {
                        if (k == topLayer)
                        {
                            grid[i, j, k] = new GrassTile(i, j, k, textures[TextureName.white]);
                        }
                        else if (randomOreGenerator.Next(10) < 1)
                        {
                            grid[i, j, k] = new GoldTile(i, j, k, textures[TextureName.white]);
                        }
                        else
                        {
                            grid[i, j, k] = new StoneTile(i, j, k, textures[TextureName.white]);
                        }
                    }
            originalHalfGridSize = new Vector2(width / 2, height / 2);
            return grid;
        }

        public void Update(GameTime gameTime)
        {
            if (worldGrid is null)
                worldGrid = CreateNewWorldGrid(25, 25, 25);

            position = CameraOffset - originalHalfGridSize * squareSize;

            foreach (Tile t in worldGrid)
            {
                if (t is not null)
                    t.Update(gameTime, position);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawTiles(spriteBatch, drawStartLayer, worldGrid);
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
        public void HandleMouseClick(MouseState mouseState)
        {
            Vector2 pos = mouseState.Position.ToVector2();
            Vector2 gpos = (pos - CameraOffset + originalHalfGridSize * squareSize + new Vector2(squareSize / 2, squareSize / 2)) / squareSize;
            gpos = new Vector2((float)Math.Floor(gpos.X), (float)Math.Floor(gpos.Y));

            if (0 <= (int)gpos.X && (int)gpos.X < worldGrid.GetLength(0) && 0 <= (int)gpos.Y && (int)gpos.Y < worldGrid.GetLength(1))
                PlaceBuilding(gpos, new Miner(worldGrid, (int)gpos.X, (int)gpos.Y, topLayer - 1, textures[TextureName.miner]));
        }

        public void PlaceBuilding(Vector2 gridLocation, Tile building)
        {
            worldGrid[(int)building.GridPosition.X, (int)building.GridPosition.Y, (int)building.GridPosition.Z] = building;
        }
    }
}
