using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMiningGameMG
{
    internal class StoneResource : Resource
    {
        public StoneResource(int x, int y) : base(x, y)
        {
            (this.Texture, this.IsTransparent) = TextureDictionary.Textures[TextureDictionary.TextureName.stoneResource];
            Initialize();
        }
    }
}
