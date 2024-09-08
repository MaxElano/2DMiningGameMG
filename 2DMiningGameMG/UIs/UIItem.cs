using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;


namespace _2DMiningGameMG
{
    internal class UIItem
    {
        // All buildables should be here
        // Add all buildables names here
        public enum BuildableName { Miner, Conveyer, SelectedRing }
        public BuildableName name;

        // Icon interactions
        public bool Usable { get; private set; }
        public bool Visible { get; private set; }

        // Object stuff
        public Vector2 centrePosition { get; private set; }
        public Texture2D Texture { get; private set; }
        public Rectangle rectangle { get; private set; }
        public Tile.Direction Direction { get; private set; }
        public float buildableScaling { get; private set; }

        public UIItem(BuildableName name) 
        { 
            Usable = true;
            Visible = true;
            this.name = name;
            this.buildableScaling = 0.9f;
            SetTexture();
        }

        // Drawing the icons in the hotbar
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, centrePosition, new Rectangle(0, 0, Texture.Width, Texture.Height), Color.White, 0f, new Vector2(Texture.Width, Texture.Height), buildableScaling, SpriteEffects.None, 1);
        }
        
        // Used to draw the buildable you have selected as "placing vision"
        public void DrawTemp(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Draw(Texture, location + new Vector2(Texture.Width / 2, Texture.Height / 2), new Rectangle(0, 0, Texture.Width, Texture.Height), Color.LightSkyBlue, Tile.SetRotation(Direction), new Vector2(Texture.Width / 2, Texture.Height / 2), 1f, SpriteEffects.None, 1);
        }

        // Sets the texture for the object
        // Add new builables (textures) here!!!!
        private void SetTexture()
        {
            switch (name)
            {
                case BuildableName.Miner:
                    (this.Texture, _) = TextureDictionary.Textures[TextureDictionary.TextureName.minerIcon];
                    break;
                case BuildableName.Conveyer:
                    (this.Texture, _) = TextureDictionary.Textures[TextureDictionary.TextureName.conveyerIcon];
                    break;
                case BuildableName.SelectedRing:
                    (this.Texture, _) = TextureDictionary.Textures[TextureDictionary.TextureName.selectedRingIcon];
                    break;
            }
        }

        // Determines the place in the hotbar the icon should be placed
        public void SetLocation(Vector2 screenSize, int buildablesCount, int index, float buildingBarBackgroundHeight, float distanceBetweenBuildables)
        {
            float xCoord = screenSize.X / 2 + (index - buildablesCount / 2) * (Texture.Width * buildableScaling + distanceBetweenBuildables);
            float yCoord = screenSize.Y - buildingBarBackgroundHeight / 2 + (Texture.Height / 2) * buildableScaling;
            centrePosition = new Vector2(xCoord, yCoord);
            rectangle = new Rectangle((int)(centrePosition.X - (Texture.Width * buildableScaling)), (int)(centrePosition.Y - (Texture.Height * buildableScaling)), (int)(Texture.Width * buildableScaling), (int)(Texture.Height * buildableScaling));
        }
        
        // If the automatic location can not be used (eg. for DrawTemp) use this to set it
        public void ManualSetLocation(Vector2 centrePosition, float buildableScalingOverride)
        {
            this.centrePosition = centrePosition;
            this.rectangle = new Rectangle((int)(centrePosition.X - (Texture.Width * buildableScalingOverride)), (int)(centrePosition.Y - (Texture.Height * buildableScalingOverride)), (int)(Texture.Width * buildableScalingOverride), (int)(Texture.Height * buildableScalingOverride));
        }

        // Rotate the "placing vision" object to the right direction (clockwise)
        public void Rotate()
        {
            var directionValues = Enum.GetValues<Tile.Direction>();
            for(int i = 0; i < directionValues.Length; i++)
            {
                if (Direction == (Tile.Direction)i)
                {
                    Direction = (Tile.Direction)((i + 1) % directionValues.Length);
                    break;
                }
            }
        }
    }
}
