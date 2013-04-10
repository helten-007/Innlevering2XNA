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
        private Texture2D _snakePart, snakeHead;
        private List<Texture2D> _snakeList;
        private KeyboardState key;
        private Rectangle _snakeRect;
        private Vector2 SnakePos;

        private bool movingUp, movingDown, movingRight, movingLeft;


        public Snake(SpriteBatch spriteBatch, ContentManager content) 
        {
            this.spriteBatch = spriteBatch;
            this.content = content;
            snakeHead = content.Load<Texture2D>("snakeHead");
            _snakePart = content.Load<Texture2D>("SnakeFood");
            _snakeList = new List<Texture2D>();
        }

        public void Update(GameTime gameTime) 
        {
            _snakeRect = new Rectangle(SnakePos.X, SnakePos.Y, );

            if (key.IsKeyDown(Keys.W))
            {
                movingUp = true;
                movingDown = false;
                movingRight = false;
                movingLeft = false;
            }
            if (key.IsKeyDown(Keys.S))
            {
                movingUp = false; ;
                movingDown = true;
                movingRight = false;
                movingLeft = false;
            }
            if (key.IsKeyDown(Keys.D))
            {
                movingUp = false; ;
                movingDown = false;
                movingRight = true;
                movingLeft = false;
            }
            if (key.IsKeyDown(Keys.A))
            {
                movingUp = false;
                movingDown = false;
                movingRight = false;
                movingLeft = true;
            }

            if (movingUp)
                SnakePos.Y -= 4;
            if (movingDown)
                SnakePos.Y += 4;
            if (movingRight)
                SnakePos.X += 4;
            if (movingLeft)
                SnakePos.X -= 4;
        }

        public void Draw(GameTime gameTime) 
        {
            spriteBatch.Draw(snakeHead, SnakePos, Color.White);

            for (int i = 0;)
        }
    }
}
