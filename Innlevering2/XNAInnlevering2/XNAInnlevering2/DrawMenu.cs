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
        private Game game;
        private SpriteBatch _spriteBatch;
        public ContentManager _content;
        
        private MouseState _currentMouseState, _previousMouseState;
        private Rectangle clientBounds;
        private bool _gameIsRunning;

        private SnakeFood _snakeFood;
        private SnakeHead _snakeHead;
        private StartMenu _startMenu;
        private MouseClass _mouse;

        public DrawMenu(Game game)
            : base(game)
        {
            this.game = game;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            _content = Game.Content;
            clientBounds = game.Window.ClientBounds;

            _snakeFood = new SnakeFood(_spriteBatch, _content);
            _snakeHead = new SnakeHead(_spriteBatch, _content, clientBounds);

            _startMenu = new StartMenu(_spriteBatch, _content, clientBounds);
            _mouse = new MouseClass(_spriteBatch, _content);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (_gameIsRunning)
            {
                _snakeFood.Update(gameTime);
                _snakeHead.Update(gameTime);
            }
            else
            {
                _startMenu.Update(gameTime);
                _mouse.Update(gameTime);
            }
            if (_snakeHead.SnakeIsDead)
                game.Exit();

            if (_startMenu.RunGame)
                _gameIsRunning = true;
            KeyboardState keyboardState = Keyboard.GetState();
            
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            _spriteBatch.Begin();
            
            _snakeFood.Draw(gameTime);
            _snakeHead.Draw(gameTime);

            if (!_gameIsRunning)
            {
                _startMenu.Draw(gameTime);
                _mouse.Draw(gameTime);
            }
            if (_gameIsRunning)
                Console.WriteLine("balle");
            _spriteBatch.End();
        }

        public bool IsMousePressed()
        {
            return _currentMouseState.LeftButton == ButtonState.Released &&
                _previousMouseState.LeftButton == ButtonState.Pressed;
        }
    }
}