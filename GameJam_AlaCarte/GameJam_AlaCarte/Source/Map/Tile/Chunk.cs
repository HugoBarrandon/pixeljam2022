using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using ZZeFactory.Source.Map.ProceduralGeneration;
using ZZeFactory.Source.ObjectInterfaces;

namespace ZZeFactory.Source.Map.Tile
{
    class Chunk :IDrawable
    {
        public const int SIZE = 16;

        public List<List<Tile>> Tiles;
        public List<Placeable.Placeable> Placeables;

        public int X { get;private set; }
        public int Y { get;private set; }


        public Chunk(int xPos,int yPos,int seed,float scale)
        {
            var pair = ProceduralGenerator.CreateChunk(SIZE, scale, xPos, yPos,seed);

            Tiles = pair.Key;
            Placeables = pair.Value;
            X = xPos;
            Y = yPos;
        }

        public void Draw(SpriteBatch spriteBatch, Microsoft.Xna.Framework.Matrix transform)
        {
            foreach(List<Tile> l in Tiles)
            {
                foreach (Tile t in l)
                {
                    t.Draw(spriteBatch, transform);
                }
            }
        }
    }
}
