using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Windows.Forms.VisualStyles;
using System.CodeDom;

namespace _2DMiningGameMG
{
    internal class Chest : Tile, IStoragable
    {
        public bool CanReceive { get; set; }
        int chestSize;
        int rowSize;
        List<Resource>[,] storage;
        int maxStackSize;

        public Chest(Vector3 gridLocation, int chestSize = 24, int rowSize = 8, int maxStackSize = 64) : base(gridLocation)
        {
            this.chestSize = chestSize;
            this.rowSize = rowSize;
            storage = new List<Resource>[rowSize, chestSize / rowSize];
            this.maxStackSize = maxStackSize;
            for (int i = 0; i < storage.GetLength(0); i++)
                for (int j = 0; j < storage.GetLength(1); j++)
                {
                    storage[i,j] = new List<Resource>(maxStackSize);
                }
        }
        public bool canReceiveResource(Resource resource)
        {
            if (!CanReceive || resource is null)
                return false;

            for (int j = 0; j < storage.GetLength(1); j++)
                for (int i = 0; i < storage.GetLength(0); i++)
                {
                    if (storage[i, j].Count() < maxStackSize && storage[i, j] is )
                    {
                        return true;
                    }
                }
            return false;
        }
        public void ReceiveResource(Resource resource)
        {
            if (!CanReceive || resource is null)
                return;

            for (int j = 0; j < storage.GetLength(1); j++)
                for (int i = 0; i < storage.GetLength(0); i++)
                {

                    if (storage[i, j].Count() < maxStackSize && storage[i, j][0].GetType() == resource.GetType() || storage[i, j].Count() == 0)
                    {

                        storage[i, j].Add(resource);
                    }
                }
        }

        public void RemoveResources()
        {
            throw new NotImplementedException();
        }

        public void UpdateResourcePosition(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
