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

namespace _2DMiningGameMG
{
    internal interface IStoragable
    {
        public bool CanReceive { protected set; get; }
        public abstract void ReceiveResource(Resource resource);
    }
}
