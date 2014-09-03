using System;
using System.Timers;
using Ptolemy.UserInterface.Enums;

namespace Ptolemy.UserInterface.Models
{
    internal class AnimationModel : IDisposable
    {
        #region Class Variables
        private const int TargetFramesPerSecond = 30;
        private const int MillisecondsInSecond = 1000; // 1 thousand
        private const int TicksInSecond = 10000000; // 10 million
        private const int MillisecondsPerFrame = MillisecondsInSecond / TargetFramesPerSecond;
        private const int TicksPerFrame = TicksInSecond / TargetFramesPerSecond;
        #endregion

        #region Member Variables

        private readonly SolarSystem.SolarSystem _solarSystem;
        private readonly Timer _timer;

        /// <summary>
        /// Time as it passes for us.
        /// </summary>
        private int _realTimeSteps = 1;
        private TimeUnit _realTimeUnit = TimeUnit.Minute;

        /// <summary>
        /// Time as it passes for Ptolemy's heavens.
        /// </summary>
        private int _simulatedTimeSteps = 1;
        private TimeUnit _simulatedTimeUnit = TimeUnit.Year;

        private DateTime _timeOfLastFrame;

        #endregion

        #region Constructors

        public AnimationModel(SolarSystem.SolarSystem solarSystem)
        {
            _solarSystem = solarSystem;

            // Create a timer which fires TargetFps times per second and is paused initially.
            _timer = new Timer(interval: MillisecondsPerFrame);
            _timer.AutoReset = true;
            _timer.Enabled = false;
            _timer.Elapsed += AdvanceTime;
        }

        #endregion

        #region Public Interface

        internal event Action TimeAdvanced;

        internal bool IsRunning
        {
            get { return _timer.Enabled; }
        }

        internal void Start()
        {
            if (!_timer.Enabled)
            {
                _timeOfLastFrame = DateTime.Now;
                _timer.Enabled = true;
            }
        }

        internal void Pause()
        {
            _timer.Enabled = false;
        }

        internal void SetRealTimeSteps(int timeSteps)
        {
            _realTimeSteps = timeSteps;
        }

        internal int GetRealTimeSteps()
        {
            return _realTimeSteps;
        }

        internal void SetSimulatedTimeSteps(int timeSteps)
        {
            _simulatedTimeSteps = timeSteps;
        }

        internal int GetSimulatedTimeSteps()
        {
            return _simulatedTimeSteps;
        }

        internal void SetRealTimeUnit(TimeUnit timeUnit)
        {
            _realTimeUnit = timeUnit;
        }

        internal TimeUnit GetRealTimeUnit()
        {
            return _realTimeUnit;
        }

        internal void SetSimulatedTimeUnit(TimeUnit timeUnit)
        {
            _simulatedTimeUnit = timeUnit;
        }

        internal TimeUnit GetSimulatedTimeUnit()
        {
            return _simulatedTimeUnit;
        }

        #endregion

        #region Overridden Methods

        public void Dispose()
        {
            _timer.Dispose();
        }

        #endregion

        #region Private Helpers

        private void OnTimeAdvanced()
        {
            if (TimeAdvanced != null)
            {
                TimeAdvanced();
            }
        }

        private void AdvanceTime(object state, ElapsedEventArgs e)
        {
            _timer.AutoReset = false;

            // Get a fraction of 1 (the delta) indicating how much of the expected movement to apply.
            // Adjusts for discrepencies in Timer's measurement between fires.
            long ticksElapsed = e.SignalTime.Ticks - _timeOfLastFrame.Ticks;
            double timerDelta = (((double) ticksElapsed) / TicksPerFrame);

            // Set the last frame time to be now
            _timeOfLastFrame = DateTime.Now;
            
            // Move the simulation forward a percentage of the target number of simulated ticks in a frame
            long ticksToAdvancePlanets = (long)(timerDelta * this.GetSimulatedTicksPerFrame());

            // Move the animation forward
            _solarSystem.AdvanceCurrentTime(ticks: ticksToAdvancePlanets);

            // Trigger the event
            this.OnTimeAdvanced();

            _timer.AutoReset = true;
        }

        private long GetSimulatedTicksPerFrame()
        {
            if (RealSeconds == 0)
            {
                return 0;
            }

            // This ratio, although calculated using seconds, is true for any time unit, including ticks.
            double simulatedTicksPerRealTick = ((double) SimulatedSeconds) / RealSeconds;

            long simulatedTicksPerFrame = (long)(simulatedTicksPerRealTick * TicksPerFrame);

            return simulatedTicksPerFrame;
        }

        private long RealSeconds
        {
            get { return _realTimeSteps * (int) _realTimeUnit;  }
        }

        private long SimulatedSeconds
        {
            get { return _simulatedTimeSteps * (int) _simulatedTimeUnit; }
        }

        #endregion
    }
}
