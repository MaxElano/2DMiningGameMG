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
    internal class StoneTile : Tile
    {
        public StoneTile(int x, int y, int z) : base(x, y, z)
        {
            (this.Texture, this.IsTransparent) = TextureDictionary.Textures[TextureDictionary.TextureName.stoneTile];
            Initialize();
        }
    }
}
