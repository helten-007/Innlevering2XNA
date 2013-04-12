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
    /// Class that handles the background music in the game
    /// </summary>
    public class BackgroundMusic
    {
        private KeyboardState _previousKeyState;
        private bool songIsPlaying;

        public BackgroundMusic()
        {
            ///Gathers songs from the users computer
            ///Three example songs is located within the project in Content//Audio//Music
            MediaLibrary library = new MediaLibrary();
            SongCollection songs = library.Songs;
            Song song = songs[0];
            MediaPlayer.Play(songs);
            songIsPlaying = true;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState _currentKeyState = Keyboard.GetState();

            if (_currentKeyState.IsKeyDown(Keys.M) && !_previousKeyState.IsKeyDown(Keys.M))
            {
                if (!songIsPlaying)
                {
                    MediaPlayer.Resume();
                    songIsPlaying = true;
                }
                else
                {
                    MediaPlayer.Pause();
                    songIsPlaying = false;
                }
            }

            if (_currentKeyState.IsKeyDown(Keys.N) && !_previousKeyState.IsKeyDown(Keys.N))
            {
                MediaPlayer.MoveNext();
            }

            if (_currentKeyState.IsKeyDown(Keys.P) && !_previousKeyState.IsKeyDown(Keys.P))
            {
                MediaPlayer.Volume += 0.1f;
                Console.WriteLine(MediaPlayer.Volume);
            }

            if (_currentKeyState.IsKeyDown(Keys.O) && !_previousKeyState.IsKeyDown(Keys.O))
            {
                MediaPlayer.Volume -= 0.1f;
                Console.WriteLine(MediaPlayer.Volume);
            }
            _previousKeyState = _currentKeyState;
        }
    }
}