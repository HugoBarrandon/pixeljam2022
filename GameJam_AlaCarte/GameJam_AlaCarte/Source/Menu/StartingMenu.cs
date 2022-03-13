using GameJam_AlaCarte.Source.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameJam_AlaCarte.Source.Menu
{
    public class StartingMenu
    {
        private bool start = false;

        public void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                start = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureFinder.MenuTexture["StartingMenu"], new Rectangle(0,0,1600,900), Color.White);
        }

        public bool is_starting()
        {
            return start;
        }

        public void Reset()
        {
            start = false;
        }
    }
}
