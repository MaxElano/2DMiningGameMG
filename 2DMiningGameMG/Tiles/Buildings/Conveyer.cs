using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Reflection.Metadata;
using SharpDX.Direct3D9;

namespace _2DMiningGameMG.Tiles.Buildings
{
    internal class Conveyer : Tile
    {

        float conveyerSpeed; //Items per minute
        Queue<Resource> conveyerQueue;
        Direction direction;
        Timer pushTimer;
        World world;

        public Conveyer(World world, float conveyerSpeed, int x, int y, int z, Texture2D texture) : base(x, y, z, texture, false)
        {
            this.tempColor = Color.Green;
            this.world = world;
            this.conveyerSpeed = conveyerSpeed;
            pushTimer = new Timer(conveyerSpeed / 60, PushItemFromQueue);
        }

        public override void Update(GameTime gameTime, Vector2 globalOffset)
        {
            pushTimer.Update(gameTime);

            base.Update(gameTime, globalOffset);
        }

        public void InsertResourceToQueue(Resource resource)
        {
            conveyerQueue.Enqueue(resource);
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

            Tile tile = world.ReturnTileAtIndex(GridPosition + difference);
            if (tile is IStoragable && (tile as IStoragable).CanReceive)
            {
                (tile as IStoragable).ReceiveResource(res);
            }
        }
    }
}
