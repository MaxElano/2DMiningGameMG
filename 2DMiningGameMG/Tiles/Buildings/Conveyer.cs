using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Reflection.Metadata;
using SharpDX.Direct3D9;

namespace _2DMiningGameMG
{
    internal class Conveyer : Tile, IBuildable, IStoragable
    {
        public bool CanReceive { get; set; }
        public bool Visible { get; set; } 
        public bool Usable { get; set; }
        public Texture2D UIIcon { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        float conveyerSpeed; //Items per minute
        Queue<Resource> conveyerQueue;
        Direction direction;
        Timer pushTimer;
        World world;
        float rotation;

        public Conveyer(World world, float conveyerSpeed, int x, int y, int z, Texture2D texture) : base(x, y, z)
        {
            this.world = world;
            this.conveyerSpeed = conveyerSpeed;
            pushTimer = new Timer(conveyerSpeed / 60, PushItemFromQueue);
            Visible = true;
            Usable = true;
        }

        public override void Update(GameTime gameTime, Vector2 globalOffset)
        {
            pushTimer.Update(gameTime);

            base.Update(gameTime, globalOffset);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, globalPosition, new Rectangle(0, 0, Texture.Width, Texture.Height), Color.White, SetRotation(direction), globalPosition + textureOffset, 1f, SpriteEffects.None, 1f);
        }

        public void PushItemFromQueue()
        {
            if (conveyerQueue.Count() == 0)
            {
                return;
            }

            Resource res = conveyerQueue.Dequeue();
 
            Vector3 difference;
            switch (direction) 
            {
                case Direction.Up:
                    difference = new Vector3(0, -1, 0);
                    break;
                case Direction.Down:
                    difference = new Vector3(0, 1, 0);
                    break;
                case Direction.Left:
                    difference = new Vector3(-1, 0, 0);
                    break;
                case Direction.Right:
                    difference = new Vector3(1, 0, 0);
                    break;
                default:
                    difference = new Vector3(0, 0, 0);
                    break;
            }

            Tile tile = world.WorldGrid.ReturnTileAtIndex(GridPosition + difference);
            if (tile is IStoragable && (tile as IStoragable).CanReceive)
            {
                (tile as IStoragable).ReceiveResource(res);
            }
        }

        public void ReceiveResource(Resource resource)
        {
            conveyerQueue.Enqueue(resource);
        }

        private float SetRotation(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return 270;
                case Direction.Down:
                    return 90;
                case Direction.Right:
                    return 0;    
                case Direction.Left:
                    return 180;
                default:
                    return 0;
            }
        }
    }
}
