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
    public class Movement
    {
        KeyboardState _previousKeyState;
        int movementSpeed = 10;
        Vector2 snake1Position;
        Vector2 snake2Position;

        public void Update(GameTime gameTime)
        {
            KeyboardState _currentKeyState = Keyboard.GetState();
            UpdateMovement(_currentKeyState);
            _previousKeyState = _currentKeyState;
            snake1Position = new Vector2(200, 240);
            snake2Position = new Vector2(600, 240);
            snake1Position.X++;
            snake2Position.X--;
        }

        private void UpdateMovement(KeyboardState _currentKeyState)
        {
            if (_currentKeyState.IsKeyDown(Keys.A) == true)
                snake1Position.X -= movementSpeed;

            if (_currentKeyState.IsKeyDown(Keys.D) == true)
                snake1Position.X += movementSpeed;

            if (_currentKeyState.IsKeyDown(Keys.W) == true)
                snake1Position.Y += movementSpeed;

            if (_currentKeyState.IsKeyDown(Keys.S) == true)
                snake1Position.Y -= movementSpeed;

            if (_currentKeyState.IsKeyDown(Keys.Left) == true)
                snake2Position.X -= movementSpeed;

            if (_currentKeyState.IsKeyDown(Keys.Right) == true)
                snake2Position.X += movementSpeed;
            
            if (_currentKeyState.IsKeyDown(Keys.Up) == true)
                snake2Position.Y += movementSpeed;

            if (_currentKeyState.IsKeyDown(Keys.Down) == true)
                snake2Position.Y -= movementSpeed;

            while (_currentKeyState.IsKeyDown(Keys.Space) == true)
            {
                movementSpeed *= 2;
            }
        }
    }
}