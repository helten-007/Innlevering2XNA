using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Innlevering2
{
    public class MenuHandler : Microsoft.Xna.Framework.Game
    {
        SpriteBatch spriteBatch;
        GraphicsDeviceManager graphics;

        private MenuData _menuBackground;
        private MenuData _startMenu;

        private Texture2D _buttonTexture;
        private Texture2D _menuBack;
        private Rectangle _buttonRect;
        private Rectangle _menuPosition;
        int _buttonPositionX;
        int _buttonPositionY;

        private String _buttonText = "Halla";
        private Vector2 _textPosition;

        public Vector2 windowBounds { get; set; }

        private String halla = "halla";

        public MenuHandler()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            DrawableGameComponent renderer = new DrawMenu(this);
            Components.Add(renderer);
            Services.AddService(typeof(IDrawMenu), renderer);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _buttonTexture = Content.Load<Texture2D>("buttonBack");
            _menuBack = Content.Load<Texture2D>("menuBack");
        }

        public void StartMenu()
        {
            IDrawMenu renderer = (IDrawMenu)Services.GetService(typeof(IDrawMenu));

            _menuPosition = new Rectangle((Window.ClientBounds.Width / 2) - (_menuBack.Width / 2), (Window.ClientBounds.Height / 2) - (_menuBack.Height / 2), 
                _menuBack.Width, _menuBack.Height);

            _menuBackground = new MenuData(_menuBack, _menuPosition, _buttonText, 
                new Vector2((_menuPosition.X + (_menuBack.Width / 2)) - (_buttonText.Length / 2), 100));
            renderer.AddButton(_menuBackground);

            _buttonPositionX = _menuPosition.X + (_menuBack.Width / 2) - (_buttonTexture.Width / 2);
            _buttonPositionY = _menuPosition.Y + 100;

            for (int i = 0; i < 4; i++)
            {
                _buttonRect = new Rectangle(_buttonPositionX, (_buttonPositionY + i * (_buttonTexture.Height + 10)),
                    _buttonTexture.Width, _buttonTexture.Height);

                _textPosition = new Vector2(_buttonPositionX, _buttonPositionY);

                _startMenu = new MenuData(_buttonTexture, _buttonRect, _buttonText,
                    new Vector2((_menuPosition.X + (_menuBack.Width / 2)) - (_buttonText.Length / 2), 100));
                renderer.AddButton(_startMenu);
            }
        }

        public void Update(GameTime gameTime) 
        {
            base.Update(gameTime);


        }
    }
}
