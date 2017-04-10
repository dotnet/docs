namespace Microsoft.Samples.PerFrameAnimations
{
    using System;
    using System.Windows; //uielement
    using System.Windows.Media; //visual operations
    using System.Windows.Media.Animation;
    using System.Windows.Controls;
    using System.Collections.Generic;
    using System.Windows.Input;

    public class SonicEffect : OverlayRenderDecorator
    {
        #region Private Members

        private TimeTracker _timeTracker;
        private int _ringCount = 5;
        private double _ringDelayInSeconds = 0.1;
        private double _ringRadius = 7.0;
        private double _ringThickness = 5.0;
        private Color _ringColor = Color.FromArgb(128, 128, 128, 128);
        private Point _clickPosition;
        private int _lowerRing, _upperRing;

        #endregion

        #region Properties
        public int RingCount
        {
            get
            {
                return _ringCount;
            }
            set
            {
                _ringCount = (int)value;
            }
        }

        public TimeSpan RingDelay
        {
            get
            {
                return TimeSpan.FromSeconds(_ringDelayInSeconds);
            }
            set
            {
                _ringDelayInSeconds = ((TimeSpan)value).TotalSeconds;
            }
        }

        public double RingRadius
        {
            get
            {
                return _ringRadius;
            }
            set
            {
                _ringRadius = (double)value;
            }
        }

        public double RingThickness
        {
            get
            {
                return _ringThickness;
            }
            set
            {
                _ringThickness = (double)value;
            }
        }

        public Color RingColor
        {
            get
            {
                return _ringColor;
            }
            set
            {
                _ringColor = (Color)value;
            }
        } 
        #endregion

        public SonicEffect()
        {
        }

        protected override void OnAttachChild(UIElement child)
        {
             child.PreviewMouseLeftButtonUp += OnMouseLeftButtonUp;
        }

        protected override void OnDetachChild(UIElement child)
        {
            CompositionTarget.Rendering -= OnFrameCallback;

            child.PreviewMouseLeftButtonUp -= OnMouseLeftButtonUp;
            _timeTracker = null;
        }


        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_timeTracker != null)
            {
                _timeTracker.TimerFired -= OnTimerFired;
                _timeTracker = null;
            }

            CompositionTarget.Rendering += OnFrameCallback;
            _timeTracker = new TimeTracker();
            _timeTracker.TimerInterval = _ringDelayInSeconds;
            _timeTracker.TimerFired += OnTimerFired;
            _lowerRing = _upperRing = 0;
            _clickPosition = e.GetPosition(this);
        }

        private void OnFrameCallback(object sender, EventArgs e)
        {
            if (_timeTracker != null)
            {
                _timeTracker.Update();
                InvalidateVisual();
            }
        }

        private void OnTimerFired(object sender, EventArgs e)
        {
            if (_upperRing < _ringCount)
            {
                _upperRing++;
            }
            else
            {
                _lowerRing++;
                if (_lowerRing >= _upperRing)
                {
                    _timeTracker.TimerFired -= OnTimerFired;
                    _timeTracker = null;
                    CompositionTarget.Rendering -= OnFrameCallback;
                }
            }
            
        }

        protected override void OnOverlayRender(DrawingContext dc)
        {
            if (_timeTracker != null)
            {
                for (int i = _lowerRing; i < _upperRing; i++)
                {
                    double radius = _ringRadius * (i + 1);
                    dc.DrawEllipse(Brushes.Transparent, new Pen(new SolidColorBrush(_ringColor), _ringThickness), _clickPosition, radius, radius);
                }
            }
        }
    }
}