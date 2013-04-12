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
    public class SnakeBody : SnakeHead
    {
        private List<Rectangle> _snakeList;
        private Rectangle _snakeBodyPart;

        public Rectangle BodyHitBox { get; set; }

        public SnakeBody(SpriteBatch spriteBatch, ContentManager content, Rectangle clientBounds, Vector2 position, int playerNumber)
            : base(spriteBatch, content, clientBounds, position, playerNumber)
        {
            _snakeList = new List<Rectangle>();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (MovingUp)
                _snakeBodyPart = new Rectangle((int)SnakePosition.X, (int)SnakePosition.Y - SnakeTexture.Height,
                SnakeTexture.Width, SnakeTexture.Height);
            if (MovingDown)
                _snakeBodyPart = new Rectangle((int)SnakePosition.X, (int)SnakePosition.Y + SnakeTexture.Height,
                SnakeTexture.Width, SnakeTexture.Height);
            if (MovingRight)
                _snakeBodyPart = new Rectangle((int)SnakePosition.X - SnakeTexture.Width, (int)SnakePosition.Y,
                SnakeTexture.Width, SnakeTexture.Height);
            if (MovingLeft)
                _snakeBodyPart = new Rectangle((int)SnakePosition.X + SnakeTexture.Width, (int)SnakePosition.Y,
                SnakeTexture.Width, SnakeTexture.Height);
            BodyHitBox = new Rectangle(_snakeBodyPart.X, _snakeBodyPart.Y, SnakeTexture.Width, SnakeTexture.Height);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            spriteBatch.Draw(SnakeTexture, _snakeBodyPart, Color.Yellow);
        }
    }
}