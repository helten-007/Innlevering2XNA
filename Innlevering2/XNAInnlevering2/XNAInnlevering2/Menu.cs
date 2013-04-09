﻿using System;
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
    public class Menu
    {
        private Rectangle _menuPosition;

        public SpriteBatch spriteBatch;
        public ContentManager content;
        public Game game;
        public MouseState _currentMouseState, _previousMouseState;
        public Rectangle _mouseRect;

        public Rectangle ClientBounds { get; set; }
        public Texture2D MenuTexture { get; set; }
        public Color BackgroundColor { get; set; }
        public Rectangle MenuPosition { get; set; }
        public SpriteFont Font { get; set; }
        public bool IsBeingDrawn { get; set; }

        public Menu(Game game, SpriteBatch spriteBatch, ContentManager content) 
        {
            this.spriteBatch = spriteBatch;
            this.content = content;
            this.game = game;
            MenuTexture = content.Load<Texture2D>("menuBack");
            BackgroundColor = Color.White;
            ClientBounds = game.Window.ClientBounds;
            Font = content.Load<SpriteFont>("Arial");

            _menuPosition = new Rectangle((ClientBounds.Width / 2) - (MenuTexture.Width / 2), 
                (ClientBounds.Height / 2) - (MenuTexture.Height / 2), MenuTexture.Width, MenuTexture.Height);
            MenuPosition = _menuPosition;
        }

        public virtual void Update(GameTime gameTime) 
        {
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
            _mouseRect = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 5, 5);

            if (IsBeingDrawn)
                MenuPosition = _menuPosition;
        }

        public virtual void Draw(GameTime gameTime) 
        {
            spriteBatch.Draw(MenuTexture, MenuPosition, BackgroundColor);
        }

        public bool IsMousePressed()
        {
            return _currentMouseState.LeftButton == ButtonState.Released &&
                _previousMouseState.LeftButton == ButtonState.Pressed;
        }
    }
}