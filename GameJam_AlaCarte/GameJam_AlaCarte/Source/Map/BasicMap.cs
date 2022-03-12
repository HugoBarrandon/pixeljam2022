using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using ZZeFactory.Source.Map.Tile;
namespace ZZeFactory.Source.Map
{
    class BasicMap : Map
    {
        private List<List<Tile.Tile>> map;
        private List<Placeable.Placeable> Placeables;

        private const int SpriteSize = 16;

        public BasicMap()
        {
            map = new List<List<Tile.Tile>>();
            for (int i = 0; i < 21; i++)
            {
                map.Add(new List<Tile.Tile>());
                for (int j = 0; j < 21; j++)
                {

                    map[i].Add( new Tile.Tile(
                         j% 2 == 0 ? Types.MapTileTypes.Ground : Types.MapTileTypes.Water
                        ,new Vector2(i,j)));
                }
            }
        }






        public override void Update(GameTime gameTime, KeyboardState keyboardState, MouseState mouseState,Matrix transform)
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
    }
}
