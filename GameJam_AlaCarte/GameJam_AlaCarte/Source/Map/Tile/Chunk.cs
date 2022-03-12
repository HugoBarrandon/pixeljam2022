using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using GameJam_AlaCarte.Source.Map.ProceduralGeneration;

namespace GameJam_AlaCarte.Source.Map.Tile
{
    class Chunk 
    {
        public const int SIZE = 16;

        public List<List<Tile>> Tiles;

        public int X { get;private set; }
        public int Y { get;private set; }


        public Chunk(int xPos,int yPos,int seed,float scale)
        {
            Tiles = ProceduralGenerator.CreateChunk(SIZE, scale, xPos, yPos,seed);

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
