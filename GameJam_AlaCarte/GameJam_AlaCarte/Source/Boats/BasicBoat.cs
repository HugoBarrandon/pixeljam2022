using GameJam_AlaCarte.Source.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameJam_AlaCarte.Source.Boats
{
    class BasicBoat : Boat
    {
        private Vector2 PosOnScreen;
        public override void Update(GameTime gameTime, Vector2 screenCenter)
        {
            PosOnScreen = screenCenter;
            base.Update(gameTime,screenCenter);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureFinder.BoatTexture, new Rectangle((int)PosOnScreen.X, (int)PosOnScreen.Y, 32,32) , Color.White) ;
        }

    }
}
