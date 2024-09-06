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
        public Vector2 MoveTo { get; set; }
        private float resourceScaling;
        public Resource(Vector2 position)
        {
            this.position = position;
            this.resourceScaling = 0.5f;
        }

        public virtual void Initialize()
        {
            this.textureOffset = new Vector2(Texture.Width / 2, Texture.Height / 2) * resourceScaling;
        }

        public virtual void Update(GameTime gameTime, Vector2 globalOffset)
        {
            globalPosition = globalOffset + position + textureOffset;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, globalPosition, new Rectangle(0, 0, Texture.Width, Texture.Height), Color.White, 0f, Vector2.Zero, resourceScaling, SpriteEffects.None, 1);
        }

        public void Move(float speed)
        {
            position += Vector2.Normalize(MoveTo - position) * speed;
        }
    }
}
