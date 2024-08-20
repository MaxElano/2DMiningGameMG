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

namespace _2DMiningGameMG
{
    internal class Miner : Tile, IBuildable
    {
        public bool Visible { get; set; }
        public bool Usable { get; set; }
        private Timer miningTimer;
        private Tile[,,] worldGrid;
        public Miner(Tile[,,] worldGrid, int x, int y, int z, Texture2D texture) : base(x, y, z, texture, true)
        {
            this.tempColor = Color.Pink;
            this.worldGrid = worldGrid;
            this.miningTimer = new Timer(2, Mine);
            Visible = true;
            Usable = true;
        }

        public override void Update(GameTime gameTime, Vector2 globalOffset)
        {
            miningTimer.Update(gameTime);

            base.Update(gameTime, globalOffset);
        }

        public void Mine()
        {
            for (int i = (int)GridPosition.Z + 1; i < worldGrid.GetLength(2); i++)
            {
                if (worldGrid[(int)GridPosition.X, (int)GridPosition.Y, i] is null)
                    continue;
                else
                {
                    worldGrid[(int)GridPosition.X, (int)GridPosition.Y, i] = null;
                    break;  
                }
            }
        }
    }
}
