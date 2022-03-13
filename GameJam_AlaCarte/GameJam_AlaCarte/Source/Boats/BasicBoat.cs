using GameJam_AlaCarte.Source.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameJam_AlaCarte.Source.Boats
{
    class BasicBoat : Boat
    {
        private Vector2 PosOnScreen;
        public override void Update(GameTime gameTime, Vector2 screenCenter)
        {
            PosOnScreen = screenCenter;
            base.Update(gameTime,screenCenter);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(rotation==0 || rotation==2)//Z
                spriteBatch.Draw(TextureFinder.TextureBoat[(BoatType)bateauSplash], new Rectangle((int)PosOnScreen.X, (int)PosOnScreen.Y, 32,32) , Color.White);
            else if (rotation==11)//S
                spriteBatch.Draw(TextureFinder.TextureBoat[(BoatType)bateauSplash], new Rectangle((int)PosOnScreen.X+32, (int)PosOnScreen.Y+32, 32, 32),null, Color.White,(float)Math.PI,new Vector2(0,0),SpriteEffects.None,0.0f);
            else if (rotation == 7)//Q
                spriteBatch.Draw(TextureFinder.TextureBoat[(BoatType)bateauSplash], new Rectangle((int)PosOnScreen.X , (int)PosOnScreen.Y+32, 32, 32), null, Color.White, (float)-Math.PI/2, new Vector2(0, 0), SpriteEffects.None, 0.0f);
            else if (rotation == 17)//D
                spriteBatch.Draw(TextureFinder.TextureBoat[(BoatType)bateauSplash], new Rectangle((int)PosOnScreen.X+32, (int)PosOnScreen.Y , 32, 32), null, Color.White, (float)Math.PI/2, new Vector2(0, 0), SpriteEffects.None, 0.0f);
            
            else if (rotation == 19)//D+Z
                spriteBatch.Draw(TextureFinder.TextureBoat[(BoatType)bateauSplash], new Rectangle((int)PosOnScreen.X + 16, (int)PosOnScreen.Y -16, 32, 32), null, Color.White, (float)(Math.PI / 4) , new Vector2(0, 0), SpriteEffects.None, 0.0f);
            else if (rotation == 28)//D+S
                spriteBatch.Draw(TextureFinder.TextureBoat[(BoatType)bateauSplash], new Rectangle((int)PosOnScreen.X + 32, (int)PosOnScreen.Y+16, 32, 32), null, Color.White, (float)(Math.PI*3 /4), new Vector2(0, 0), SpriteEffects.None, 0.0f);
            else if (rotation == 9)//Q+Z
                spriteBatch.Draw(TextureFinder.TextureBoat[(BoatType)bateauSplash], new Rectangle((int)PosOnScreen.X-16 , (int)PosOnScreen.Y+16, 32, 32), null, Color.White, (float)(-Math.PI / 4), new Vector2(0, 0), SpriteEffects.None, 0.0f);
            else if (rotation == 18)//Q+S
                spriteBatch.Draw(TextureFinder.TextureBoat[(BoatType)bateauSplash], new Rectangle((int)PosOnScreen.X +16, (int)PosOnScreen.Y +32, 32, 32), null, Color.White, (float)(-Math.PI * 3 / 4), new Vector2(0, 0), SpriteEffects.None, 0.0f);


        }

    }
}
