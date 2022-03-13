using GameJam_AlaCarte.Source.Boats;
using GameJam_AlaCarte.Source.Data;
using GameJam_AlaCarte.Source.Menu;
using GameJam_AlaCarte.Source.Placeable;
using GameJam_AlaCarte.Source.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
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
        private TimeSpan TimeSpend;

        private String Timer_String;

        public bool finish { get; private set; }

        private Treasure Treasure;

        private Boat boat;
        private FogWar fog;

        private int NbPoint = 0;

        public Map.Map Map { get; private set; }

        private CollisionManager collisionManager;

        private BonusMenu bonusMenu;

        public GameManager()
        {
            TotalTime = new TimeSpan(0, 1, 0);
            TimeTotalPause = new TimeSpan(0, 0, 0);
            TimeSpend = new TimeSpan(0, 0, 0);
            TimePause = new Stopwatch();

            boat = new BasicBoat();
            fog = new FogWar();
            collisionManager = new CollisionManager();
            Treasure = new Treasure();
            bonusMenu= new BonusMenu();

            NbPoint = 0;

            finish = false;

            Timer_String = "";
        }

        public void init_time(GameTime gameTime)
        {
            boat = new BasicBoat();
            TimerStart = gameTime.TotalGameTime;
            TotalTime = new TimeSpan(0, 1, 0);
            TimeTotalPause = new TimeSpan(0, 0, 0);
            TimePause.Restart();
            finish = false;
            NbPoint = 0;
            boat.ResetSpeed();
            Treasure.Move(Map.GetGround());
        }

        public void AddTime()
        {
            TotalTime += new TimeSpan(0,0,30);
        }

        public void Update(GameTime gameTime, Vector2 screenCenter, MouseState mouse)
        {
            TimeSpend = gameTime.TotalGameTime - TimerStart;
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

                if (!collisionManager.collision_map(boat.Get_Position(), Map.GetChunks(boat.Get_Position())) && !collisionManager.collision_bord(boat.Get_Position()))
                {
                    boat.Move();
                }
                else
                {
                    boat.MoveBack();
                }

                //fog.Update(gameTime);

                //fog.Update_Position(boat.get_position());

                if (collisionManager.collision_Treasure(boat, Treasure))
                {
                    Treasure.Move(Map.GetGround());
                    bonusMenu.ChoiceHasToBeMade();
                    TimePause.Start();
                    NbPoint++;
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
                            boat.IncreaseSpeed();
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
            _spriteBatch.DrawString(TextureFinder.BasicFont, Timer_String, new Vector2(10, 10), Color.White);
            _spriteBatch.DrawString(TextureFinder.BasicFont, "Points : " + NbPoint, new Vector2(10, 50), Color.White);
            _spriteBatch.DrawString(TextureFinder.BasicFont, "Temps : " + TimeSpend, new Vector2(10, 100), Color.White);
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

        public void GenerateMap(GraphicsDevice GraphicsDevice)
        {
            Map = new ProceduralMap(GraphicsDevice);
        }
    }
}
