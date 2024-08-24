using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Reflection.Metadata;
using SharpDX.Direct3D9;
using SharpDX.DirectWrite;
using System.Diagnostics;
using _2DMiningGameMG.Tiles.Buildings;
using System.Security.Cryptography.Xml;

namespace _2DMiningGameMG
{
    internal class Miner : Tile, IBuildable
    {
        public bool Visible { get; set; }
        public bool Usable { get; set; }
        private Timer miningTimer;
        private WorldGrid worldGrid;
        private Vector3 outputTileGridLoc;

        public Miner(WorldGrid worldGrid, int x, int y, int z, Texture2D texture) : base(x, y, z)
        {
            this.worldGrid = worldGrid;
            this.miningTimer = new Timer(2, Mine);
            Visible = true;
            Usable = true;
            outputTileGridLoc = GridPosition - new Vector3(-1, 0, 0);
        }

        public override void Update(GameTime gameTime, Vector2 globalOffset)
        {
            miningTimer.Update(gameTime);

            base.Update(gameTime, globalOffset);
        }

        public void Mine()
        {
            Tile outputTile = worldGrid.ReturnTileAtIndex(outputTileGridLoc);
            if (outputTile is IStoragable)
            {
                for (int i = (int)GridPosition.Z + 1; i < worldGrid.Depth; i++)
                {
                    Tile tile = worldGrid.ReturnTileAtIndex(new Vector3(GridPosition.X, GridPosition.Y, i));
                    if (tile is null)
                        continue;
                    else
                    {
                        (outputTile as IStoragable).ReceiveResource(tile.GetResource());
                        worldGrid.RemoveTile(new Vector3(GridPosition.X, GridPosition.Y, i));
                        break;
                    }
                }
            }
        }
    }
}
