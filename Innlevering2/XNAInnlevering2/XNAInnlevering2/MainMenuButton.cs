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
    public class MainMenuButton : Menu
    {
        private Rectangle _buttonPosition;
        private Texture2D _buttonTexture;
        private Vector2 _textPosition;

        public Rectangle ButtonPosition { get; set; }
        public Texture2D ButtonTexture { get; set; }
        public String ButtonText { get; set; }
        public Vector2 TextPosition { get; set; }
        public Color ColorButton { get; set; }
        public Color ColorText { get; set; }

        public MainMenuButton(SpriteBatch spriteBatch, ContentManager content, Rectangle clientBounds, String buttonText)
            : base(spriteBatch, content, clientBounds)
        {
            _buttonTexture = content.Load<Texture2D>("mainMenuButton");
            ButtonTexture = _buttonTexture;
            //_buttonPosition = new Rectangle((int)MenuPosition.X + (int)(MenuTexture.Width / 2) - 
            //    (ButtonTexture.Width / 2), (int)MenuPosition.Y + 125, ButtonTexture.Width, ButtonTexture.Height);

            _buttonPosition = new Rectangle((int)MenuPosition.X + MenuPosition.Width - ButtonTexture.Width - 20,
                (int)MenuPosition.Y + 20, ButtonTexture.Width, ButtonTexture.Height);
            ButtonPosition = _buttonPosition;
            ButtonText = buttonText;
            _textPosition = new Vector2(_buttonPosition.X + (ButtonTexture.Width / 2) -
                (Font.MeasureString(ButtonText).X / 2), _buttonPosition.Y + 15);
            TextPosition = _textPosition;
            ColorButton = Color.White;
            ColorText = Color.Red;
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