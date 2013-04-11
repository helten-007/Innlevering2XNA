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

        private ContentManager Content;



        public SoundEffects(ContentManager content)
        {
            Content = content;

            soundGameOver = Content.Load<SoundEffect>("Audio\\Effects\\Applause");
            soundGameStart = Content.Load<SoundEffect>("Audio\\Effects\\Air Horn");
            soundFoodSpawn = Content.Load<SoundEffect>("Audio\\Effects\\Door Bell");
        }

        public void Update(GameTime gameTime)
        {

        }


        public void playFoodSpawn()
        {
            soundFoodSpawn.Play();
        }

        public void playSoundGameOver()
        {
            soundGameOver.Play();
        }

        public void playSoundGameStart()
        {
            soundGameStart.Play();
        }

    }

}
