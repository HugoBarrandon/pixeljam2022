using GameJam_AlaCarte.Source.Camera;
using GameJam_AlaCarte.Source.Data;
using GameJam_AlaCarte.Source.Manager;
using GameJam_AlaCarte.Source.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameJam_AlaCarte
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameManager GM;

        private Camera Camera;
        private Map Map;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            GM = new GameManager();
            Camera = new Camera(_graphics.GraphicsDevice);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            TextureFinder.Load(Content);
            Map = new BasicMap();

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var keyboardState = Keyboard.GetState();
            var mouseState = Mouse.GetState();


            GM.Update(gameTime);
            Camera.Update(gameTime, keyboardState, mouseState);
            Map.Update(gameTime, keyboardState, mouseState, Vector2.Zero, Camera.Transform);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Map.Draw(_spriteBatch, Camera.Transform);
            _spriteBatch.Begin();

            GM.Draw(_spriteBatch);

            _spriteBatch.End();
            

            base.Draw(gameTime);
        }
    }
}
