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

        public static Dictionary<TileType, Texture2D> Tiles { get; private set; }

        public static void Load(ContentManager content)
        {
            BoatTexture = content.Load<Texture2D>("Boat/sprite_bateau_1");
            BasicFont = content.Load<SpriteFont>("Font/BasicFont");
            LoadTiles(content);
        }

        private static void LoadTiles(ContentManager content)
        {
            Tiles = new Dictionary<TileType, Texture2D>();
            Tiles.Add(TileType.Ground, content.Load<Texture2D>("Tiles/sprite_ile_1"));
            Tiles.Add(TileType.Water, content.Load<Texture2D>("Tiles/sprite_mer_2"));
            Tiles.Add(TileType.Sand, content.Load<Texture2D>("Tiles/sprite_sable"));


        }
    }
}
