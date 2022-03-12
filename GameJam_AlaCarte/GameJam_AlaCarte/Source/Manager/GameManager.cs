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
        private TimeSpan Timer;
        private String Timer_String;

        private Boat boat;

        public GameManager()
        {
            TimerStart = new TimeSpan(0, 0, 30);
            boat = new BasicBoat();
        }

        public void AddTime(int time)
        {
        }

        public void Update(GameTime gameTime)
        {
            Timer = TimerStart - gameTime.TotalGameTime;
            if (Timer.TotalSeconds > 0)
            {
                Timer_String = Timer.Minutes + ":" + Timer.Seconds + ":" + Timer.Milliseconds;
            }
            else
            {
                Timer_String = "Perdu";
            }

            boat.Update(gameTime);

        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            
            _spriteBatch.DrawString(TextureFinder.BasicFont, Timer_String, new Vector2(10, 10), Color.Black);
            boat.Draw(_spriteBatch);
        }
    }
}
