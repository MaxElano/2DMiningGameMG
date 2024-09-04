using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace _2DMiningGameMG
{
    internal class Resource
    {
        public bool IsTransparent { get; protected set; }
        public Texture2D Texture { get; protected set; }
        private Vector2 textureOffset;
        private Vector2 position;
        private Vector2 globalPosition;
        private Tile container;
        private float resourceScaling;
        public Resource(Vector2 position)
        {
            this.position = position;
            this.resourceScaling = 0.5f;
        }

        public virtual void Initialize()
        {
            this.textureOffset = new Vector2(Texture.Width / 2, Texture.Height / 2);
        }

        public virtual void Update(GameTime gameTime, Vector2 globalOffset)
        {
            globalPosition = globalOffset + position;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, globalPosition, new Rectangle(0, 0, Texture.Width, Texture.Height), Color.White, 0f, new Vector2(Texture.Width, Texture.Height), resourceScaling, SpriteEffects.None, 1);
        }

        public void Move(Vector2 movement)
        {
            position += movement;
        }
    }
}
