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
        public StoneTile(Vector3 gridLocation) : base(gridLocation)
        {
            (this.Texture, this.IsTransparent) = TextureDictionary.Textures[TextureDictionary.TextureName.stoneTile];
            Initialize();
        }

        public override Resource GetResource()
        {
            return new StoneResource(texturePosition);
        }
    }
}
