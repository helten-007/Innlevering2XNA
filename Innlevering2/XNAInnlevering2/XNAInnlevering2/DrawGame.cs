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

//namespace XNAInnlevering2
//{
//    public class DrawGame : DrawableGameComponent, IDrawSprites
//    {
//        private Game game;
//        private SpriteBatch _spriteBatch;
//        private ContentManager _content;
//        private Snake player1, player2;

//        public DrawGame(Game game)
//            : base(game)
//        {
//            this.game = game;
//        }

//        protected override void LoadContent()
//        {
//            base.LoadContent();
//            _content = Game.Content;
//            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
//            player1 = new Snake(_spriteBatch, _content, new Vector2(0, 0));

//        }

//        public void AddButton(Object obj)
//        {

//        }

//        public void RemoveButton(Object obj)
//        {

//        }

//        public override void Update(GameTime gameTime)
//        {
//            base.Update(gameTime);
//            player1.Update(gameTime);
//        }

//        public override void Draw(GameTime gameTime)
//        {
//            base.Draw(gameTime);
//            player1.Draw(gameTime);
//        }
//    }
//}
