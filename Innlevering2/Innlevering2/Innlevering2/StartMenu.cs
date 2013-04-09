//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Audio;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using Microsoft.Xna.Framework.Media;

//namespace Innlevering2
//{
//    public class StartMenu
//    {
//        public ContentManager content;
//        public Vector2 clientBounds;
//        private int _numberOfButtons;
//        private SpriteFont _text;
//        private String _header;
//        private Vector2 _menuPosition;
//        private Vector2 _textPosition;
//        private Rectangle _buttonRect;
//        private int _buttonPositionX;
//        private int _buttonPositionY;
//        private Texture2D _buttonTexture;

//        private Texture2D _menuBack;

//        public StartMenu(ContentManager content, Vector2 clientBounds)
//        {
//            this.content = content;
//            this.clientBounds = clientBounds;
//            _numberOfButtons = 4;

//            _text = content.Load<SpriteFont>("Arial");
//            _menuBack = content.Load<Texture2D>("menuBack");
//            _buttonTexture = content.Load<Texture2D>("buttonBack");
//            _header = "Awesomeness";

//            _menuPosition = new Vector2((clientBounds.X / 2) - (_menuBack.Width / 2), (clientBounds.Y / 2) - (_menuBack.Height / 2));
//            _textPosition = new Vector2((_menuPosition.X + (_menuBack.Width / 2)) - (_text.MeasureString(_header).X / 2), 100);

//            _buttonPositionX = ((int)clientBounds.X / 2) - (_buttonTexture.Width / 2);
//            _buttonPositionY = _menuBack.Height / 2 - 50;


//            _buttonRect = new Rectangle(_buttonPositionX, (_buttonPositionY + 1 * (_buttonTexture.Height + 10)), _buttonTexture.Width, _buttonTexture.Height);

//            //for (int i = 0; i < _numberOfButtons; i++)
//            //{
//            //    _buttonRect = new Rectangle(_buttonPositionX, (_buttonPositionY + i * (_buttonTexture.Height + 10)), 
//            //        _buttonTexture.Width, _buttonTexture.Height);

//            //    MenuData button = new MenuData(_buttonTexture, _buttonRect);
//            //    button.ButtonText = "Halla";
//            //}


//        }
//    }
//}
