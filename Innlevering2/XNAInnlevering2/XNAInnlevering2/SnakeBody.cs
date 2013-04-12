using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace XNAInnlevering2
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public class Snake
    {
        private List<Rectangle> _parts;
        private Texture2D _bodyBlock;
        private int _startX = 160;
        private int _startY = 120;
        private int _moveDelay = 100;
        private DateTime _lastUpdatedAt;
        private Direction _direction;
        private Rectangle _lastTail;

        public Snake(Texture2D bodyBlock)
        {
            _bodyBlock = bodyBlock;
            _parts = new List<Rectangle>();
            _parts.Add(new Rectangle(_startX, _startY, _bodyBlock.Width, _bodyBlock.Height));
            _parts.Add(new Rectangle(_startX + bodyBlock.Width, _startY, _bodyBlock.Width, _bodyBlock.Height));
            _parts.Add(new Rectangle(_startX + (bodyBlock.Width) * 2, _startY, _bodyBlock.Width, _bodyBlock.Height));
            _parts.Add(new Rectangle(_startX + (bodyBlock.Width) * 3, _startY, _bodyBlock.Width, _bodyBlock.Height));
            _direction = Direction.Right;
            _lastUpdatedAt = DateTime.Now;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var p in _parts)
            {
                spriteBatch.Draw(_bodyBlock, new Vector2(p.X, p.Y), Color.White);
            }
        }

        public void Update()
        {
            if (DateTime.Now.Subtract(_lastUpdatedAt).TotalMilliseconds > _moveDelay)
            {
                //DateTime.Now.Ticks
                _lastTail = _parts.First();
                _parts.Remove(_lastTail);

                /* add new head in right direction */
                var lastHead = _parts.Last();
                var newHead = new Rectangle(0, 0, _bodyBlock.Width, _bodyBlock.Height);
                switch (_direction)
                {
                    case Direction.Up:
                        newHead.X = lastHead.X;
                        newHead.Y = lastHead.Y - _bodyBlock.Width;
                        break;
                    case Direction.Down:
                        newHead.X = lastHead.X;
                        newHead.Y = lastHead.Y + _bodyBlock.Width;
                        break;
                    case Direction.Left:
                        newHead.X = lastHead.X - _bodyBlock.Width;
                        newHead.Y = lastHead.Y;
                        break;
                    case Direction.Right:
                        newHead.X = lastHead.X + _bodyBlock.Width;
                        newHead.Y = lastHead.Y;
                        break;
                }
                _parts.Add(newHead);
                _lastUpdatedAt = DateTime.Now;
            }
        }

        public void SetDirection(Direction newDirection)
        {
            if (_direction == Direction.Up && newDirection == Direction.Down)
            {
                return;
            }
            else if (_direction == Direction.Down && newDirection == Direction.Up)
            {
                return;
            }
            else if (_direction == Direction.Left && newDirection == Direction.Right)
            {
                return;
            }
            else if (_direction == Direction.Right && newDirection == Direction.Left)
            {
                return;
            }
            _direction = newDirection;
        }

        //public bool IsEating(Apple apple)
        //{
        //    if (_parts.Last().Intersects(apple.Location))
        //    {
        //        GrowBiggerAndFaster();
        //        return true;
        //    }
        //    return false;
        //}

        private void GrowBiggerAndFaster()
        {
            _parts.Insert(0, _lastTail);
            _moveDelay -= (_moveDelay / 100) * 2;
        }
    }
}