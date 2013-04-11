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
    public class SnakeFood
    {
        private SpriteBatch spriteBatch;
        private ContentManager content;
        private Rectangle clientBounds;
        private Texture2D _snakeFood;
        private Rectangle _foodRect;
        private Random rand;
        private int _gameTime, _timeBetweenFood;

        public SnakeFood(SpriteBatch spriteBatch, ContentManager content, Rectangle clientBounds)
        {
            this.spriteBatch = spriteBatch;
            this.content = content;
            this.clientBounds = clientBounds;
            _snakeFood = content.Load<Texture2D>("snakeFood");
            _foodRect = new Rectangle(-1000, -1000, _snakeFood.Width, _snakeFood.Height);
            rand = new Random();
            _timeBetweenFood = 5000;
            _gameTime = _timeBetweenFood;
        }

        public void Update(GameTime gameTime)
        {
            _gameTime += gameTime.ElapsedGameTime.Milliseconds;

            if (_gameTime > _timeBetweenFood)
            {
                _gameTime = 0;
                _foodRect.X = rand.Next(0, clientBounds.Width - _snakeFood.Width);
                _foodRect.Y = rand.Next(0, clientBounds.Height - _snakeFood.Height);
            }
        }

        public void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(_snakeFood, _foodRect, Color.Blue);
        }
    }
}