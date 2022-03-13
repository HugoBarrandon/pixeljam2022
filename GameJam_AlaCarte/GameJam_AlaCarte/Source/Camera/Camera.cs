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

        public Matrix Transform { get; protected set; }
        protected Vector2 LastPosition;
        protected GraphicsDevice _graphics;

        private float Zoom = 2;


        public Camera(GraphicsDevice graphics, int baseX =0, int baseY =0) 
        {
            _graphics = graphics;
            LastPosition = Vector2.One;
            CalculateTransform(_graphics.Viewport);
        }

        public void Update(
            GameTime gameTime,
            Vector2 boatPosition)
        {

            Viewport _viewport = _graphics.Viewport;

            bool recalculate = false;
            if(boatPosition != LastPosition)
            {
                LastPosition = boatPosition + new Vector2(_viewport.Width/2,_viewport.Height/2);
                recalculate = true;
            }
            if (recalculate)
            {
                CalculateTransform(_viewport);
            }
        }

        private void CalculateTransform(Viewport _viewport)
        {
            Transform =
                    Matrix.CreateTranslation(new Vector3(LastPosition.X - _viewport.Width / 2, LastPosition.Y - _viewport.Height / 2, 0)) *  // Translation Matrix
                    Matrix.CreateScale(Zoom) *
                    Matrix.CreateTranslation(new Vector3(_viewport.Width / 2, _viewport.Height / 2, 0));
        }


        public static Vector2 GetMouseRealPositionOnMap(Vector2 mousePostion, Matrix transform)
        {
            Matrix invertedMatrix = Matrix.Invert(transform);
            return Vector2.Transform(mousePostion, invertedMatrix);
        }

    }
}
