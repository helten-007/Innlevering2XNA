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
        private ContentManager _content;
        
        private Rectangle clientBounds;
        private bool _gameIsRunning, _drawStartMenu, _drawMusicMenu, _drawControlsMenu, 
            _playStartSound, _playGameOverSound, _playFoodSound;

        private SnakeFood _snakeFood;
        private SnakeHead _snakeHead;
        private StartMenu _startMenu;
        private ControlsMenu _controlsMenu;
        private MouseClass _mouse;
        private SoundEffects _sound;

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

            _snakeFood = new SnakeFood(_spriteBatch, _content, clientBounds);
            _snakeHead = new SnakeHead(_spriteBatch, _content, clientBounds);
            _startMenu = new StartMenu(_spriteBatch, _content, clientBounds);
            _controlsMenu = new ControlsMenu(_spriteBatch, _content, clientBounds);
            _mouse = new MouseClass(_spriteBatch, _content);
            _sound = new SoundEffects(_content);

            _drawStartMenu = true;
            _playStartSound = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (_playStartSound)
            {
                _sound.PlaySoundGameStart();
                _playStartSound = false;
            }

            if (_gameIsRunning)
            {
                _snakeHead.Update(gameTime);
                _snakeFood.Update(gameTime);
                if (_snakeHead.GameOverScreen)
                {
                    _drawStartMenu = true;
                    _gameIsRunning = false;
                    _drawMusicMenu = false;
                    _drawControlsMenu = false;
                }
                KeyboardState keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.Escape))
                {
                    _drawStartMenu = true;
                    _gameIsRunning = false;
                    _drawMusicMenu = false;
                    _drawControlsMenu = false;
                }
            }

            if (!_gameIsRunning)
            {
                _mouse.Update(gameTime);
                if (_drawStartMenu)
                {
                    if (_startMenu.RestartGame)
                    {
                        RestartGame();
                        _gameIsRunning = true;
                    }
                    _startMenu.Update(gameTime);
                    if (_startMenu.DrawControlsMenu)
                    {
                        Console.WriteLine("tegn controls");
                        _drawStartMenu = false;
                        _drawControlsMenu = true;
                    }
                    if (_startMenu.RunGame)
                        _gameIsRunning = true;
                    if (_startMenu.QuitGame)
                        game.Exit();
                }
                if (_drawControlsMenu)
                {
                    _controlsMenu.Update(gameTime);
                    if (_controlsMenu.DrawStartMenu)
                    {
                        _drawStartMenu = true;
                        _drawControlsMenu = false;
                    }
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            _spriteBatch.Begin();
            
            _snakeFood.Draw(gameTime);
            _snakeHead.Draw(gameTime);

            if (!_gameIsRunning)
            {
                if (_drawStartMenu)
                    _startMenu.Draw(gameTime);
                if (_drawControlsMenu)
                    _controlsMenu.Draw(gameTime);
                _mouse.Draw(gameTime);
            }
            _spriteBatch.End();
        }

        public void RestartGame()
        {
            _snakeHead.SnakeIsDead = false;
            _snakeHead.SnakePosition = new Vector2(0, 0);
            _snakeHead.MovementSpeed = _snakeHead.MinSpeed;
            _snakeHead.MovingRight = true;
        }
    }
}