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
    public class Menu
    {
        private Rectangle _menuPosition;

        public SpriteBatch spriteBatch;
        public ContentManager content;

        public Rectangle ClientBounds { get; set; }
        public Texture2D MenuTexture { get; set; }
        public Color BackgroundColor { get; set; }
        public Rectangle MenuPosition { get; set; }
        public SpriteFont Font { get; set; }
        public bool IsBeingDrawn { get; set; }

        public Menu(SpriteBatch spriteBatch, ContentManager content, Rectangle clientBounds) 
        {
            this.spriteBatch = spriteBatch;
            this.content = content;
            MenuTexture = content.Load<Texture2D>("menuBack");
            BackgroundColor = Color.White;
            ClientBounds = clientBounds;
            Font = content.Load<SpriteFont>("Arial");

            _menuPosition = new Rectangle((ClientBounds.Width / 2) - (MenuTexture.Width / 2), 
                (ClientBounds.Height / 2) - (MenuTexture.Height / 2), MenuTexture.Width, MenuTexture.Height);
            MenuPosition = _menuPosition;
        }

        public virtual void Update(GameTime gameTime) 
        {}

        public virtual void Draw(GameTime gameTime) 
        {
            spriteBatch.Draw(MenuTexture, MenuPosition, BackgroundColor);
        }
    }
}