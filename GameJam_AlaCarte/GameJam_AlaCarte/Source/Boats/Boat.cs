using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameJam_AlaCarte.Source.Boats
{
    abstract class Boat
    {
        protected Vector2 position;
        protected int speed = 2;

        public Vector2 get_position()
        {
            return position;
        }

        public Boat()
        {
            position = new Vector2(100, 100);
        }

        public virtual void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.S))
            {
                position.Y += speed;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                position.Y -= speed;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                position.X -= speed;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.D))
            {
                position.X += speed;
            }
        }
        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            throw new Exception("Draw from abstract class Boat");
        }
    }
}
