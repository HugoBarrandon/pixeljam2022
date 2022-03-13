using GameJam_AlaCarte.Source.Boats;
using GameJam_AlaCarte.Source.Data;
using GameJam_AlaCarte.Source.Menu;
using GameJam_AlaCarte.Source.Placeable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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

        public bool finish { get; private set; }

        private Treasure Treasure;

        private Boat boat;

        private CollisionManager collisionManager;

        private BonusMenu bonusMenu;

        private Effect Fog;

        public GameManager()
        {
            TotalTime = new TimeSpan(0, 0, 10);
            boat = new BasicBoat();
            collisionManager = new CollisionManager();
            Treasure = new Treasure();
            bonusMenu= new BonusMenu();

            finish = false;

            Timer_String = "";
        }

        public void Load(ContentManager content)
        {
            Fog = content.Load<Effect>("Effects/File");
        }

        public void init_time(GameTime gameTime)
        {
            TimerStart = gameTime.TotalGameTime;
            finish = false;
        }   

        public void AddTime(int time)
        {
        }

        public void Update(GameTime gameTime, Vector2 screenCenter, MouseState mouse)
        {
            Timer = TotalTime - (gameTime.TotalGameTime - TimerStart);
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
            boat.Update(gameTime,screenCenter);
            bonusMenu.Update(mouse);
            //fog.Update(gameTime);

            //fog.Update_Position(boat.get_position());

            if(collisionManager.collision_Treasure(boat, Treasure))
            {
                Treasure.Move();
                bonusMenu.ChoiceHasToBeMade();
            }

        }

        public void Draw(SpriteBatch _spriteBatch,Matrix transform)
        {
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.DrawString(TextureFinder.BasicFont, Timer_String, new Vector2(10, 10), Color.Black);
            boat.Draw(_spriteBatch);
            _spriteBatch.DrawString(TextureFinder.BasicFont, Treasure.Get_Position().X.ToString(), new Vector2(10, 200), Color.Black);

            _spriteBatch.End();

            _spriteBatch.Begin(
                transformMatrix :transform, 
                samplerState: SamplerState.PointClamp
                );
            //fog.Draw(_spriteBatch); 
            Fog.CurrentTechnique.Passes[0].Apply();

            Treasure.Draw(_spriteBatch);
            _spriteBatch.End();

            _spriteBatch.Begin();
            bonusMenu.Draw(_spriteBatch);
            _spriteBatch.End();

            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            Fog.CurrentTechnique.Passes[0].Apply();
            Fog.Parameters["size"].SetValue(3);
            _spriteBatch.Draw(TextureFinder.noir,new Rectangle(0,0,1600,900),Color.White);
            _spriteBatch.End();
        }

        public Vector2 GetBoatPosition()
        {
            return boat.Get_Position();
        }
    }
}
