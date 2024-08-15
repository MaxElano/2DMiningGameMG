using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMiningGameMG
{
    internal class Timer
    {
        private float timerDurationMil;
        private float timerCurrentTimeMil;
        private bool active;
        private bool repeat;
        private Action finishAction;
        public bool Finished { get; private set; }

        public Timer(float durationSec, Action func, bool repeat = true, bool active = true) 
        {
            this.timerDurationMil = durationSec * 1000;
            this.active = active;
            this.repeat = repeat;
            this.finishAction = func;
        }

        public void Update(GameTime gameTime)
        {
            if(active && timerCurrentTimeMil > 0)
            {
                timerCurrentTimeMil -= gameTime.ElapsedGameTime.Milliseconds;
                if (timerCurrentTimeMil <= 0)
                {
                    Finished = true;
                    finishAction();
                }
            }

            else if(repeat && timerCurrentTimeMil <= 0) 
            {
                timerCurrentTimeMil = timerDurationMil;
            }
        }

        public void SetTimerDuration(float timerDurationSec)
        {
            this.timerDurationMil = timerDurationSec * 1000;
        }

        public void ResetTimer()
        {
            timerCurrentTimeMil = timerDurationMil;
        }

        public void StartTimer()
        {
            active = true;
        }

        public void StopTimer() 
        { 
            active = false;
        }

        public void ToggleRepeat()
        {
            repeat = !repeat;
        }

        public float RemainingTime()
        {
            return timerCurrentTimeMil / 1000;
        }
    }
}
