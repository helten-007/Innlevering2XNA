﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace XNAInnlevering2
{
    public class DrawMenu : DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;
        public ContentManager _content;
        private Game game;
        private StartMenu _startMenu;
        private MusicMenu _musicMenu;
        private ControlsMenu _controlsMenu;
        private CreditsMenu _creditsMenu;
        private MouseState _currentMouseState, _previousMouseState;
        private Rectangle _mouseRect, clientBounds;
        private bool _drawStartMenu, _drawMusicMenu, _drawControls, _drawCredits, _gameIsPaused, _gameHasStarted, _drawMenus;

        SnakeFood food;

        public DrawMenu(Game game)
            : base(game)
        {
            this.game = game;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            _content = Game.Content;
            clientBounds = game.Window.ClientBounds;
            Console.WriteLine(clientBounds);
            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            _startMenu = new StartMenu(_spriteBatch, _content, clientBounds);
            _musicMenu = new MusicMenu(_spriteBatch, _content, clientBounds);
            _controlsMenu = new ControlsMenu(_spriteBatch, _content, clientBounds);
            _creditsMenu = new CreditsMenu(_spriteBatch, _content, clientBounds);

            food = new SnakeFood(_spriteBatch, _content);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _startMenu.Update(gameTime);
            _musicMenu.Update(gameTime);
            _controlsMenu.Update(gameTime);
            _creditsMenu.Update(gameTime);
            food.Update(gameTime);

            KeyboardState keyboardState = Keyboard.GetState();
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
            _mouseRect = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 10, 10);

            
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            _spriteBatch.Begin();

            food.Draw(gameTime);

            _spriteBatch.End();
        }

        public bool IsMousePressed()
        {
            return _currentMouseState.LeftButton == ButtonState.Released &&
                _previousMouseState.LeftButton == ButtonState.Pressed;
        }
    }
}