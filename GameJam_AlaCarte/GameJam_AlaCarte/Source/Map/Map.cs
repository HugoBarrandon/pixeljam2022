using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameJam_AlaCarte.Source.Map
{
    public abstract class Map
    {

        public abstract void Update(GameTime gameTime, KeyboardState keyboardState, MouseState mouseState, Vector2 cameraPosition, Matrix transform);
        public abstract void Draw(SpriteBatch spriteBatch, Matrix transform);

        public abstract bool CanPlaceMachine();
        public abstract void PlaceMachine();
    }
}

