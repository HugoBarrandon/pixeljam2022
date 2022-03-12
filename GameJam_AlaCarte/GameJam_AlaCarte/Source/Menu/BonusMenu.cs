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
            WindowDimension.X = GraphicsDeviceManager.DefaultBackBufferWidth;
            WindowDimension.Y = GraphicsDeviceManager.DefaultBackBufferHeight;
        }


        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(TextureFinder.BoatTexture, new Rectangle(0, 0, (int)WindowDimension.X/3, (int)WindowDimension.Y/3), Color.White);
            _spriteBatch.Draw(TextureFinder.BoatTexture, new Rectangle((int)WindowDimension.X/3, (int)WindowDimension.Y/3, (int)WindowDimension.X / 3, (int)WindowDimension.Y / 3), Color.White);
            _spriteBatch.Draw(TextureFinder.BoatTexture, new Rectangle((int)WindowDimension.X*2/3, (int)WindowDimension.Y*2/3, (int)WindowDimension.X / 3, (int)WindowDimension.Y / 3), Color.White);
        }
    }
}
