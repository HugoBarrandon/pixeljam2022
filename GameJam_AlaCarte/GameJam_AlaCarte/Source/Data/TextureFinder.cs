using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameJam_AlaCarte.Source.Data
{
    static class TextureFinder
    {
        public const int SPRITESIZE = 16;

        public static Texture2D BoatTexture { get; private set; }


        public static SpriteFont BasicFont { get; private set; }

        public static void Load(ContentManager content)
        {
            BoatTexture = content.Load<Texture2D>("Boat/sprite_bateau_1");
            BasicFont = content.Load<SpriteFont>("Font/BasicFont");
        }
    }
}
