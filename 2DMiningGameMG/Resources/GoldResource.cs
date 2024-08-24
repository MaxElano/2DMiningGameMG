using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace _2DMiningGameMG
{
    internal class GoldResource : Resource
    {
        public GoldResource(int x, int y) : base(x, y)
        {
            (this.Texture, this.IsTransparent) = TextureDictionary.Textures[TextureDictionary.TextureName.goldResource];
            Initialize();
        }
    }
}
