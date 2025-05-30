﻿using GameJam_AlaCarte.Source.Camera;
using GameJam_AlaCarte.Source.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using GameJam_AlaCarte.Source.Map.Tile;
using System.Diagnostics;

namespace GameJam_AlaCarte.Source.Map
{
    class ProceduralMap : Map
    {
        public int Seed { get; private set; }

        private float scale = 0.03f;


        private List<Chunk> Chunks;
        private const int MAPSIZE = 8;

        public const int baseX = Chunk.SIZE * 300;
        public const int baseY = Chunk.SIZE * 300;
        GraphicsDevice _graphics;


        public ProceduralMap(GraphicsDevice graphics)
        {
            _graphics = graphics;
            Random random = new Random();
            Seed = random.Next();
            //Seed = 999999;
            Chunks = new List<Chunk>();
            for (int i = 0; i < MAPSIZE; i++)
            {
                for (int j = 0; j < MAPSIZE; j++)
                {
                    Chunks.Add(new Chunk(i*Chunk.SIZE,j* Chunk.SIZE, Seed,scale));
                }
            }
        }


        public override void Update(GameTime gameTime, KeyboardState keyboardState, MouseState mouseState,Vector2 cameraPosition,Matrix transform)
        { 
            
        }

        public override void Draw(SpriteBatch spriteBatch, Matrix transform)
        {
            spriteBatch.Begin(transformMatrix: transform, samplerState: SamplerState.PointClamp);
            int draw = 0;
            foreach (Chunk c in Chunks)
            {
                c.Draw(spriteBatch, transform);
                draw++;
            }

            spriteBatch.End();
        }

        

        



        public override bool CanPlaceMachine()
        {
            throw new NotImplementedException();
        }

        public override void PlaceMachine()
        {
            throw new NotImplementedException();
        }

        public override List<Chunk> GetChunks(Vector2 pos)
        {
            List<Chunk> ret = new List<Chunk>();
            int X = (int)(pos.X / (Chunk.SIZE * TextureFinder.SPRITESIZE));
            int Y = (int)(pos.Y / (Chunk.SIZE * TextureFinder.SPRITESIZE));



            int margeX = -1*(int)pos.X % Chunk.SIZE;
            int margeY = -1*(int)pos.Y % Chunk.SIZE;

            if (X == -8) X = -7;
            if (Y == -8) Y = -7;

            int num = MAPSIZE * (-1*X) + (-1*Y);

            ret.Add(Chunks[num]);

            return ret;
        }

        public override List<Coordonnees> GetGround()
        {
            Coordonnees coo;
            List<Coordonnees> ret = new List<Coordonnees>();

            foreach(Chunk c in Chunks)
            {
                foreach(List<Tile.Tile> lt in c.Tiles)
                {
                    foreach(Tile.Tile t in lt)
                    {
                        if(t.Type == TileType.Sand)
                        {
                            coo = new Coordonnees(t.Get_Position().X * TextureFinder.SPRITESIZE, t.Get_Position().Y * TextureFinder.SPRITESIZE);
                            ret.Add(coo);
                        }
                    }
                }
            }
            return ret;
        }
    }
}
