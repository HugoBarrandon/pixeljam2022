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

        public int Width { get; private set; }
        public int Height { get; private set; }

        protected double speed = 0.2;

        protected int rotation;
        protected int lastrotation;
        public Boat()
        {
            Position = Vector2.Zero;
            Width = 16;
            Height = 16;
            rotation = 0;
        }

        public Vector2 Get_Position()
        {
            return Position;
        }

        public virtual void Update(GameTime gameTime, Vector2 screenCenter)
        {
            lastrotation = rotation;
            rotation = 0;
            if(Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Position.Y -= (float)(speed * gameTime.ElapsedGameTime.TotalMilliseconds);
                rotation += 11;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                Position.Y += (float)(speed * gameTime.ElapsedGameTime.TotalMilliseconds);
                rotation += 2;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                Position.X += (float)(speed * gameTime.ElapsedGameTime.TotalMilliseconds);
                rotation += 7;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Position.X -= (float)(speed * gameTime.ElapsedGameTime.TotalMilliseconds);
                rotation += 17;
            }
            if (rotation == 0)
                rotation = lastrotation;
        }
        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            throw new Exception("Draw from abstract class Boat");
        }
    }
}
