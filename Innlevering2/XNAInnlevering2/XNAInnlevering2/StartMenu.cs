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
    public class StartMenu : Menu
    {
        private List<ButtonData> _startMenuList;

        public ButtonData startGameButton, musicMenuButton, controlsButton, creditsButton;

        public bool RunGame { get; set; }
        public bool DrawMusicMenu { get; set; }
        public bool DrawControlsMenu { get; set; }
        public bool DrawCreditsMenu { get; set; }

        public StartMenu(SpriteBatch spriteBatch, ContentManager content, Rectangle clientBounds) 
            :base(spriteBatch, content, clientBounds)
        {
            _startMenuList = new List<ButtonData>();

            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    startGameButton = new ButtonData(spriteBatch, content, clientBounds, i, "Start Game");
                    _startMenuList.Add(startGameButton);
                }
                else if (i == 1)
                {
                    musicMenuButton = new ButtonData(spriteBatch, content, clientBounds, i, "Music");
                    _startMenuList.Add(musicMenuButton);
                }
                else if (i == 2)
                {
                    controlsButton = new ButtonData(spriteBatch, content, clientBounds, i, "Controls");
                    _startMenuList.Add(controlsButton);
                }
                else if (i == 3)
                {
                    creditsButton = new ButtonData(spriteBatch, content, clientBounds, i, "Credits");
                    _startMenuList.Add(creditsButton);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            startGameButton.Update(gameTime);
            musicMenuButton.Update(gameTime);
            controlsButton.Update(gameTime);
            creditsButton.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) 
        {
            base.Draw(gameTime);

            foreach (ButtonData button in _startMenuList)
            {
                spriteBatch.Draw(button.ButtonTexture, button.ButtonPosition, button.ColorButton);
                spriteBatch.DrawString(Font, button.ButtonText, button.TextPosition, button.ColorText);
            }
        }
    }
}