using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ZZeFactory.Source.ObjectInterfaces;
using ZZeFactory.Source.Types;

namespace ZZeFactory.Source.Map.Tile
{
    class Tile : IUpdatable, ObjectInterfaces.IDrawable
    {

        public MapTileTypes Type { get; private set; }
        private Vector2 Position;

        private Texture2D Texture;
        public bool HasPlaceable;
        public bool HasResource { get; private set; }


        public Tile(MapTileTypes type, Vector2 position)
        {
            Type = type;
            Texture = Data.TextureFinder.MapTiles[Type];
            Position = position;
            HasPlaceable = false;
            HasResource = false;
        }

        public void Update(GameTime gameTime, KeyboardState keyboardState, MouseState mouseState)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Matrix transform)
        {
            spriteBatch.Draw(Texture, new Vector2(Data.TextureFinder.SPRITESIZE * Position.X, Data.TextureFinder.SPRITESIZE * Position.Y), Color.White);
        }

    }
}
