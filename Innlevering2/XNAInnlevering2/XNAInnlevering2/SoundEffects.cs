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

        public SoundEffects(ContentManager content)
        {
            _content = content;
            soundGameOver = _content.Load<SoundEffect>("Audio\\Effects\\Applause");
            soundGameStart = _content.Load<SoundEffect>("Audio\\Effects\\Air Horn");
            soundFoodSpawn = _content.Load<SoundEffect>("Audio\\Effects\\Door Bell");
        }

        public void PlayFoodSpawn()
        {
            soundFoodSpawn.Play();
        }

        public void PlaySoundGameOver()
        {
            soundGameOver.Play();
        }

        public void PlaySoundGameStart()
        {
            soundGameStart.Play();
        }
    }
}