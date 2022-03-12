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

        public void Update(GameTime gameTime, Vector2 screenCenter)
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

            boat.Update(gameTime,screenCenter);
            //fog.Update(gameTime);

            //fog.Update_Position(boat.get_position());

        }

        public void Draw(SpriteBatch _spriteBatch,Matrix transform)
        {
            _spriteBatch.Begin();
            _spriteBatch.DrawString(TextureFinder.BasicFont, Timer_String, new Vector2(10, 10), Color.Black);
            _spriteBatch.DrawString(TextureFinder.BasicFont, boat.get_position().X +" "+ boat.get_position().Y, new Vector2(10, 200), Color.Black);
            _spriteBatch.End();

            _spriteBatch.Begin( samplerState: SamplerState.PointClamp);
            boat.Draw(_spriteBatch);
            _spriteBatch.End();
            //fog.Draw(_spriteBatch); 
        }

        public Vector2 GetBoatPosition()
        {
            return boat.get_position();
        }
    }
}
