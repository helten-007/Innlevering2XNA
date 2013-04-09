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
    public class ButtonData : Menu
    {
        private Rectangle _buttonPosition;
        private Vector2 _textPosition;
        private int _startMenuButtonPositionX, _startMenuButtonPositionY, _fromThetop;

        public Texture2D ButtonTexture { get; set; }
        public Color ColorButton { get; set; }
        public Color ColorText { get; set; }
        public String ButtonText { get; set; }
        public Rectangle ButtonPosition { get; set; }
        public Vector2 TextPosition { get; set; }

        public ButtonData(Game game, SpriteBatch spriteBatch, ContentManager content, 
            int fromTheTop, String buttonText)
            : base(game, spriteBatch, content)
        {
            ButtonTexture = content.Load<Texture2D>("buttonBack");
            ButtonText = buttonText;
            ColorButton = Color.White;
            ColorText = Color.Red;
            _fromThetop = fromTheTop;

            _startMenuButtonPositionX = (int)MenuPosition.X + (MenuTexture.Width / 2) - (ButtonTexture.Width / 2);
            _startMenuButtonPositionY = (int)MenuPosition.Y + 125;
            _buttonPosition = new Rectangle(_startMenuButtonPositionX, (_startMenuButtonPositionY + fromTheTop *
                (ButtonTexture.Height + 10)), ButtonTexture.Width, ButtonTexture.Height);
            ButtonPosition = _buttonPosition;

            _textPosition = new Vector2(_buttonPosition.X + (ButtonTexture.Width / 2) - 
                (Font.MeasureString(ButtonText).X / 2), _buttonPosition.Y + 15);
            TextPosition = _textPosition;
        }

        public override void Update(GameTime gameTime) 
        {
            base.Update(gameTime);

            if (_mouseRect.Intersects(ButtonPosition))
                ColorButton = Color.Gray;
            else
                ColorButton = Color.White;
        }
    }
}