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

namespace Innlevering2
{
    public class DrawMenu : DrawableGameComponent, IDrawMenu
    {
        private SpriteBatch _spriteBatch;
        private int numberOfButtons;
        private SpriteFont _font;

        List<MenuData> _buttonList = new List<MenuData>();

        public DrawMenu(Game game) 
            :base(game)
        {

        }

        // Er protected siden metoden den overrrider er protected
        protected override void LoadContent() 
        {
            base.LoadContent();
            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            _font = Game.Content.Load<SpriteFont>("Arial");
            numberOfButtons = 4;
        }

        public void AddButton(MenuData button)
        {
            if (button == null || _buttonList.Contains(button) || _buttonList.Count > numberOfButtons)
            {
                Console.WriteLine("");
                return;
            }
            _buttonList.Add(button);
        }

        public void RemoveButton(MenuData button) 
        {
            _buttonList.Remove(button);
        }

        public override void Update(GameTime gameTime) 
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) 
        {
            base.Draw(gameTime);
            _spriteBatch.Begin();
            foreach (MenuData button in _buttonList)
            {
                DrawButton(button);
            }
            _spriteBatch.End();
        } 

        public void DrawButton(MenuData button) 
        {
            _spriteBatch.Draw(button.Texture, button.Destination, button.TextureBounds, button.ColorButton);
            _spriteBatch.DrawString(_font, button.ButtonText, button.TextPosition, button.ColorText);
        }
    }
}
