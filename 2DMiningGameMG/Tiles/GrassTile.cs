using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Drawing;
using System.Reflection.Metadata;
using SharpDX.Direct3D9;

namespace _2DMiningGameMG
{
    internal class GrassTile : Tile
    {
        public GrassTile(int x, int y, int z) : base(x, y, z, Game1.Content2.Load<Texture2D>("Sprites\\Tiles\\GrassTest.png")) 
        {
        }
    }
}
