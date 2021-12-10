﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirdJYSP
{
    public class CollisionManager : GameComponent
    {

        private Bird bird;
        private Pipe pipe1;
        private PipeDown pipe2;
        private Enemy enemy1;
        private Enemy enemy2;
        private Score score;
        private SoundEffect losingSound, pointUpSound;


        //private SoundEffect hitSound;
        public CollisionManager(Game game,
            Bird bird,
            Pipe pipe1,
            PipeDown pipe2,
            Enemy enemy1,
            Enemy enemy2,
            Score score,
           SoundEffect losingSound,
           SoundEffect pointUpSound) : base(game)
        {
            this.bird = bird;
            this.pipe1 = pipe1;
            this.pipe2 = pipe2;
            this.enemy1 = enemy1;
            this.enemy2 = enemy2;
            this.score = score;
            this.losingSound = losingSound;
            this.pointUpSound = pointUpSound;

        }

        public override void Update(GameTime gameTime)
        {
            Rectangle birdRec = bird.getBirdBounds();
            Rectangle bulletRec = bird.getBulletBounds();
            Rectangle pipe1Rec = pipe1.getBounds();
            Rectangle pipe2Rec = pipe2.getBounds();
            Rectangle enemy1Rec = enemy1.getBounds();
            Rectangle enemy2Rec = enemy2.getBounds();

            //palyer bird collides  with enemy bird
            if (birdRec.Intersects(enemy1Rec) && enemy1.Visible || birdRec.Intersects(enemy2Rec) && enemy2.Visible)
            {
                var instance = losingSound.CreateInstance();
                instance.Volume = 0.8f;
                instance.Play();
                bird.Enabled = false;
                bird.Visible = false;
                pipe1.Enabled = false;
                pipe1.Visible = false;
                pipe2.Enabled = false;
                pipe2.Visible = false;
                enemy1.Enabled = false;
                enemy1.Visible = false;
                enemy2.Enabled = false;
                enemy2.Visible = false;
            }

            //palyer bird collides  with pipe1
            if (birdRec.Intersects(pipe1Rec) && pipe1.Visible)
            {
                var instance = losingSound.CreateInstance();
                instance.Volume = 0.5f;
                instance.Play();
                bird.Enabled = false;
                bird.Visible = false;
                pipe1.Enabled = false;
                pipe1.Visible = false;
                pipe2.Enabled = false;
                pipe2.Visible = false;
                enemy1.Enabled = false;
                enemy1.Visible = false;
                enemy2.Enabled = false;
                enemy2.Visible = false;
            }
            //palyer bird collides  with pipe2
            if (birdRec.Intersects(pipe2Rec) && pipe2.Visible)
            {
                var instance = losingSound.CreateInstance();
                instance.Volume = 0.5f;
                instance.Play();
                bird.Enabled = false;
                bird.Visible = false;
                pipe1.Enabled = false;
                pipe1.Visible = false;
                pipe2.Enabled = false;
                pipe2.Visible = false;
                enemy1.Enabled = false;
                enemy1.Visible = false;
                enemy2.Enabled = false;
                enemy2.Visible = false;
            }

            //bullet collides with enemy bird
            if (bulletRec.Intersects(enemy1Rec) && enemy1.Visible)
            {
                var instance = pointUpSound.CreateInstance();
                instance.Volume = 0.5f;
                instance.Play();
                score.CurrentScore++;
                enemy1.Visible = false;
            }
            //bullet collides with enemy bird
            if (bulletRec.Intersects(enemy2Rec) && enemy2.Visible)
            {
                var instance = pointUpSound.CreateInstance();
                instance.Volume = 0.5f;
                instance.Play();
                score.CurrentScore++;
                enemy2.Visible = false;
            }

            if (pipe1Rec.X <= 0)
            {
                score.CurrentScore++;
            }
            if (pipe2Rec.X <= 0)
            {
                score.CurrentScore++;
            }


            base.Update(gameTime);
        }
    }
}
