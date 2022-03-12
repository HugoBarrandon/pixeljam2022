using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameJam_AlaCarte.Source.Camera
{
    class Camera
    {
        private float scale;
        private int lastScrollWheelValue;

        private const float baseZoom = 2;
        private const float maxZoom = 15;
        private const float sensitivity = 0.4f;
        private const float speed = 0.5f;

        public Matrix Transform { get; protected set; }
        protected Vector2 Position;
        protected GraphicsDevice _graphics;

        public Camera(GraphicsDevice graphics, int baseX =0, int baseY =0) 
        {
            _graphics = graphics;
            Position = new Vector2(-baseX * 16, -baseY * 16);
            scale = baseZoom;
            lastScrollWheelValue = 0;
            CalculateTransform();
        }

        public void Update(
            GameTime gameTime,
            KeyboardState keyboardState,
            MouseState mouseState)
        {
            bool recalculate = false;
            if (mouseState.ScrollWheelValue != lastScrollWheelValue)
            {
                int zoom = lastScrollWheelValue > mouseState.ScrollWheelValue ? -1 : 1;
                scale += zoom * sensitivity;

                if (scale <= 1)
                {
                    scale = 1;
                }
                else if (scale > maxZoom)
                {
                    scale = maxZoom;
                }

                recalculate = true;


            }
            lastScrollWheelValue = mouseState.ScrollWheelValue;



            /*if (keyboardState.IsKeyDown(Keys.Z))
            {
                Move(gameTime, 0, 1);
                recalculate = true;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                Move(gameTime, 0, -1);
                recalculate = true;
            }
            if (keyboardState.IsKeyDown(Keys.Q))
            {
                Move(gameTime, 1, 0);
                recalculate = true;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                Move(gameTime, -1, 0);
                recalculate = true;
            }*/

            if (recalculate)
            {
                CalculateTransform();
            }
        }

        private void CalculateTransform()
        {
            Viewport _viewport = _graphics.Viewport;
            Transform =
                    Matrix.CreateTranslation(new Vector3(Position.X - _viewport.Width / 2, Position.Y - _viewport.Height / 2, 0)) *  // Translation Matrix
                    Matrix.CreateScale(scale) *
                    Matrix.CreateTranslation(new Vector3(_viewport.Width / 2, _viewport.Height / 2, 0));
        }

        private void Move(GameTime gameTime, int x, int y)
        {
            Position.X += x * (float)gameTime.ElapsedGameTime.TotalMilliseconds * speed;
            Position.Y += y * (float)gameTime.ElapsedGameTime.TotalMilliseconds * speed;
        }

        public static Vector2 GetMouseRealPositionOnMap(Vector2 mousePostion, Matrix transform)
        {
            Matrix invertedMatrix = Matrix.Invert(transform);
            return Vector2.Transform(mousePostion, invertedMatrix);
        }

    }
}
