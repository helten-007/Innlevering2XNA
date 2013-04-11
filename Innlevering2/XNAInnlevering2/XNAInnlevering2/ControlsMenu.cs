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
    public class ControlsMenu : Menu
    {
        private List<DrawData> _controlsMenuList;
        private Texture2D _buttonTexture, _playerInfoTexture, _spaceButtonTexture;
        private Rectangle _startMenuButtonPosition, _controlsInfoPosition, _spaceButtonPosition;
        private int _numberOfButtons;

        public DrawData _playerInfo, _startMenuButton, _spaceButtonInfo;

        public bool DrawStartMenu { get; set; }

        public ControlsMenu(SpriteBatch spriteBatch, ContentManager content, Rectangle clientBounds)
            : base(spriteBatch, content, clientBounds)
        {
            _buttonTexture = content.Load<Texture2D>("mainMenuButton");
            _playerInfoTexture = content.Load<Texture2D>("playerInfoButton");
            _spaceButtonTexture = content.Load<Texture2D>("spaceButton");
            _numberOfButtons = 10;
            _controlsMenuList = new List<DrawData>();

            for (int i = 0; i < _numberOfButtons; i++)
            {
                _controlsInfoPosition = new Rectangle((int)MenuPosition.X + 100, (int)MenuPosition.Y + _playerInfoTexture.Height * i + 50,
                    _playerInfoTexture.Width, _playerInfoTexture.Height);
                if (i == 0)
                {
                    _playerInfo = new DrawData(_playerInfoTexture, _controlsInfoPosition, "PLAYER 1", Font, false);
                    _controlsMenuList.Add(_playerInfo);
                }
                if (i == 1)
                {
                    _playerInfo = new DrawData(_playerInfoTexture, _controlsInfoPosition, "Move up = W", Font, false);
                    _controlsMenuList.Add(_playerInfo);
                }
                if (i == 2)
                {
                    _playerInfo = new DrawData(_playerInfoTexture, _controlsInfoPosition, "Move down = S", Font, false);
                    _controlsMenuList.Add(_playerInfo);
                }
                if (i == 3)
                {
                    _playerInfo = new DrawData(_playerInfoTexture, _controlsInfoPosition, "Move left = A", Font, false);
                    _controlsMenuList.Add(_playerInfo);
                }
                if (i == 4)
                {
                    _playerInfo = new DrawData(_playerInfoTexture, _controlsInfoPosition, "Move right = D", Font, false);
                    _controlsMenuList.Add(_playerInfo);
                }
                if (i > 4)
                {
                    _controlsInfoPosition = new Rectangle((int)MenuPosition.X + _playerInfoTexture.Width + 150, (int)MenuPosition.Y +
                        _playerInfoTexture.Height * (i - 5) + 50, _playerInfoTexture.Width, _playerInfoTexture.Height);
                    if (i == 5)
                    {
                        _playerInfo = new DrawData(_playerInfoTexture, _controlsInfoPosition, "PLAYER 2", Font, false);
                        _controlsMenuList.Add(_playerInfo);
                    }
                    if (i == 6)
                    {
                        _playerInfo = new DrawData(_playerInfoTexture, _controlsInfoPosition, "Move up = UP", Font, false);
                        _controlsMenuList.Add(_playerInfo);
                    }
                    if (i == 7)
                    {
                        _playerInfo = new DrawData(_playerInfoTexture, _controlsInfoPosition, "Move down = DOWN", Font, false);
                        _controlsMenuList.Add(_playerInfo);
                    }
                    if (i == 8)
                    {
                        _playerInfo = new DrawData(_playerInfoTexture, _controlsInfoPosition, "Move left = LEFT", Font, false);
                        _controlsMenuList.Add(_playerInfo);
                    }
                    if (i == 9)
                    {
                        _playerInfo = new DrawData(_playerInfoTexture, _controlsInfoPosition, "Move right = RIGHT", Font, false);
                        _controlsMenuList.Add(_playerInfo);
                    }
                }
            }

            _startMenuButtonPosition = new Rectangle((int)MenuPosition.X + MenuPosition.Width -
                _buttonTexture.Width - 20, (int)MenuPosition.Y + 20, _buttonTexture.Width, _buttonTexture.Height);
            _startMenuButton = new DrawData(_buttonTexture, _startMenuButtonPosition, "Main Menu", Font, true);
            _controlsMenuList.Add(_startMenuButton);

            _spaceButtonPosition = new Rectangle((int)MenuPosition.X + 100, (int)MenuPosition.Y + MenuTexture.Height - _playerInfoTexture.Height - 25, 
                450, 50);
            _spaceButtonInfo = new DrawData(_spaceButtonTexture, _spaceButtonPosition, "Speed boost = SPACE for BOTH players", Font, false);
            _controlsMenuList.Add(_spaceButtonInfo);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _startMenuButton.Update(gameTime);
            if (_startMenuButton.IsClicked)
                DrawStartMenu = true;
            else
                DrawStartMenu = false;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            foreach (DrawData button in _controlsMenuList)
            {
                spriteBatch.Draw(button.Texture, button.Position, button.TextureColor);
                spriteBatch.DrawString(Font, button.Text, button.TextPosition, button.TextColor);
            }
        }
    }
}