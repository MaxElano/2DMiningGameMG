using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SharpDX.Direct3D9;

namespace _2DMiningGameMG
{
    internal class Tile
    {
        protected enum Direction { Up, Down, Left, Right }

        public Vector3 GridPosition { get; private set; }
        public bool IsTransparent { get; protected set; }

        public Texture2D Texture { get; protected set; }

        protected Vector2 textureOffset;
        protected Vector2 texturePosition;
        protected Vector2 globalPosition;

        public Tile(Vector3 gridLocation)
        {
            this.GridPosition = gridLocation;
        }

        public virtual void Initialize()
        {
            this.textureOffset = new Vector2(Texture.Width / 2, Texture.Height / 2);
            this.texturePosition = new Vector2(GridPosition.X * (Texture.Width), GridPosition.Y * (Texture.Height));
        }

        public virtual Resource GetResource()
        {
            return new GrassResource(texturePosition);
        }

        public void SetGridLocation(Vector3 gridLocation)
        {
            this.GridPosition = gridLocation;
        }

        public virtual void Update(GameTime gameTime, Vector2 globalOffset)
        {
            globalPosition = globalOffset + texturePosition ;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, globalPosition, Color.White);
        }

    }
}
