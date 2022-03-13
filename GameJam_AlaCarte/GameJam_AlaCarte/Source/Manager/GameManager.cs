using GameJam_AlaCarte.Source.Boats;
using GameJam_AlaCarte.Source.Data;
using GameJam_AlaCarte.Source.Menu;
using GameJam_AlaCarte.Source.Placeable;
using GameJam_AlaCarte.Source.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        public TimeSpan TimeSpend;

        private String Timer_String;

        public bool finish { get; private set; }

        private Treasure Treasure;

        private Boat boat;

        public int NbPoint = 0;

        public Map.Map Map { get; private set; }

        private CollisionManager collisionManager;

        private BonusMenu bonusMenu;

        private Effect Fog;

        public GameManager()
        {
            TotalTime = new TimeSpan(0, 1, 0);
            TimeTotalPause = new TimeSpan(0, 0, 0);
            TimeSpend = new TimeSpan(0, 0, 0);
            TimePause = new Stopwatch();

            boat = new BasicBoat();
            collisionManager = new CollisionManager();
            Treasure = new Treasure();
            bonusMenu= new BonusMenu();

            NbPoint = 0;

            finish = false;

            Timer_String = "";
        }

        public void Load(ContentManager content)
        {
            Fog = content.Load<Effect>("Effects/File");
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
            boat.ResetBonus();
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

                    if(NbPoint == 10)
                    {
                        finish = true;
                    }
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
                    boat.AddBonus();
                    TimePause.Stop();
                    TimeTotalPause = TimePause.Elapsed;
                }
            }

        }

        public void Draw(SpriteBatch _spriteBatch,Matrix transform)
        {
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            boat.Draw(_spriteBatch);

            _spriteBatch.End();

            _spriteBatch.Begin(
                transformMatrix :transform, 
                samplerState: SamplerState.PointClamp
                );
            //fog.Draw(_spriteBatch); 
            Fog.CurrentTechnique.Passes[0].Apply();

            Treasure.Draw(_spriteBatch);
            _spriteBatch.End();


            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            Fog.CurrentTechnique.Passes[0].Apply();
            Fog.Parameters["size"].SetValue(3);
            _spriteBatch.Draw(TextureFinder.noir,new Rectangle(0,0,1600,900),Color.White);
            _spriteBatch.End();

            _spriteBatch.Begin();
            bonusMenu.Draw(_spriteBatch);
            _spriteBatch.DrawString(TextureFinder.BasicFont, Timer_String, new Vector2(10, 10), Color.White);
            _spriteBatch.DrawString(TextureFinder.BasicFont, "Points : " + NbPoint, new Vector2(10, 50), Color.White);
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
