using GameJam_AlaCarte.Source.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameJam_AlaCarte.Source.Menu
{
    public class FinishMenu
    {

        public bool next { get; private set; }
        public int NbPoint = 0;
        public TimeSpan TimeSpend = new TimeSpan();

        public FinishMenu()
        {
            next = false;
        }

        public void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                next = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(TextureFinder.MenuTexture["FinishMenu"], new Rectangle(0, 0, 1600, 900), Color.White);
            spriteBatch.DrawString(TextureFinder.BasicFont, "Points : " + NbPoint, new Vector2(700, 400), Color.White);
            spriteBatch.DrawString(TextureFinder.BasicFont, "Temps :" + TimeSpend, new Vector2(550, 500), Color.White);
            spriteBatch.End();
        }
    }
}
