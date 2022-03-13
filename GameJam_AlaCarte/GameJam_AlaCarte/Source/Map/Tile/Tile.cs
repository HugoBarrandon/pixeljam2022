using GameJam_AlaCarte.Source.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameJam_AlaCarte.Source.Map.Tile
{
    public class Tile
    {

        public TileType Type { get; private set; }
        private Vector2 Position;

        private Texture2D Texture;
        public bool HasPlaceable;
        public bool HasResource { get; private set; }


        public Tile(TileType type, Vector2 position)
        {
            Type = type;
            Texture = TextureFinder.Tiles[Type];
            Position = position;
            HasPlaceable = false;
            HasResource = false;
        }

        public void Update(GameTime gameTime, KeyboardState keyboardState, MouseState mouseState)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Matrix transform)
        {
            spriteBatch.Draw(Texture, new Vector2(TextureFinder.SPRITESIZE * Position.X, TextureFinder.SPRITESIZE * Position.Y), Color.White);
        }

        public Vector2 Get_Position()
        {
            return Position;
        }

    }
}
