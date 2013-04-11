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
        private List<DrawData> _startMenuList;
        private Texture2D _buttonTexture;
        private Rectangle _buttonPosition;

        public DrawData startGameButton, restartButton, musicMenuButton, controlsButton, quitGameButton;

        public bool RunGame { get; set; }
        public bool RestartGame { get; set; }
        public bool DrawMusicMenu { get; set; }
        public bool DrawControlsMenu { get; set; }
        public bool QuitGame { get; set; }

        public StartMenu(SpriteBatch spriteBatch, ContentManager content, Rectangle clientBounds) 
            :base(spriteBatch, content, clientBounds)
        {
            _startMenuList = new List<DrawData>();
            _buttonTexture = content.Load<Texture2D>("buttonBack");
            for (int i = 0; i < 5; i++)
            {
                _buttonPosition = new Rectangle(MenuPosition.X + (MenuTexture.Width / 2) - (_buttonTexture.Width / 2),
                        (MenuPosition.Y + 50) + i * (_buttonTexture.Height + 10), _buttonTexture.Width, _buttonTexture.Height);

                if (i == 0)
                {
                    startGameButton = new DrawData(_buttonTexture, _buttonPosition, "Start Game", Font, true);
                    _startMenuList.Add(startGameButton);
                }
                else if(i == 1)
                {
                    restartButton = new DrawData(_buttonTexture, _buttonPosition, "Restart Game", Font, true);
                    _startMenuList.Add(restartButton);
                }
                else if (i == 2)
                {
                    musicMenuButton = new DrawData(_buttonTexture, _buttonPosition, "Music", Font, true);
                    _startMenuList.Add(musicMenuButton);
                }
                else if (i == 3)
                {
                    controlsButton = new DrawData(_buttonTexture, _buttonPosition, "Controls", Font, true);
                    _startMenuList.Add(controlsButton);
                }
                else if (i == 4)
                {
                    quitGameButton = new DrawData(_buttonTexture, _buttonPosition, "Quit Game", Font, true);
                    _startMenuList.Add(quitGameButton);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            startGameButton.Update(gameTime);
            restartButton.Update(gameTime);
            musicMenuButton.Update(gameTime);
            controlsButton.Update(gameTime);
            quitGameButton.Update(gameTime);

            if (startGameButton.isClicked)
            {
                RunGame = true;
            }
        }

        public override void Draw(GameTime gameTime) 
        {
            base.Draw(gameTime);

            foreach (DrawData button in _startMenuList)
            {
                spriteBatch.Draw(button.Texture, button.Position, button.TextureColor);
                spriteBatch.DrawString(Font, button.Text, button.TextPosition, button.TextColor);
            }
        }
    }
}