﻿using GameJam_AlaCarte.Source.Camera;
using GameJam_AlaCarte.Source.Data;
using GameJam_AlaCarte.Source.Manager;
using GameJam_AlaCarte.Source.Map;
using GameJam_AlaCarte.Source.Menu;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace GameJam_AlaCarte
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch _spriteBatch;
        private GameManager GM;


        private Camera Camera;
        private Map Map;
        private StartingMenu StartMenu;
        private FinishMenu FinishMenu;
        private BonusMenu BonusMenu;

        private int state = 0;
        int i = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            GM = new GameManager();
            Camera = new Camera(graphics.GraphicsDevice);
            StartMenu = new StartingMenu();
            BonusMenu = new BonusMenu();
            FinishMenu = new FinishMenu();

            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
            graphics.ApplyChanges();
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            TextureFinder.Load(Content);
            GM.GenerateMap(GraphicsDevice);
            GM.Load(Content);
            Map = GM.Map;
            TextureFinder.PlaySongJeu();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            var mouseState= Mouse.GetState();
            var keyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            switch (state)
            {
                case 0:
                    StartMenu.Update(gameTime);
                    //BonusMenu.Update(mouseState);
                    
                    if (StartMenu.is_starting())
                    {
                        state += 1;
                        GM.init_time(gameTime);
                        Update(gameTime);
                    }
                    break;


                case 1:
                    i++;
                    GM.Update(gameTime, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2),mouseState);
                    Camera.Update(gameTime, GM.GetBoatPosition());
                    Map.Update(gameTime, keyboardState, mouseState, Vector2.Zero, Camera.Transform);

                    if (GM.finish)
                    {
                        FinishMenu.NbPoint = GM.NbPoint;
                        FinishMenu.TimeSpend = GM.TimeSpend;
                        state = 2;
                        Reset();
                    }
                    break;

                case 2:
                    FinishMenu.Update(gameTime);
                    if(FinishMenu.next)
                    {
                        state = 0;
                        FinishMenu = new FinishMenu();
                    }
                    break;
            }

            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);

            
            switch (state)
            {
                case 0:
                    _spriteBatch.Begin();
                    StartMenu.Draw(_spriteBatch);
                    _spriteBatch.End();

                    break;

                case 1:
                    Map.Draw(_spriteBatch, Camera.Transform);
                    GM.Draw(_spriteBatch, Camera.Transform);
                    break;

                case 2:
                    FinishMenu.Draw(_spriteBatch);
                    break;
            }
        }

        public void Reset()
        {
            StartMenu.Reset();
        }
    }
}
