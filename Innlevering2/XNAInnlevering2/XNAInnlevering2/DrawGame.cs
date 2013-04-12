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
    public class DrawGame : DrawableGameComponent
    {
        private Game game;
        private SpriteBatch _spriteBatch;
        private ContentManager _content;
        
        private Rectangle clientBounds;
        private Vector2 _player1Position, _player2Position;
        private bool _gameIsRunning, _drawStartMenu, _drawMusicMenu, _drawControlsMenu, 
            _playStartSound;

        private SnakeFood _snakeFood;
        private SnakeHead _player1, _player2;
        private StartMenu _startMenu;
        private ControlsMenu _controlsMenu;
        private MouseClass _mouse;
        private SoundEffects _sound;
        private BackgroundMusic _music;

        public DrawGame(Game game)
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

            _player1Position = new Vector2(10, 10);
            _player2Position = new Vector2(clientBounds.Width - 30, clientBounds.Height - 30);

            _snakeFood = new SnakeFood(_spriteBatch, _content, clientBounds);
            _player1 = new SnakeHead(_spriteBatch, _content, clientBounds, _player1Position, 1);
            _player2 = new SnakeHead(_spriteBatch, _content, clientBounds, _player2Position, 2);
            _startMenu = new StartMenu(_spriteBatch, _content, clientBounds);
            _controlsMenu = new ControlsMenu(_spriteBatch, _content, clientBounds);
            _mouse = new MouseClass(_spriteBatch, _content);
            _sound = new SoundEffects(_content);
            _music = new BackgroundMusic(_content);

            _drawStartMenu = true;
            _playStartSound = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            _sound.Update(gameTime);
            _music.Update(gameTime);

            if (_playStartSound)
            {
                _sound.PlaySoundGameStart();
                _playStartSound = false;
            }

            if (_gameIsRunning)
            {
                _player1.Update(gameTime);
                _player2.Update(gameTime);
                _snakeFood.Update(gameTime);
                if (_player1.GameOverScreen)
                {
                    _sound.PlaySoundGameOver();
                    _drawStartMenu = true;
                    _gameIsRunning = false;
                    _drawMusicMenu = false;
                    _drawControlsMenu = false;
                }
                if (_player2.GameOverScreen)
                {
                    _sound.PlaySoundGameOver();
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

                if (_player1.SnakeHitBox.Intersects(_snakeFood.FoodPosition))
                {
                    _snakeFood.IsEaten = true;
                    _player1.SnakeAteFood = true;
                    _sound.PlayFoodSpawn();
                }
                else
                    _player1.SnakeAteFood = false;

                if (_player2.SnakeHitBox.Intersects(_snakeFood.FoodPosition))
                {
                    _snakeFood.IsEaten = true;
                    _player2.SnakeAteFood = true;
                    _sound.PlayFoodSpawn();
                }
                else
                    _player2.SnakeAteFood = false;

                if (_snakeFood.ChangePosition)
                    _sound.PlayFoodSpawn();
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
            _player1.Draw(gameTime);
            _player2.Draw(gameTime);

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
            _player1.SnakeIsDead = false;
            _player1.SnakePosition = _player1Position;
            _player1.MovementSpeed = _player1.MinSpeed;
            _player1.MovingUp = false;
            _player1.MovingDown = false;
            _player1.MovingRight = true;
            _player1.MovingLeft = false;

            _player2.SnakeIsDead = false;
            _player2.SnakePosition = _player2Position;
            _player2.MovementSpeed = _player2.MinSpeed;
            _player2.MovingUp = false;
            _player2.MovingDown = false;
            _player2.MovingRight = false;
            _player2.MovingLeft = true;
        }
    }
}