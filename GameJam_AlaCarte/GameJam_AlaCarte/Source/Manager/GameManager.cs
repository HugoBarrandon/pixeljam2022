using GameJam_AlaCarte.Source.Boats;
using GameJam_AlaCarte.Source.Data;
using GameJam_AlaCarte.Source.Placeable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameJam_AlaCarte.Source.Manager
{
    public class GameManager
    {
        private TimeSpan TimerStart;
        private TimeSpan TotalTime;
        private TimeSpan Timer;
        private String Timer_String;

        private Treasure Treasure;

        private Boat boat;
        private FogWar fog;

        public GameManager()
        {
            TotalTime = new TimeSpan(0, 2, 30);
            boat = new BasicBoat();
            fog = new FogWar();

            Treasure = new Treasure();

            Timer_String = "";
        }

        public void init_time(GameTime gameTime)
        {
            TimerStart = gameTime.TotalGameTime;
        }   

        public void AddTime(int time)
        {
        }

        public void Update(GameTime gameTime)
        {
            Timer = TotalTime - (gameTime.TotalGameTime - TimerStart);
            if (Timer.TotalSeconds > 0)
            {
                Timer_String = Timer.Minutes + ":" + Timer.Seconds + ":" + Timer.Milliseconds;
            }
            else
            {
                Timer_String = "Perdu";
            }

            boat.Update(gameTime);
            Treasure.Update(gameTime);
            //fog.Update(gameTime);

            //fog.Update_Position(boat.get_position());

            collision_Treasure(boat, Treasure);

        }

        public void Draw(SpriteBatch _spriteBatch)
        {
       
            _spriteBatch.DrawString(TextureFinder.BasicFont, Timer_String, new Vector2(10, 10), Color.Black);
            boat.Draw(_spriteBatch);
            Treasure.Draw(_spriteBatch);
            //fog.Draw(_spriteBatch);
        }

        public void collision_Treasure(Boat b, Treasure t)
        {
            Vector2 rect1 = b.Get_Position();
            Vector2 rect2 = t.Get_Position();
            if (rect1.X < rect2.X + t.Width &&
                   rect1.X + b.Width > rect2.X &&
                   rect1.Y < rect2.Y + t.Height &&
                   b.Height + rect1.Y > rect2.Y)
            {
                t.Move();
            }
        }
    }
}
