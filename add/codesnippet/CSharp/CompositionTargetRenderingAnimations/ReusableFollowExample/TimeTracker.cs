namespace Microsoft.Samples.PerFrameAnimations
{
    using System;
    using System.Windows; //uielement
    using System.Windows.Media; //visual operations
    using System.Windows.Media.Animation; //animation effect stuff

    public class TimeTracker
    {
        #region Private Members
        private Timeline _timeline;
        private Clock _timeClock;
        private TimeSpan? _lastTime;
        private double _deltaTime;
        private double _timerInterval = -1; 
        #endregion

        #region Properties
        
        public double TimerInterval
        {
            get
            {
                return _timerInterval;
            }
            set
            {
                _timerInterval = value;
            }
        }

        public TimeSpan ElapsedTime
        {
            get
            {
                if (_lastTime.HasValue)
                    return _lastTime.Value;
                else
                    return new TimeSpan(0);
            }
        }

        public double DeltaSeconds
        {
            get
            {
                return _deltaTime;
            }
        }

        #endregion

        #region Events
        public event EventHandler TimerFired; 
        #endregion

        #region Constructors
        public TimeTracker()
        {
            _timeline = new ParallelTimeline(null, Duration.Forever);
            _timeClock = _timeline.CreateClock();
            _timeClock.Controller.Begin();
            _lastTime = TimeSpan.FromSeconds(0);
        } 
        #endregion

        public double Update()
        {
            TimeSpan? currentTime = _timeClock.CurrentTime;

            //we're working with nullables, so just to be safe we should check for values
            if (currentTime.HasValue && _lastTime.HasValue)
            {
                //get the difference in time
                TimeSpan diffTime = currentTime.Value - _lastTime.Value;
                _deltaTime = diffTime.TotalSeconds;

                //does the user want a callback on regular intervals?
                if (_timerInterval > 0.0)
                {
                    //compute the intervals for this and previous update
                    int currInterval = (int)(currentTime.Value.TotalSeconds / _timerInterval);
                    int prevInterval = (int)(_lastTime.Value.TotalSeconds / _timerInterval);

                    //has the interval changed since last update?
                    if (currInterval != prevInterval)
                    {
                        //fire interval event
                        //note that this will only be called once per frame at most
                        // so if they interval is too small, you wont get 2+ fires per frame
                        TimerFired(this, null);
                    }
                }
            }

            //cycle old time
            _lastTime = currentTime;
            
            return _deltaTime;
        }
    }

}