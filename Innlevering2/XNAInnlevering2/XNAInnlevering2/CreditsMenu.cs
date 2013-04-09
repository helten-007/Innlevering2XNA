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
    public class CreditsMenu : Menu
    {
        private ButtonData _mainMenuButton;

        public bool DrawStartMenu { get; set; }

        public CreditsMenu(Game game, SpriteBatch spriteBatch, ContentManager content) 
            : base(game, spriteBatch, content)
        {
            _mainMenuButton = new ButtonData(game, spriteBatch, content, 3, "CreditsTest");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _mainMenuButton.Update(gameTime);

            if (IsMousePressed() && _mouseRect.Intersects(_mainMenuButton.ButtonPosition))
            {
                DrawStartMenu = true;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            spriteBatch.Draw(_mainMenuButton.ButtonTexture, _mainMenuButton.ButtonPosition, _mainMenuButton.ColorButton);
            spriteBatch.DrawString(Font, _mainMenuButton.ButtonText, _mainMenuButton.TextPosition, _mainMenuButton.ColorText);
        }
    }
}