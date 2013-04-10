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
    public static class Map
    {
        public const int _squareSize = 40;
        public const int _squareHalfSize = _squareSize / 2;
        int MaxColumn = 800 / _squareSize;
        int MaxRow = 480 / _squareSize;


        public static Vector2 PointToVector2(Point p)   
        {
            return new Vector2(p.X * _squareSize + _squareHalfSize, p.Y * _squareSize + _squareHalfSize);
        }

        public static void DrawSprite(SpriteBatch spriteBatch, Texture2D texture, Point point, float rotation)
        {
            float spriteSize = (float)Math.Max(texture.Width, texture.Height);
            Vector2 origin = new Vector2(texture.Width / 2f, texture.Height / 2f);
            spriteBatch.Draw(texture, PointToVector2(point), null, Color.White, rotation, origin, _squareSize / spriteSize, SpriteEffects.None, 0);
        }
    }
}
