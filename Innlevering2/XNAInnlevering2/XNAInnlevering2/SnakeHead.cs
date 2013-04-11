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
    public class SnakeHead
    {
        public SpriteBatch spriteBatch;
        public ContentManager content;
        public Rectangle clientBounds;

        private Texture2D _snakeTexture;
        private Vector2 _position;
        private bool _movingUp, _movingDown, _movingLeft;
        private float maxSpeed;
        private float acceleration;
        private float brake;

        public bool MovingRight { get; set; }
        public float MovementSpeed { get; set; }
        public float MinSpeed { get; set; }

        public bool SnakeIsDead { get; set; }
        public bool SnakeAteFood { get; set; }
        public bool GameOverScreen { get; set; }
        public Rectangle SnakeHitBox { get; set; }

        public Vector2 SnakePosition
        {
            get { return _position; }

            set
            {
                _position = value;
            }
        }

        public SnakeHead(SpriteBatch spriteBatch, ContentManager content, Rectangle clientBounds)
        {
            this.spriteBatch = spriteBatch;
            this.content = content;
            this.clientBounds = clientBounds;
            _snakeTexture = content.Load<Texture2D>("snakeHead");
            SnakePosition = new Vector2(10, 10);
            MovingRight = true;
            MovementSpeed = 3;
            maxSpeed = 15;
            MinSpeed = MovementSpeed;
            acceleration = 0.5f;
            brake = 0.08f;
        }

        public void Update(GameTime gameTime)
        {
            if (SnakeIsDead)
                GameOverScreen = true;

            else
            {
                KeyboardState keyboardState = Keyboard.GetState();
                GameOverScreen = false;
                SnakeHitBox = new Rectangle((int)SnakePosition.X, (int)SnakePosition.Y, _snakeTexture.Width, _snakeTexture.Height);
                if (keyboardState.IsKeyDown(Keys.W))
                {
                    _movingUp = true;
                    _movingDown = false;
                    MovingRight = false;
                    _movingLeft = false;
                }
                if (keyboardState.IsKeyDown(Keys.S))
                {
                    _movingUp = false;
                    _movingDown = true;
                    MovingRight = false;
                    _movingLeft = false;
                }
                if (keyboardState.IsKeyDown(Keys.D))
                {
                    _movingUp = false;
                    _movingDown = false;
                    MovingRight = true;
                    _movingLeft = false;
                }
                if (keyboardState.IsKeyDown(Keys.A))
                {
                    _movingUp = false;
                    _movingDown = false;
                    MovingRight = false;
                    _movingLeft = true;
                }

                if (_movingUp)
                    _position.Y -= MovementSpeed;
                if (_movingDown)
                    _position.Y += MovementSpeed;
                if (MovingRight)
                    _position.X += MovementSpeed;
                if (_movingLeft)
                    _position.X -= MovementSpeed;

                if (keyboardState.IsKeyDown(Keys.Space) && MovementSpeed < maxSpeed)
                    MovementSpeed += acceleration;
                if (keyboardState.IsKeyUp(Keys.Space) && MovementSpeed > MinSpeed)
                    MovementSpeed -= brake;
            }
            if (SnakePosition.X > clientBounds.Width - _snakeTexture.Width)
            {
                SnakeIsDead = true;
                Console.WriteLine("test");
            }
            if (SnakePosition.Y > clientBounds.Height - _snakeTexture.Height)
            {
                SnakeIsDead = true;
                Console.WriteLine("test");
            }
            if (SnakePosition.X < 0)
            {
                SnakeIsDead = true;
                Console.WriteLine("test");
            }
            if (SnakePosition.Y < 0)
            {
                SnakeIsDead = true;
                Console.WriteLine("test");
            }
        }

        public void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(_snakeTexture, SnakePosition, Color.White);
        }
    }
}