using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMiningGameMG.UIs.Playstate
{
    internal class BuildingUI : UI
    {
        private Texture2D buildingBarBackground;
        public BuildingUI(Vector2 screenSize) : base(screenSize)
        {

        }

        public override void LoadContent(ContentManager content)
        {
            buildingBarBackground = content.Load<Texture2D>("Sprites\\UIs\\BuildingUI\\BuildingBarBackground");
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            buildingBarBackground
        }
    }
}
