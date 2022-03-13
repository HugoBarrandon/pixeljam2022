using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GameJam_AlaCarte.Source.Data;


namespace GameJam_AlaCarte.Source.Boats
{
    public abstract class Boat
    {
        protected Vector2 Position;
        protected Vector2 Velocity;

        protected Vector2 FuturPosition;
        protected Vector2 PreviousPosition;

        public int Width { get; private set; }
        public int Height { get; private set; }

        protected double speed = 0.2;

        protected int rotation;
        protected int lastrotation;

        protected BoatType bateauSplash;

        
        public Boat()
        {
            Position = Vector2.Zero;
            FuturPosition = Vector2.Zero;
            PreviousPosition = Vector2.Zero;
            Velocity = Vector2.Zero;
            Width = 16;
            Height = 16;
            rotation = 0;
            bateauSplash = 0;
        }

        public Vector2 Get_Position()
        {
            return Position;
        }

        public void ResetSpeed()
        {
            speed = 0.2;
        }

        public void IncreaseSpeed()
        {
            speed += 0.05;
        }

        public void AddBonus()
        {
            if(bateauSplash<BoatType.Boat5)
                bateauSplash++;
        }

        public void ResetBonus()
        {
            bateauSplash = 0;
        }

        public virtual void Update(GameTime gameTime, Vector2 screenCenter)
        {
            lastrotation = rotation;
            rotation = 0;
            Velocity = Vector2.Zero;
            FuturPosition = Position;
            if(Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Velocity.Y -= 1;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                Velocity.Y += 1;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                Velocity.X += 1;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Velocity.X -= 1;
            }
            if(Velocity.Length() > 0)
            {
                Velocity.Normalize();
                Velocity.X = Velocity.X * (float)(speed * gameTime.ElapsedGameTime.TotalMilliseconds);
                Velocity.Y = Velocity.Y * (float)(speed * gameTime.ElapsedGameTime.TotalMilliseconds);

                FuturPosition += Velocity;

                if(Velocity.X > 0) rotation += 7;
                if(Velocity.X < 0) rotation += 17;
                if(Velocity.Y > 0) rotation += 2;
                if(Velocity.Y < 0) rotation += 11;
            }

            if (rotation == 0 || !(rotation == 2 || rotation == 7 || rotation == 11 || rotation == 17 || rotation == 7 || rotation == 9 || rotation == 19 || rotation == 28 || rotation == 18))
                rotation = lastrotation;
        }

        public void Move()
        {
            PreviousPosition = Position;
            Position = FuturPosition;
        }

        public void MoveBack()
        {
            Position = PreviousPosition;
        }

        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            throw new Exception("Draw from abstract class Boat");
        }
    }
}
