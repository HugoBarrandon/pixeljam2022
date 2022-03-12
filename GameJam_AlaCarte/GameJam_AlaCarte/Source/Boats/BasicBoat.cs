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
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureFinder.BoatTexture, new Rectangle((int)position.X, (int)position.Y, 16, 16), Color.White);
        }

    }
}
