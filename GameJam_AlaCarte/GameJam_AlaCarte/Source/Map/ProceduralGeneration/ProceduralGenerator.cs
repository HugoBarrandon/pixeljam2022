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
                    if (noise[i, j] < 210)
                    {
                        Random ran=new Random();
                        int nb = ran.Next(0, 1000);

                        if (nb == 98)
                        {
                            map[i].Add(new Tile.Tile(TileType.Water2, new Vector2(offsetX + i, offsetY + j)));

                        }
                        else if (nb == 44)
                        {
                            map[i].Add(new Tile.Tile(TileType.Water3, new Vector2(offsetX + i, offsetY + j)));

                        }
                        else if (nb == 69)
                        {
                            map[i].Add(new Tile.Tile(TileType.Water4, new Vector2(offsetX + i, offsetY + j)));

                        }
                        else if (nb == 727)//WYSI
                        {
                            map[i].Add(new Tile.Tile(TileType.Water5, new Vector2(offsetX + i, offsetY + j)));

                        }
                        else if (nb == 42)//WYSI
                        {
                            map[i].Add(new Tile.Tile(TileType.Water6, new Vector2(offsetX + i, offsetY + j)));

                        }
                        else 
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
