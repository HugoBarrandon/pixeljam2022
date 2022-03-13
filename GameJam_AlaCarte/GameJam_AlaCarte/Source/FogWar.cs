using GameJam_AlaCarte.Source.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;


namespace GameJam_AlaCarte.Source
{
    public class FogWar
    {

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 screenCenter)
        {
            spriteBatch.Begin();
          
            spriteBatch.End();
           // spriteBatch.Draw(TextureFinder.FogTexture, new Rectangle((int)position.X, (int)position.Y, 1600, 900), Color.White);
        }


      
    }
}
