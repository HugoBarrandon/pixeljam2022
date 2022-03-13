using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameJam_AlaCarte.Source.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace GameJam_AlaCarte.Source.Menu
{
    class BonusMenu
    {
        public int NbBonus { get; private set; }

        private bool ChoiceDone;
        private BonusType Choice;

        public BonusMenu()
        {
            Choice = BonusType.Time;
            this.ChoiceDone = true;
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

        public void ChoiceHasToBeMade()
        {
            this.ChoiceDone = false;
            this.Choice = BonusType.Time;
        }

        public void Update(MouseState Souris)
        {
            if (!ChoiceDone)
            {

                if (Souris.LeftButton==ButtonState.Pressed)
                {
                    int nb = Souris.X;
                    if (nb < 533) {
                        this.Choice = BonusType.Speed;
                    }
                    else if (nb < 1067)
                    {
                        Choice = BonusType.Time;
                    }
                    else
                    {
                        Choice = BonusType.FOV;
                    }
                    ChoiceDone = true;
                }

            }
        }


        public void Draw(SpriteBatch _spriteBatch)
        {
            if (!ChoiceDone)
            {   //1600*900
                //_spriteBatch.Begin();
                /*_spriteBatch.Draw(TextureFinder.BoatTexture, new Rectangle(0, 0, 300, 300), Color.White);
                _spriteBatch.Draw(TextureFinder.BoatTexture, new Rectangle(533,100, 300, 300), Color.White);
                _spriteBatch.Draw(TextureFinder.BoatTexture, new Rectangle(1067, 100, 300, 300), Color.White);*/
                _spriteBatch.Draw(TextureFinder.TextureBonusMenu, new Rectangle(100, 100, 1400, 700), Color.White);
                //_spriteBatch.End();

            }
        }
    }
}
