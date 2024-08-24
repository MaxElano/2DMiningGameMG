using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMiningGameMG
{
    internal class GrassResource : Resource
    {
        public GrassResource(int x, int y) : base(x, y)
        {
            (this.Texture, this.IsTransparent) = TextureDictionary.Textures[TextureDictionary.TextureName.grassResource];
            Initialize();
        }
    }
}
