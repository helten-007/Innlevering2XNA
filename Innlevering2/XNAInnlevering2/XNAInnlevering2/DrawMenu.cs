using System;
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
        private ContentManager _content;
        private Game game;
        private StartMenu _startMenu;
        private MusicMenu _musicMenu;
        private ControlsMenu _controlsMenu;
        private CreditsMenu _creditsMenu;
        private MouseState _currentMouseState, _previousMouseState;
        private Rectangle _mouseRect;
        private bool _drawStartMenu, _drawMusicMenu, _drawControls, _drawCredits, _gameIsPaused, _gameHasStarted, _drawMenus;

        Snake snake;

        public DrawMenu(Game game)
            : base(game)
        {
            this.game = game;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            _content = Game.Content;
            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            _startMenu = new StartMenu(game, _spriteBatch, _content);
            _musicMenu = new MusicMenu(game, _spriteBatch, _content);
            _controlsMenu = new ControlsMenu(game, _spriteBatch, _content);
            _creditsMenu = new CreditsMenu(game, _spriteBatch, _content);

            snake = new Snake(_spriteBatch, _content);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _startMenu.Update(gameTime);
            _musicMenu.Update(gameTime);
            _controlsMenu.Update(gameTime);
            _creditsMenu.Update(gameTime);
            snake.Update(gameTime);

            KeyboardState keyboardState = Keyboard.GetState();
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
            _mouseRect = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 10, 10);

            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                _gameIsPaused = true;
                _drawStartMenu = true;
            }

            if (_drawStartMenu)
            {
                _drawMusicMenu = false;
                _drawControls = false;
                _drawCredits = false;
            }

            if (IsMousePressed() && _mouseRect.Intersects(_startMenu.startGameButton.ButtonPosition))
            {
                Console.WriteLine("halla");
                _startMenu.IsBeingDrawn = true;
                _drawStartMenu = false;
                _gameHasStarted = true;
                _gameIsPaused = false;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            _spriteBatch.Begin();

            //if (_drawStartMenu || !_gameHasStarted)
            //{
            //    _startMenu.Draw(gameTime);
            //    _startMenu.IsBeingDrawn = true;
            //}
            //if (_drawMusicMenu)
            //{
            //    _musicMenu.Draw(gameTime);
            //    _musicMenu.IsBeingDrawn = true;
            //}
            //if (_drawControls)
            //{
            //    _controlsMenu.Draw(gameTime);
            //    _controlsMenu.IsBeingDrawn = true;
            //}
            //if (_drawCredits)
            //{
            //    _creditsMenu.Draw(gameTime);
            //    _creditsMenu.IsBeingDrawn = true;
            //}

            snake.Draw(gameTime);

            _spriteBatch.End();
        }

        public bool IsMousePressed()
        {
            return _currentMouseState.LeftButton == ButtonState.Released &&
                _previousMouseState.LeftButton == ButtonState.Pressed;
        }
    }
}