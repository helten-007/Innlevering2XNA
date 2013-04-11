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
        private SpriteBatch spriteBatch;
        private ContentManager content;
        private Rectangle clientBounds;
        private Texture2D _snakeTexture;
        private Vector2 _snakePosition;
        private bool _movingUp, _movingDown, _movingRight, _movingLeft;
        private float movementSpeed, maxSpeed, minSpeed, acceleration, brake;

        public bool SnakeIsDead { get; set; }
        public bool SnakeAteFood { get; set; }

        public SnakeHead(SpriteBatch spriteBatch, ContentManager content, Rectangle clientBounds)
        {
            this.spriteBatch = spriteBatch;
            this.content = content;
            this.clientBounds = clientBounds;
            _snakeTexture = content.Load<Texture2D>("snakeHead");
            _snakePosition = new Vector2(10, 10);
            _movingRight = true;
            movementSpeed = 5;
            maxSpeed = 15;
            minSpeed = 5;
            acceleration = 0.05f;
            brake = 0.1f;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.W))
            {
                _movingUp = true;
                _movingDown = false;
                _movingRight = false;
                _movingLeft = false;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                _movingUp = false;
                _movingDown = true;
                _movingRight = false;
                _movingLeft = false;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                _movingUp = false;
                _movingDown = false;
                _movingRight = true;
                _movingLeft = false;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                _movingUp = false;
                _movingDown = false;
                _movingRight = false;
                _movingLeft = true;
            }

            if (_movingUp)
                _snakePosition.Y -= movementSpeed;
            if (_movingDown)
                _snakePosition.Y += movementSpeed;
            if (_movingRight)
                _snakePosition.X += movementSpeed;
            if (_movingLeft)
                _snakePosition.X -= movementSpeed;

            if (keyboardState.IsKeyDown(Keys.Space) && movementSpeed < maxSpeed)
                movementSpeed += acceleration;
            if (keyboardState.IsKeyUp(Keys.Space) && movementSpeed > minSpeed)
                movementSpeed -= brake;

            if (_snakePosition.X > clientBounds.Width - _snakeTexture.Width)
                SnakeIsDead = true;
            if (_snakePosition.Y > clientBounds.Height - _snakeTexture.Height)
                SnakeIsDead = true;
            if (_snakePosition.X < 0)
                SnakeIsDead = true;
            if (_snakePosition.Y < 0)
                SnakeIsDead = true;
        }

        public void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(_snakeTexture, _snakePosition, Color.White);
        }
    }
}
