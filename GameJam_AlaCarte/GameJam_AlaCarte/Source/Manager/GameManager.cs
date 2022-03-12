using Microsoft.Xna.Framework;
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

        public GameManager()
        {
            TimerStart = new TimeSpan(0, 0, 30);
        }

        public void AddTime(int time)
        {
        }

        public void Update(GameTime gameTime)
        {
            Timer = TimerStart - gameTime.TotalGameTime;
            if (Timer.TotalSeconds > 0)
            {
                Debug.WriteLine(Timer);
            }
            else
            {
                Debug.WriteLine("Perdu");
            }
        }
    }
}
