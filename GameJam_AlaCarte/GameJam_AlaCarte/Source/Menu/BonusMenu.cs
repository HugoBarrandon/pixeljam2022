using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameJam_AlaCarte.Source.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameJam_AlaCarte.Source.Menu
{
    class BonusMenu
    {
        public int NbBonus { get; private set; }
        private Vector2 WindowDimension;
        private bool ChoiceDone;
        private BonusType Choice;

        public BonusMenu()
        {
            Choice = BonusType.Speed;
            ChoiceDone = false;
            NbBonus = 3;
            
        }


        public bool IsChoiceDone()
        {
            return ChoiceDone;
        }

        public BonusType GetChoice()
        {
            return Choice;
        }

        public void Update(Point position)
        {
            if (!ChoiceDone)
            {
                WindowDimension.X = GraphicsDeviceManager.DefaultBackBufferWidth;
                WindowDimension.Y = GraphicsDeviceManager.DefaultBackBufferHeight;
            }
        }


        public void Draw(SpriteBatch _spriteBatch)
        {
            if (!ChoiceDone)
            {   //1600*900
                _spriteBatch.Draw(TextureFinder.BoatTexture, new Rectangle(0, 0, 100, (int)WindowDimension.Y / 3), Color.White);
                _spriteBatch.Draw(TextureFinder.BoatTexture, new Rectangle(533,100, 300, 300), Color.White);
                _spriteBatch.Draw(TextureFinder.BoatTexture, new Rectangle(1066, 100, 300, 300), Color.White);

            }
        }
    }
}
