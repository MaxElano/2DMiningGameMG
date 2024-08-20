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
    internal interface IBuildable
    {
        bool Visible { get; set; }
        bool Usable { get; set; }
    }
}
