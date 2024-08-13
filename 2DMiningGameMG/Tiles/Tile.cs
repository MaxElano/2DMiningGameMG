using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace _2DMiningGameMG
{
    internal class Tile
    {
        private Vector2 gridPosition;
        private int depth;

        private Texture2D texture;
        private Vector2 textureOffset;
        private Vector2 texturePosition;

        public Tile(int x, int y, int depth, Texture2D texture)
        {
            this.gridPosition = new Vector2(x, y);
            this.depth = depth;
            this.texture = texture;
            this.textureOffset = new Vector2(texture.Width / 2, texture.Height / 2);
            this.texturePosition = new Vector2(x * (texture.Width), y * (texture.Height));
        }

        public virtual void Initialize()
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 globalOffset, Vector2 gridOffset)
        {
            spriteBatch.Draw(texture, globalOffset + texturePosition - textureOffset - new Vector2(gridOffset.X * (texture.Width), gridOffset.Y * (texture.Height)), Color.White);
        }
    }
}
