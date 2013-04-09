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
    public class Snake
    {
        private SpriteBatch spriteBatch;
        private ContentManager content;
        private Texture2D _snakePart;
        private Rectangle _snakeRect;

        public Snake(SpriteBatch spriteBatch, ContentManager content) 
        {
            this.spriteBatch = spriteBatch;
            this.content = content;
            _snakePart = content.Load<Texture2D>("SnakeFood");
            _snakeRect = new Rectangle(0, 20, 20, 20);
        }

        public void Update(GameTime gameTime) 
        {
            _snakeRect.X += 1;
        }

        public void Draw(GameTime gameTime) 
        {
            spriteBatch.Draw(_snakePart, _snakeRect, Color.White);
        }
    }
}
