using GameJam_AlaCarte.Source.Data;
using GameJam_AlaCarte.Source.Map.Tile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
namespace GameJam_AlaCarte.Source.Map
{
    class BasicMap : Map
    {
        private List<List<Tile.Tile>> map;


        public BasicMap()
        {
            map = new List<List<Tile.Tile>>();
            for (int i = 0; i < 21; i++)
            {
                map.Add(new List<Tile.Tile>());
                for (int j = 0; j < 21; j++)
                {

                    map[i].Add( new Tile.Tile(
                         j% 2 == 0 ? TileType.Sand : TileType.Water
                        ,new Vector2(i,j)));
                }
            }
        }






        public override void Update(GameTime gameTime, KeyboardState keyboardState, MouseState mouseState, Vector2 cameraPosition, Matrix transform)
        {
        }

        public override void Draw(SpriteBatch spriteBatch, Matrix transform)
        {
            spriteBatch.Begin(transformMatrix: transform, samplerState: SamplerState.PointClamp);
            for (int i = 0; i < 21; i++)
            {
                for (int j = 0; j < 21; j++)
                {
                    map[i][j].Draw(spriteBatch, transform);
                }
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
            throw new NotImplementedException();
        }
        public override List<Coordonnees> GetGround()
        {
            throw new NotImplementedException();
        }

    }
}
