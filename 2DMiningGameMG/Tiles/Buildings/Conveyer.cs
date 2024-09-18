using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Reflection.Metadata;
using SharpDX.Direct3D9;
using System.Transactions;
using static _2DMiningGameMG.Tile;

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
        WorldGrid worldGrid;
        float rotation;

        public Conveyer(WorldGrid worldGrid, float conveyerSpeed, Vector3 gridLocation, Direction direction) : base(gridLocation)
        {
            (this.Texture, this.IsTransparent) = TextureDictionary.Textures[TextureDictionary.TextureName.conveyerTile];
            this.direction = Direction.Right;
            conveyerQueue = new Queue<Resource>();
            this.worldGrid = worldGrid;
            this.conveyerSpeed = conveyerSpeed;
            pushTimer = new Timer(conveyerSpeed / 60, PushItemFromQueue);
            Visible = true;
            Usable = true;
            this.CanReceive = true;
            this.direction = direction;

            Initialize();
        }

        public override void Update(GameTime gameTime, Vector2 globalOffset)
        {
            pushTimer.Update(gameTime);
            UpdateResourcePosition(gameTime);

            base.Update(gameTime, globalOffset);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, globalPosition + textureOffset, new Rectangle(0, 0, Texture.Width, Texture.Height), Color.White, SetRotation(direction), textureOffset, 1f, SpriteEffects.None, 1f);
        }

        public void UpdateResourcePosition(GameTime gameTime)
        {
            foreach (Resource r in conveyerQueue)
            {
                float movSpeed = (conveyerSpeed * (gameTime.ElapsedGameTime.Milliseconds / 1000f) * worldGrid.SquareSize) / 60;
                r.Move(movSpeed);
            }
        }

        public void PushItemFromQueue()
        {
            if (conveyerQueue.Count() == 0)
            {
                return;
            }

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

            Tile tile = worldGrid.ReturnTileAtIndex(GridPosition + difference);
            if (tile is IStoragable && (tile as IStoragable).CanReceive)
            {
                Resource res = conveyerQueue.Dequeue();
                World.RemoveResource(res);


                (tile as IStoragable).ReceiveResource(res);
                CanReceive = true;
            }
            
        }

        public void ReceiveResource(Resource resource)
        {
            if (conveyerQueue.Count() == 0)
                pushTimer.ResetTimer();
            resource.MoveTo = texturePosition;
            CanReceive = false;
            conveyerQueue.Enqueue(resource);
            World.AddResource(resource);
        }

        public void RemoveResources(World world)
        {
            foreach (Resource res in conveyerQueue)
                World.RemoveResource(res);
        }
    }
}
