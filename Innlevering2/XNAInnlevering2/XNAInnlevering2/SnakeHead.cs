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

        private Vector2 _position;
        private Rectangle _lastTail;
        private float _maxSpeed;
        private float _acceleration;
        private float _brake;
        private int _playerNumber;
        private List<Rectangle> _parts;

        public bool MovingUp { get; set; }
        public bool MovingDown { get; set; }
        public bool MovingLeft { get; set; }
        public bool MovingRight { get; set; }
        public float MovementSpeed { get; set; }
        public float MinSpeed { get; set; }
        public Texture2D SnakeTexture { get; set; }
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

        public SnakeHead(SpriteBatch spriteBatch, ContentManager content, Rectangle clientBounds, Vector2 position, int playerNumber)
        {
            this.spriteBatch = spriteBatch;
            this.content = content;
            this.clientBounds = clientBounds;
            _playerNumber = playerNumber;
            SnakeTexture = content.Load<Texture2D>("snakeHead");
            SnakePosition = position;
            _parts = new List<Rectangle>();
            _parts.Add(new Rectangle((int)SnakePosition.X, (int)SnakePosition.Y, SnakeTexture.Width, SnakeTexture.Height));

            if (_playerNumber == 1)
                MovingRight = true;
            if (_playerNumber == 2)
                MovingLeft = true;
            MovementSpeed = 3;
            _maxSpeed = 15;
            MinSpeed = MovementSpeed;
            _acceleration = 0.2f;
            _brake = 0.08f;
        }

        public virtual void Update(GameTime gameTime)
        {
            if (SnakeIsDead)
                GameOverScreen = true;

            else
            {
                if (_playerNumber == 1)
                {
                    KeyboardState keyboardState = Keyboard.GetState();
                    GameOverScreen = false;
                    SnakeHitBox = new Rectangle((int)SnakePosition.X, (int)SnakePosition.Y, SnakeTexture.Width, SnakeTexture.Height);
                    if (keyboardState.IsKeyDown(Keys.W) && !MovingDown)
                    {
                        MovingUp = true;
                        MovingDown = false;
                        MovingRight = false;
                        MovingLeft = false;
                    }
                    if (keyboardState.IsKeyDown(Keys.S) && !MovingUp)
                    {
                        MovingUp = false;
                        MovingDown = true;
                        MovingRight = false;
                        MovingLeft = false;
                    }
                    if (keyboardState.IsKeyDown(Keys.D) && !MovingLeft)
                    {
                        MovingUp = false;
                        MovingDown = false;
                        MovingRight = true;
                        MovingLeft = false;
                    }
                    if (keyboardState.IsKeyDown(Keys.A) && !MovingRight)
                    {
                        MovingUp = false;
                        MovingDown = false;
                        MovingRight = false;
                        MovingLeft = true;
                    }

                    if (MovingUp)
                        _position.Y -= MovementSpeed;
                    if (MovingDown)
                        _position.Y += MovementSpeed;
                    if (MovingRight)
                        _position.X += MovementSpeed;
                    if (MovingLeft)
                        _position.X -= MovementSpeed;

                    if (keyboardState.IsKeyDown(Keys.Space) && MovementSpeed < _maxSpeed)
                        MovementSpeed += _acceleration;
                    if (keyboardState.IsKeyUp(Keys.Space) && MovementSpeed > MinSpeed)
                        MovementSpeed -= _brake;
                }
                if (_playerNumber == 2)
                {
                    KeyboardState keyboardState = Keyboard.GetState();
                    GameOverScreen = false;
                    SnakeHitBox = new Rectangle((int)SnakePosition.X, (int)SnakePosition.Y, SnakeTexture.Width, SnakeTexture.Height);

                    if (keyboardState.IsKeyDown(Keys.Up) && !MovingDown)
                    {
                        MovingUp = true;
                        MovingDown = false;
                        MovingRight = false;
                        MovingLeft = false;
                    }
                    if (keyboardState.IsKeyDown(Keys.Down) && !MovingUp)
                    {
                        MovingUp = false;
                        MovingDown = true;
                        MovingRight = false;
                        MovingLeft = false;
                    }
                    if (keyboardState.IsKeyDown(Keys.Right) && !MovingLeft)
                    {
                        MovingUp = false;
                        MovingDown = false;
                        MovingRight = true;
                        MovingLeft = false;
                    }
                    if (keyboardState.IsKeyDown(Keys.Left) && !MovingRight)
                    {
                        MovingUp = false;
                        MovingDown = false;
                        MovingRight = false;
                        MovingLeft = true;
                    }

                    if (MovingUp)
                        _position.Y -= MovementSpeed;
                    if (MovingDown)
                        _position.Y += MovementSpeed;
                    if (MovingRight)
                        _position.X += MovementSpeed;
                    if (MovingLeft)
                        _position.X -= MovementSpeed;

                    if (keyboardState.IsKeyDown(Keys.Space) && MovementSpeed < _maxSpeed)
                        MovementSpeed += _acceleration;

                    if (keyboardState.IsKeyUp(Keys.Space) && MovementSpeed > MinSpeed)
                        MovementSpeed -= _brake;
                }

                Rectangle lastHead = _parts.Last();
                Rectangle newHead = new Rectangle(0, 0, SnakeTexture.Width, SnakeTexture.Height);

                if (SnakeAteFood)
                {
                    if (MovingUp)
                    {
                        newHead.X = lastHead.X;
                        newHead.Y = lastHead.Y - SnakeTexture.Width;
                    }
                    if (MovingDown)
                    {
                        newHead.X = lastHead.X;
                        newHead.Y = lastHead.Y + SnakeTexture.Width;
                    }
                    if (MovingLeft)
                    {
                        newHead.X = lastHead.X - SnakeTexture.Width;
                        newHead.Y = lastHead.Y;
                    }
                    if (MovingRight)
                    {
                        newHead.X = lastHead.X + SnakeTexture.Width;
                        newHead.Y = lastHead.Y;
                    }
                    _parts.Add(newHead);
                }
            }
            _lastTail = _parts.First();

            if (SnakeAteFood)
                _parts.Insert(0, _lastTail);

            if (SnakePosition.X > clientBounds.Width - SnakeTexture.Width)
            {
                SnakeIsDead = true;
                Console.WriteLine("test");
            }
            if (SnakePosition.Y > clientBounds.Height - SnakeTexture.Height)
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

        public virtual void Draw(GameTime gameTime)
        {
            if (_playerNumber == 1)
            {
                foreach (Rectangle r in _parts)
                {
                    spriteBatch.Draw(SnakeTexture, new Vector2(r.X, r.Y), Color.Red);
                }
            }
            if (_playerNumber == 2)
            {
                foreach (Rectangle r in _parts)
                {
                    spriteBatch.Draw(SnakeTexture, new Vector2(r.X, r.Y), Color.Yellow);
                }
            }
        }
    }
}