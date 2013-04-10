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

namespace XNAInnlevering2
{
    public class DrawGame : DrawableGameComponent, IDrawSprites
    {
        private Game game;
        private SpriteBatch _spriteBatch;
        private ContentManager _content;


        public DrawGame(Game game) 
            : base(game)
        {
            this.game = game;
        }

        public void AddButton(Object obj)
        {

        }

        public void RemoveButton(Object obj) 
        {

        }
    }
}
