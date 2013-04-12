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
    /// <summary>
    /// Class that handles the sound effects in the game
    /// </summary>
    public class SoundEffects
    {
        private SoundEffect soundGameStart, soundGameOver, soundFoodSpawn;
        private ContentManager _content;
        private bool _isMute;
        private KeyboardState _previousKeyState;

        public SoundEffects(ContentManager content)
        {
            _content = content;
            soundGameOver = _content.Load<SoundEffect>("Sound//Effects//MinigunWindupAndFireLooped1");
            soundGameStart = _content.Load<SoundEffect>("Sound//Effects//fletcher_05");
            soundFoodSpawn = _content.Load<SoundEffect>("Sound//Effects//foodAppears");
            _isMute = false;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState _currentKeyState = Keyboard.GetState();

            if (_currentKeyState.IsKeyDown(Keys.J) && !_previousKeyState.IsKeyDown(Keys.J))
                _isMute = true;
            
            _previousKeyState = _currentKeyState;
        }

        public void PlayFoodSpawn()
        {
            if (!_isMute)
                soundFoodSpawn.Play();
        }

        public void PlaySoundGameOver()
        {
            if (!_isMute)
                soundGameOver.Play();
        }

        public void PlaySoundGameStart()
        {
            if (!_isMute)
             soundGameStart.Play();
        }
    }
}