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
    public class MusicMenu : Menu
    {
        private ButtonData _songButton1, _songButton2, _songButton3, _mainMenuButton;
        private List<ButtonData> _startMenuList;

        public bool Song1 { get; set; }
        public bool Song2 { get; set; }
        public bool Song3 { get; set; }
        public bool DrawStartMenu { get; set; }

        public MusicMenu(Game game, SpriteBatch spriteBatch, ContentManager content)
            : base(game, spriteBatch, content)
        {
            //_songTextureChecked = content.Load<Texture2D>("buttonBackChecked");
            //_songTextureUnchecked = content.Load<Texture2D>("buttonBackUnchecked");
            //_buttonTexture = content.Load<Texture2D>("buttonBack");
            _startMenuList = new List<ButtonData>();

            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    _songButton1 = new ButtonData(game, spriteBatch, content, i, "Sang1");
                    _startMenuList.Add(_songButton1);
                }
                else if (i == 1)
                {
                    _songButton2 = new ButtonData(game, spriteBatch, content, i, "Sang2");
                    _startMenuList.Add(_songButton2);
                }
                else if (i == 2)
                {
                    _songButton3 = new ButtonData(game, spriteBatch, content, i, "Sang3");
                    _startMenuList.Add(_songButton3);
                }
                else if (i == 3)
                {
                    _mainMenuButton = new ButtonData(game, spriteBatch, content, i, "Main Menu");
                    _startMenuList.Add(_mainMenuButton);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _songButton1.Update(gameTime);
            _songButton2.Update(gameTime);
            _songButton3.Update(gameTime);
            _mainMenuButton.Update(gameTime);

            if (IsMousePressed() && _mouseRect.Intersects(_songButton1.ButtonPosition))
            {
                Song1 = true;
                Song2 = false;
                Song3 = false;
            }

            if (IsMousePressed() && _mouseRect.Intersects(_songButton2.ButtonPosition))
            {
                Song1 = false;
                Song2 = true;
                Song3 = false;
            }

            if (IsMousePressed() && _mouseRect.Intersects(_songButton3.ButtonPosition))
            {
                Song1 = false;
                Song2 = false;
                Song3 = true;
            }

            if (IsMousePressed() && _mouseRect.Intersects(_mainMenuButton.ButtonPosition))
            {
                DrawStartMenu = true;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            foreach (ButtonData button in _startMenuList)
            {
                spriteBatch.Draw(button.ButtonTexture, button.ButtonPosition, button.ColorButton);
                spriteBatch.DrawString(Font, button.ButtonText, button.TextPosition, button.ColorText);
            }

            //if (Song1)
            //    _songButton1.ButtonTexture = _songTextureChecked;
            //else
            //    _songButton1.ButtonTexture = _songTextureUnchecked;

            //if (Song2)
            //    _songButton2.ButtonTexture = _songTextureChecked;
            //else
            //    _songButton2.ButtonTexture = _songTextureUnchecked;

            //if (Song3)
            //    _songButton3.ButtonTexture = _songTextureChecked;
            //else
            //    _songButton3.ButtonTexture = _songTextureUnchecked;
        }
    }
}