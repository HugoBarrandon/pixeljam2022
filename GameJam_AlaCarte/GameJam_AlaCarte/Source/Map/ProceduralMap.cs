using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using ZZeFactory.Source.Map.ProceduralGeneration;
using ZZeFactory.Source.Map.Tile;

namespace ZZeFactory.Source.Map
{
    class ProceduralMap : Map
    {
        public int Seed { get; private set; }

        private float scale = 0.03f;


        private List<Chunk> Chunks;
        private const int UpdateDistance = 11;

        private Chunk CentralChunk;
        public const int baseX = 16*300;
        public const int baseY = 16*300;
        GraphicsDevice _graphics;

        public ProceduralMap(GraphicsDevice graphics)
        {
            _graphics = graphics;
            Random random = new Random();
            Seed = random.Next();

            Chunks = new List<Chunk>();

        }


        public override void Update(GameTime gameTime, KeyboardState keyboardState, MouseState mouseState,Matrix transform)
        {
            
            Vector2 topLeft = Camera.Camera.GetMouseRealPositionOnMap(Vector2.Zero, transform);
            Vector2 center = new Vector2(topLeft.X + _graphics.Viewport.Width / 2, topLeft.Y + _graphics.Viewport.Height / 2);
            if (Chunks.Count == 0)
            {
                for (int i = 0; i < UpdateDistance; i++)
                {
                    for (int j = 0; j < UpdateDistance; j++)
                    {
                        Chunks.Add(new Chunk((int)center.X / Chunk.SIZE+  ( -(UpdateDistance/2)+1 +i ) * 16, ((int)center.Y / Chunk.SIZE) + (-(UpdateDistance / 2)+1 + j ) * 16, Seed, scale));
                    }
                }

            }

            for(int i = 0;i < Chunks.Count;i++)
            {
                if(Chunks[i].X *16- center.X> 16*16* ((UpdateDistance/2)+1))
                {
                    Chunks[i] = new Chunk( Chunks[(i+UpdateDistance)%Chunks.Count].X - 16, Chunks[i].Y, Seed, scale);
                }else if (Chunks[i].X * 16 - center.X < -16 * 16 * ((UpdateDistance / 2) + 1))
                {
                    Chunks[i] = new Chunk(Chunks[(i - UpdateDistance + Chunks.Count) % Chunks.Count].X +16, Chunks[i].Y, Seed, scale);
                }
                else if (Chunks[i].Y * 16 - center.Y > 16 * 16 * ((UpdateDistance / 2) + 1))
                {
                    Chunks[i] = new Chunk(Chunks[i].X, Chunks[(i + 1) % Chunks.Count].Y - 16, Seed, scale);
                }
                else if (Chunks[i].Y * 16 - center.Y < - 16 * 16 * ((UpdateDistance / 2) + 1))
                {
                    Chunks[i] = new Chunk(Chunks[i].X, Chunks[(i - 1 + Chunks.Count) % Chunks.Count].Y + 16, Seed, scale);
                }
            }
            
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
            //System.Diagnostics.Debug.WriteLine(draw);

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
    }
}
