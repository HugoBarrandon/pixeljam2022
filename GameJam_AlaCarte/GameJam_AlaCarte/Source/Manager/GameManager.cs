using GameJam_AlaCarte.Source.Boats;
using GameJam_AlaCarte.Source.Data;
using GameJam_AlaCarte.Source.Menu;
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
        private TimeSpan TimeTotalPause;
        private Stopwatch TimePause;

        private String Timer_String;

        public bool finish { get; private set; }

        private Treasure Treasure;

        private Boat boat;
        private FogWar fog;

        private CollisionManager collisionManager;

        private BonusMenu bonusMenu;

        public GameManager()
        {
            TotalTime = new TimeSpan(0, 1, 0);
            TimeTotalPause = new TimeSpan(0, 0, 0);
            TimePause = new Stopwatch();

            boat = new BasicBoat();
            fog = new FogWar();
            collisionManager = new CollisionManager();
            Treasure = new Treasure();
            bonusMenu= new BonusMenu();

            finish = false;

            Timer_String = "";
        }

        public void init_time(GameTime gameTime)
        {
            TimerStart = gameTime.TotalGameTime;
            TotalTime = new TimeSpan(0, 1, 0);
            TimeTotalPause = new TimeSpan(0, 0, 0);
            TimePause.Restart();
            finish = false;
        }

        public void AddTime()
        {
            TotalTime += new TimeSpan(0,0,30);
        }

        public void Update(GameTime gameTime, Vector2 screenCenter, MouseState mouse)
        {
            if (bonusMenu.IsChoiceDone())
            {
                Timer = TotalTime - (gameTime.TotalGameTime - TimerStart) + TimeTotalPause;
                if (Timer.TotalSeconds > 0)
                {
                    Timer_String = Timer.Minutes + ":" + Timer.Seconds + ":" + Timer.Milliseconds;
                }
                else
                {
                    Timer_String = "Perdu";
                    finish = true;
                }

                Treasure.Update(gameTime);
                boat.Update(gameTime, screenCenter);
                bonusMenu.Update(mouse);
                //fog.Update(gameTime);

                //fog.Update_Position(boat.get_position());

                if (collisionManager.collision_Treasure(boat, Treasure))
                {
                    Treasure.Move();
                    bonusMenu.ChoiceHasToBeMade();
                    TimePause.Start();
                }
            }
            else
            {
                bonusMenu.Update(mouse);
                if (bonusMenu.IsChoiceDone())
                {
                    switch (bonusMenu.GetChoice())
                    {
                        case BonusType.Speed:
                            
                            break;

                        case BonusType.Time:
                            AddTime();
                            break;
                        
                        case BonusType.FOV:

                            break;
                    }
                    TimePause.Stop();
                    TimeTotalPause = TimePause.Elapsed;
                }
            }

        }

        public void Draw(SpriteBatch _spriteBatch,Matrix transform)
        {
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.DrawString(TextureFinder.BasicFont, Timer_String, new Vector2(10, 10), Color.Black);
            boat.Draw(_spriteBatch);
            _spriteBatch.End();

            _spriteBatch.Begin(transformMatrix :transform, samplerState: SamplerState.PointClamp);
            //fog.Draw(_spriteBatch); 
            Treasure.Draw(_spriteBatch);
            _spriteBatch.End();

            _spriteBatch.Begin();
            bonusMenu.Draw(_spriteBatch);
            _spriteBatch.End();
        }

        public Vector2 GetBoatPosition()
        {
            return boat.Get_Position();
        }
    }
}
