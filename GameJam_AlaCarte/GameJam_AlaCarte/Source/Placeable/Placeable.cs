using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameJam_AlaCarte.Source.Placeable
{
    public abstract class Placeable
    {
        private Vector2 position = new Vector2();

        public virtual void Draw(SpriteBatch spritebatch)
        {

        }
    }
}
