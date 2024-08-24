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
using Microsoft.Xna.Framework.Content;

namespace _2DMiningGameMG
{
    internal static class TextureDictionary
    {
        public enum TextureName {
        /*Icons*/      minerIcon
        /*Resources*/, grassResource, stoneResource, goldResource
        /*Tiles*/    , grassTile, stoneTile, goldTile, minerTile, conveyerTile
        /*UIs*/      , buildingBarBackground
        }
        public static Dictionary<TextureName, (Texture2D, bool)> Textures { get; private set; }
        private static bool Generated { get; set; }
        public static void GenerateTextures(ContentManager content)
        {
            if (!Generated)
            {
                GenerateTiles(content);
                GenerateResources(content);
                GenerateUIItems(content);
                GenerateBuildables(content);

                Generated = true;
            }
            else
            {
                Debug.WriteLine("Already Generated Textures");
            }
        }

        private static void GenerateTiles(ContentManager content)
        {
            //grassTile
            Texture2D texture = content.Load<Texture2D>("Sprites\\Tiles\\GrassTile");
            Textures.Add(TextureName.grassTile, (texture, IsTextureTransparent(texture)));

            //stoneTile
            texture = content.Load<Texture2D>("Sprites\\Tiles\\StoneTile");
            Textures.Add(TextureName.stoneTile, (texture, IsTextureTransparent(texture)));

            //goldTile
            texture = content.Load<Texture2D>("Sprites\\Tiles\\GoldTile");
            Textures.Add(TextureName.goldTile, (texture, IsTextureTransparent(texture)));

            //minerTile
            texture = content.Load<Texture2D>("Sprites\\Tiles\\MinerTile");
            Textures.Add(TextureName.minerTile, (texture, IsTextureTransparent(texture)));

            //conveyerTile
            texture = content.Load<Texture2D>("Sprites\\Tiles\\ConeyerTile");
            Textures.Add(TextureName.conveyerTile, (texture, IsTextureTransparent(texture)));
        }

        private static void GenerateResources(ContentManager content)
        {

            //grassResource
            Texture2D texture = content.Load<Texture2D>("Sprites\\Tiles\\GrassResource");
            Textures.Add(TextureName.grassResource, (texture, IsTextureTransparent(texture)));

            //stoneResource
            texture = content.Load<Texture2D>("Sprites\\Tiles\\StoneResource");
            Textures.Add(TextureName.stoneResource, (texture, IsTextureTransparent(texture)));

            //goldResource
            texture = content.Load<Texture2D>("Sprites\\Tiles\\GoldResource");
            Textures.Add(TextureName.goldResource, (texture, IsTextureTransparent(texture)));
        }

        private static void GenerateUIItems(ContentManager content)
        {
            //buildingBarBackground
            Texture2D texture = content.Load<Texture2D>("Sprites\\UIs\\Playstate\\BuildingBarBackground");
            Textures.Add(TextureName.buildingBarBackground, (texture, IsTextureTransparent(texture)));
        }

        private static void GenerateBuildables(ContentManager content)
        {
            //minerIcon
            Texture2D texture = content.Load<Texture2D>("Sprites\\UIs\\Playstate\\MinerIcon");
            Textures.Add(TextureName.buildingBarBackground, (texture, IsTextureTransparent(texture)));
        }
        private static bool IsTextureTransparent(Texture2D texture)
        {
            Rectangle r = texture.Bounds;
            int size = r.Width * r.Height;
            Color[] buffer = new Color[size];
            texture.GetData(0, r, buffer, 0, size);
            return buffer.All(c => c == Color.Transparent);
        }
    }
}
