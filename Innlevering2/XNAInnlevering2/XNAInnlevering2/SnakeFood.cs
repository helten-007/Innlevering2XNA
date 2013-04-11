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
        private Texture2D _snakeFood;
        private Rectangle _foodRect;
        private Random rand;

        int tid;

        public SnakeFood(SpriteBatch spriteBatch, ContentManager content) 
        {
            this.spriteBatch = spriteBatch;
            this.content = content;
            _snakeFood = content.Load<Texture2D>("snakeFood");
            _foodRect = new Rectangle(-1000, -1000, _snakeFood.Width, _snakeFood.Height);
            rand = new Random();
            tid = 0;
        }

        public void Update(GameTime gameTime)
        {
            tid += gameTime.ElapsedGameTime.Milliseconds;

            if (tid > 1000)
            {
                tid = 0;
                _foodRect.X = rand.Next(0, 800 - _snakeFood.Width);
                _foodRect.Y = rand.Next(480 - _snakeFood.Height);
            }
        }

        public void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(_snakeFood, _foodRect, Color.Blue);
        }
    }
}