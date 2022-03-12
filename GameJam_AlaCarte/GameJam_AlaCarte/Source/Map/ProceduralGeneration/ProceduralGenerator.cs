using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ZZeFactory.Source.Data;
using ZZeFactory.Source.Placeable.Miscellaneous;

namespace ZZeFactory.Source.Map.ProceduralGeneration
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

      

        public static KeyValuePair<List<List<Tile.Tile>>, List<Placeable.Placeable>> CreateChunk(int size, float scale, int offsetX, int offsetY,int seed)
        {
            List<List<Tile.Tile>> map = new List<List<Tile.Tile>>();
            List<Placeable.Placeable> placeables = new List<Placeable.Placeable>();
            var noise = CreateNoise(size, scale,offsetX,offsetY,seed);

            for (int i = 0; i < size; i++)
            {
                map.Add(new List<Tile.Tile>());
                for (int j = 0; j < size; j++)
                {
                    if (noise[i, j] < 40)
                    {
                        map[i].Add(new Tile.Tile(Types.MapTileTypes.Water, new Vector2(offsetX + i,offsetY + j)));
                    }
                    else if (noise[i, j] < 120)
                    {
                        map[i].Add(new Tile.Tile(Types.MapTileTypes.Grass, new Vector2(offsetX + i, offsetY + j)));
                        if (noise[i, j] < 80)
                        {
                            map[i][j].HasPlaceable = true;
                            placeables.Add(new Tree(new Vector2(offsetX + i, offsetY + j), 1, 1, TextureFinder.MapTiles[Types.MapTileTypes.Tree]));
                        }
                    }
                    else
                    {
                        map[i].Add(new Tile.Tile(Types.MapTileTypes.Ground, new Vector2(offsetX + i, offsetY + j)));
                    }

                }
            }
            return new KeyValuePair<List<List<Tile.Tile>>, List<Placeable.Placeable>>(map, placeables);
        }
    }
}
