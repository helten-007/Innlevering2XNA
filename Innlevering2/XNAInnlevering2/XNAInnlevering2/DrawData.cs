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
    public class DrawData
    {
        private bool clickable;
        private Rectangle _position, _firstPosition;
        private MouseClass _mouse;

        public bool IntersectsMouse { get; set; }
        public bool IsClicked { get; set; }

        public Texture2D Texture { get; set; }
        public Color TextureColor { get; set; }
        public String Text { get; set; }
        public Vector2 TextPosition { get; set; }
        public Color TextColor { get; set; }
        public SpriteFont Font { get; set; }

        public DrawData(Texture2D texture, Rectangle position)
            : this(texture, position, null, null, false)
        {}

        public DrawData(Texture2D texture, Rectangle position, String text, SpriteFont font, bool clickable)
        {
            Texture = texture;
            _firstPosition = position;
            Position = position;
            Text = text;
            Font = font;
            this.clickable = clickable;
            TextureColor = Color.White;
            TextColor = Color.Red;
            TextPosition = new Vector2(Position.X + (Texture.Width / 2) - (Font.MeasureString(Text).X / 2), Position.Y + 15);
            _mouse = new MouseClass(_firstPosition);
        }

        public Rectangle Position
        {
            get { return _position; }
            set
            {
                _position = value;
            }
        }

        public void Update(GameTime gameTime)
        {
            _mouse.Update(gameTime);

            if (_mouse.IntersectsMouse)
                IntersectsMouse = true;
            else
                IntersectsMouse = false;

            Position = _position;
            if (clickable && IntersectsMouse)
            {
                TextureColor = Color.Gray;
                if (Position.Width < _firstPosition.Width + 20 && Position.Height < _firstPosition.Height + 20)
                {
                    _position.X -= 1;
                    _position.Y -= 1;
                    _position.Width += 2;
                    _position.Height += 2;
                }
            }
            else
            {
                TextureColor = Color.White;
                if (Position.Width > _firstPosition.Width && Position.Height > _firstPosition.Height)
                {
                    _position.X += 1;
                    _position.Y += 1;
                    _position.Width -= 2;
                    _position.Height -= 2;
                }
            }

            if (_mouse.IsMouseClicked && clickable && IntersectsMouse)
                IsClicked = true;
            else
                IsClicked = false;
        }
    }
}