using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameJam_AlaCarte.Source.Boats
{
    public abstract class Boat
    {
        protected Vector2 Position;

        public int Width { get; }
        public int Height { get; }

        protected int speed = 1;

        public Boat()
        {
            Position = new Vector2(100, 100);
            Width = 16;
            Height = 16;
        }

        public Vector2 Get_Position()
        {
            return Position;
        }

        public virtual void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Position.Y += speed;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                Position.Y -= speed;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                Position.X -= speed;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Position.X += speed;
            }
        }
        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            throw new Exception("Draw from abstract class Boat");
        }
    }
}
