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

namespace _2DMiningGameMG
{
    internal class GoldTile : Tile
    {
        public GoldTile(Vector3 gridLocation) : base(gridLocation)
        {
            (this.Texture, this.IsTransparent) = TextureDictionary.Textures[TextureDictionary.TextureName.goldTile];
            Initialize();
        }
    }
}
