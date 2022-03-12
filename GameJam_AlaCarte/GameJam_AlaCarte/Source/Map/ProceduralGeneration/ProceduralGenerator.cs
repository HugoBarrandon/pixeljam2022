using GameJam_AlaCarte.Source.Data;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace GameJam_AlaCarte.Source.Map.ProceduralGeneration
{
    static class ProceduralGenerator
    {


        private static float[,] CreateNoise(int size, float scale,int offsetX,int offsetY,int seed)
        { 
            SimplexNoise.Noise.Seed = seed;
            float[,] noise = new float[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    noise[i, j] = SimplexNoise.Noise.CalcPixel2D(i+offsetX, j+offsetY, scale);
                }
            }

            return noise;
        }

      

        public static List<List<Tile.Tile>> CreateChunk(int size, float scale, int offsetX, int offsetY,int seed)
        {
            List<List<Tile.Tile>> map = new List<List<Tile.Tile>>();
            var noise = CreateNoise(size, scale,offsetX,offsetY,seed);

            for (int i = 0; i < size; i++)
            {
                map.Add(new List<Tile.Tile>());
                for (int j = 0; j < size; j++)
                {
                    if (noise[i, j] < 150)
                    {
                        map[i].Add(new Tile.Tile(TileType.Water, new Vector2(offsetX + i,offsetY + j)));
                    }
                    else
                    {
                        map[i].Add(new Tile.Tile(TileType.Sand, new Vector2(offsetX + i, offsetY + j)));
                    }

                }
            }
            return map;
        }
    }
}
