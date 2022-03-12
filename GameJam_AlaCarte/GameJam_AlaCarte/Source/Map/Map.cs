using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using ZZeFactory.Source.ObjectInterfaces;

namespace ZZeFactory.Source.Map
{
    abstract class Map
    {

        public abstract void Update(GameTime gameTime, KeyboardState keyboardState, MouseState mouseState,Matrix transform);
        public abstract void Draw(SpriteBatch spriteBatch, Matrix transform);

        public abstract bool CanPlaceMachine();
        public abstract void PlaceMachine();
    }
}

