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
    public class MouseClass
    {
        private SpriteBatch spriteBatch;
        private ContentManager content;
        private MouseState _currentMouseState, _previousMouseState;
        private Rectangle _mouseRect, _checkRect;
        private Texture2D _mouseTexture;

        public bool IsMouseClicked { get; set; }
        public bool IntersectsMouse { get; set; }

        public MouseClass(Rectangle checkRect)
            : this(null, null)
        {
            _checkRect = checkRect;
        }

        public MouseClass(SpriteBatch spriteBatch, ContentManager content)
        {
            this.spriteBatch = spriteBatch;
            this.content = content;
            if (content != null)
                _mouseTexture = content.Load<Texture2D>("snakeHead");
        }

        public void Update(GameTime gameTime)
        {
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
            _mouseRect = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 5, 5);

            if (_checkRect != null)
            {
                if (_mouseRect.Intersects(_checkRect))
                {
                    IntersectsMouse = true;
                }
                else
                    IntersectsMouse = false;

                if (_currentMouseState.LeftButton == ButtonState.Released &&
                    _previousMouseState.LeftButton == ButtonState.Pressed)
                    IsMouseClicked = true;
                else
                    IsMouseClicked = false;
            }
        }

        public void Draw(GameTime gameTime)
        {
            if (spriteBatch != null)
            {
                spriteBatch.Draw(_mouseTexture, _mouseRect, Color.White);
            }
        }
    }
}
