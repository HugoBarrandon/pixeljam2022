using GameJam_AlaCarte.Source.Boats;
using GameJam_AlaCarte.Source.Data;
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

        private Boat boat;
        private FogWar fog;

        public GameManager()
        {
            TotalTime = new TimeSpan(0, 2, 30);
            boat = new BasicBoat();
            fog = new FogWar();
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
            //fog.Update(gameTime);

            //fog.Update_Position(boat.get_position());

        }

        public void Draw(SpriteBatch _spriteBatch)
        {
       
            _spriteBatch.DrawString(TextureFinder.BasicFont, Timer_String, new Vector2(10, 10), Color.Black);
            boat.Draw(_spriteBatch);
            //fog.Draw(_spriteBatch);
        }
    }
}
