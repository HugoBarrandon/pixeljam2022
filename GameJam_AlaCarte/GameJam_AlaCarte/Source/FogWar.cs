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
        private Vector2 position = new Vector2();

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureFinder.FogTexture, new Rectangle((int)position.X, (int)position.Y, 1600, 900), Color.White);
        }

        public void Update_Position(Vector2 player_position)
        {
            position = player_position;
            position.X -= 800;
            position.Y -= 450;
        }
    }
}
