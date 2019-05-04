using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpidaLib.Util
{
    interface ITimer
    {
        void ResetTimer();
        void PlayTimerContinuous(float timerinseconds);
        void PlayTimerOnce(float timerinseconds);
    }
    public class Timer : ITimer
    {
        enum TimerState { Play, Stop, Reset };

        private float CurrentTime;
        private float SecondsTimer;
        /// <summary>
        /// Time is up.
        /// </summary>
        private bool istimeup;
        public bool IsTimeUp { get { return istimeup; } }
        public Timer()
        {
            CurrentTime = 0;
            SecondsTimer = 0;
        }
        /// <summary>
        /// Activates different states of a timer.
        /// </summary>
        /// <param name="timerState">Timer State.</param>
        private void ActivateTimerType(TimerState timerState)
        {
            switch (timerState)
            {
                case TimerState.Play:
                    CurrentTime += Time.deltaTime;
                    break;
                case TimerState.Stop:
                    if (!istimeup)
                    {
                        istimeup = true;
                    }
                    break;
                case TimerState.Reset:
                    CurrentTime = 0;
                    istimeup = false;
                    break;
            }
        }
        public void ResetTimer()
        {
            ActivateTimerType(TimerState.Reset);
        }
        /// <summary>
        /// Plays the timer once.
        /// </summary>
        /// <param name="seconds">Seconds before timer ends</param>
        public void PlayTimerOnce(float seconds)
        {
            SecondsTimer = seconds;
            if (CurrentTime < SecondsTimer)
            {
                ActivateTimerType(TimerState.Play);
            }
            else
            {
                ActivateTimerType(TimerState.Stop);
            }
        }
        /// <summary>
        /// Plays the timer continuous.
        /// </summary>
        /// <param name="seconds">Seconds before timer restarts</param>
        public void PlayTimerContinuous(float seconds)
        {
            SecondsTimer = seconds;
            if (CurrentTime < SecondsTimer)
            {
                ActivateTimerType(TimerState.Play);
            }
            else if (!istimeup && CurrentTime >= SecondsTimer)
            {
                istimeup = true;
            }
            else if (istimeup && CurrentTime >= SecondsTimer)
            {
                ActivateTimerType(TimerState.Reset);
                ActivateTimerType(TimerState.Play);
            }
        }
        
        public override string ToString()
        {
            return string.Format("Current Time: {0}", CurrentTime);
        }
    }
}
