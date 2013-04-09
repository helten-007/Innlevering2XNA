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

namespace Innlevering2
{
    public class MenuData
    {
        private Rectangle _destination;
        private Point _position;
        private Vector2 _textPosition;

        public Texture2D Texture { get; set; }
        public Rectangle TextureBounds { get; set; }
        public Color ColorButton { get; set; }
        public Color ColorText { get; set; }
        public String ButtonText { get; set; }

        public MenuData(Texture2D texture)
            : this(texture, texture.Bounds, "", new Vector2(0, 0))
        {

        }

        public MenuData(Texture2D texture, Rectangle destination, String buttonText, Vector2 textDestination)
        {
            Texture = texture;
            Destination = destination;
            TextureBounds = texture.Bounds;
            ButtonText = buttonText;
            TextPosition = textDestination;
            ColorButton = Color.Red;
            ColorText = Color.Blue;
        }

        public Point Position
        {
            get { return _position; }
            set
            {
                _position = value;
                _destination.X = _position.X;
                _destination.Y = _position.Y;
            }
        }

        public Rectangle Destination
        {
            get { return _destination; }
            set
            {
                _destination = value;
                _position.X = _destination.X;
                _position.Y = _destination.Y;
            }
        }

        public Vector2 TextPosition
        {
            get { return _textPosition; }
            set
            {
                _textPosition = value;
            }
        }
    }
}