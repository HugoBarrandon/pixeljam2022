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
        public static Texture2D FogTexture { get; private set; }
        public static Texture2D noir { get; private set; }
        public static Texture2D TextureBonusMenu { get; private set; }
        public static Dictionary<String, Texture2D> MenuTexture { get; private set; }
        public static SpriteFont BasicFont { get; private set; }

        public static List<Texture2D> TreasureTextures;
        public static Dictionary<TileType, Texture2D> Tiles { get; private set; }

        public static Dictionary<BoatType, Texture2D> TextureBoat { get; private set; }

        public static void Load(ContentManager content)
        {
            MenuTexture = new Dictionary<string, Texture2D>();
            TreasureTextures = new List<Texture2D>();

            BoatTexture = content.Load<Texture2D>("Boat/sprite_bateau_1");
            noir = content.Load<Texture2D>("noir");
            FogTexture = content.Load<Texture2D>("Menu/Fog_of_War");
            TextureBonusMenu = content.Load<Texture2D>("Menu/plaque-bonus");
            
            TreasureTextures.Add(content.Load<Texture2D>("Placeables/tresor1"));
            TreasureTextures.Add(content.Load<Texture2D>("Placeables/tresor2"));


            BasicFont = content.Load<SpriteFont>("Font/BasicFont");

            MenuTexture.Add("StartingMenu", content.Load<Texture2D>("Menu/StartingMenu"));
            MenuTexture.Add("FinishMenu", content.Load<Texture2D>("Menu/FinishMenu"));


            LoadTiles(content);
            LoadBoat(content);
        }

        private static void LoadBoat(ContentManager content)
        {
            TextureBoat = new Dictionary<BoatType, Texture2D>();
            TextureBoat.Add(BoatType.Boat1, content.Load<Texture2D>("Boat/sprite_bateau_1"));
            TextureBoat.Add(BoatType.Boat2, content.Load<Texture2D>("Boat/sprite_bateau_vision"));
            TextureBoat.Add(BoatType.Boat3, content.Load<Texture2D>("Boat/sprite_bateau_vitesse"));
            TextureBoat.Add(BoatType.Boat4, content.Load<Texture2D>("Boat/sprite_bateau_vitessevision"));
            TextureBoat.Add(BoatType.Boat5, content.Load<Texture2D>("Boat/sprite_bateau_final"));
            
        }

        private static void LoadTiles(ContentManager content)
        {
            Tiles = new Dictionary<TileType, Texture2D>();
            Tiles.Add(TileType.Ground, content.Load<Texture2D>("Tiles/sprite_ile_1"));
            Tiles.Add(TileType.Water, content.Load<Texture2D>("Tiles/sprite_mer_3"));
            Tiles.Add(TileType.Sand, content.Load<Texture2D>("Tiles/sprite_sable"));
            Tiles.Add(TileType.Water2, content.Load<Texture2D>("Tiles/sprite_mer_1"));
            Tiles.Add(TileType.Water3, content.Load<Texture2D>("Tiles/sprite_mer_2"));
            Tiles.Add(TileType.Water4, content.Load<Texture2D>("Tiles/sprite_mer_4"));
            Tiles.Add(TileType.Water5, content.Load<Texture2D>("Tiles/sprite_mer_5"));
            Tiles.Add(TileType.Water6, content.Load<Texture2D>("Tiles/sprite_mer_6"));

        }
    }
}
