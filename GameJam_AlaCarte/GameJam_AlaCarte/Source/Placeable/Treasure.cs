using GameJam_AlaCarte.Source.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameJam_AlaCarte.Source.Placeable
{
    public class Treasure : Placeable
    {
        private Vector2 Position;

        public int Width {get;}
        public int Height { get;}

        private int current_state = 0;
        private TimeSpan Time_Between = new TimeSpan(0, 0, 0, 0, 500);
        private TimeSpan Timer = new TimeSpan(0,0,0);

        public Treasure()
        {
            Position = new Vector2(500, 500);
            Height = TextureFinder.SPRITESIZE;
            Width = TextureFinder.SPRITESIZE;
        }

        public Vector2 Get_Position()
        {
            return Position;
        }

        public void Move()
        {
            Random rand = new Random();
            Position.X = rand.Next(0, 400);
            Position.Y = rand.Next(0, 400);
        }

        public void Update(GameTime gameTime)
        {
            Timer += gameTime.ElapsedGameTime;
            if (Timer.TotalMilliseconds > Time_Between.TotalMilliseconds)
            {
                current_state = (current_state + 1)%2;
                Timer = new TimeSpan(0, 0, 0);
            }
        }

        override public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureFinder.TreasureTextures[current_state], Position, Color.White);
        }
    }
}
