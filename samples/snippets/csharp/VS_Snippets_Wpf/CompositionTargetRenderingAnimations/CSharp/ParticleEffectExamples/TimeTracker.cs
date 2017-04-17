namespace Microsoft.Samples.PerFrameAnimations
{
    using System;
    using System.Windows; //uielement
    using System.Windows.Media; //visual operations
    using System.Windows.Media.Animation; //animation effect stuff

    public class TimeTracker
    {
        #region Private Memebers

        private DateTime _lastTime;
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

        public DateTime ElapsedTime
        {
            get
            {
                return _lastTime;
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

            _lastTime = DateTime.Now;
        } 
        #endregion

        public double Update()
        {
        
            
            DateTime currentTime = DateTime.Now;

                
            //get the difference in time
            TimeSpan diffTime = currentTime - _lastTime;
            _deltaTime = diffTime.TotalSeconds;
            


                //does the user want a callback on regular intervals?
                if (_timerInterval > 0.0)
                {
                    
                    /*
                    //compute the intervals for this and previous update
                    int currInterval = (int)(currentTime / TimeSpan.FromSeconds(_timerInterval));
                    int prevInterval = (int)(_lastTime / TimeSpan.FromSeconds(_timerInterval));

                    //has the interval changed since last update?
                    if (currInterval != prevInterval)
                    {
                        //fire interval event
                        //note that this will only be called once per frame at most
                        // so if they interval is too small, you wont get 2+ fires per frame
                        TimerFired(this, null);
                    } */
                    
                    if (currentTime != _lastTime)
                    {
                        TimerFired(this, null);
                    }
                   
                }
                

            //cycle old time
            _lastTime = currentTime;
            
            return _deltaTime;
        }
    }

}