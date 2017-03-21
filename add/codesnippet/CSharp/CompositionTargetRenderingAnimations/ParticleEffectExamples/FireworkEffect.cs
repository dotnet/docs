namespace Microsoft.Samples.PerFrameAnimations
{
    using System;
    using System.Windows; //uielement
    using System.Windows.Media; //visual operations
    using System.Windows.Media.Animation; //animation effect stuff
    using System.Windows.Controls; //LayoutOverrideDecorator
    using System.Collections.Generic;
    using System.Windows.Input;
    using System.Security.Permissions;

    internal class Particle
    {
        public Point Location;
        public Vector Velocity;
        public DateTime LifeTime;
        public DateTime DeathTime;
        public Color StartColor;
        public Color EndColor;
        public double Diameter;
    }

    public class FireworkEffect : OverlayRenderDecorator
    {
        private List<Particle> _particles = new List<Particle>();
        protected Random _random = new Random();
        private bool _bounceOffContainer = false;
        private Vector _gravity = new Vector(0.0, 10.0);
        private bool _gravitateToMouse = false;
        private double _gravitateScale = 0.1;

        private bool _mouseDropsParticles = false;
        private double _secondsUntilDrop = 0;
        private Point _lastMousePosition = new Point(0, 0);

        private TimeTracker _timeTracker;


        #region Dependency Properties
        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register(
                "RadiusBase",
                typeof(double),
                typeof(FireworkEffect),
                new FrameworkPropertyMetadata(15.0)
            );

        public static readonly DependencyProperty RadiusVariationProperty =
            DependencyProperty.Register(
                "RadiusVariation",
                typeof(double),
                typeof(FireworkEffect),
                new FrameworkPropertyMetadata(5.0)
            );

        public static readonly DependencyProperty StartColorProperty =
            DependencyProperty.Register(
                "StartColor",
                typeof(Color),
                typeof(FireworkEffect),
                new FrameworkPropertyMetadata(Color.FromArgb(245, 200, 50, 20))
            );
        public static readonly DependencyProperty EndColorProperty =
            DependencyProperty.Register(
                "EndColor",
                typeof(Color),
                typeof(FireworkEffect),
                new FrameworkPropertyMetadata(Color.FromArgb(100, 200, 255, 20))
            );

        public static readonly DependencyProperty StartColorVariationProperty =
            DependencyProperty.Register(
                "StartColorVariation",
                typeof(Color),
                typeof(FireworkEffect),
                new FrameworkPropertyMetadata(Color.FromArgb(10, 55, 50, 20))
            );

        public static readonly DependencyProperty EndColorVariationProperty =
            DependencyProperty.Register(
                "EndColorVariation",
                typeof(Color),
                typeof(FireworkEffect),
                new FrameworkPropertyMetadata(Color.FromArgb(50, 20, 100, 20))
            );

        public static readonly DependencyProperty MouseDropDelayProperty =
           DependencyProperty.Register(
               "MouseDropDelay",
               typeof(double),
               typeof(FireworkEffect),
               new FrameworkPropertyMetadata(0.1)
           );

        public static readonly DependencyProperty MouseDropDelayVariationProperty =
           DependencyProperty.Register(
               "MouseDropDelayVariation",
               typeof(double),
               typeof(FireworkEffect),
               new FrameworkPropertyMetadata(0.05)
           );

        public static readonly DependencyProperty ClickBurstSizeProperty =
            DependencyProperty.Register(
                "ClickBurstSize",
                typeof(int),
                typeof(FireworkEffect),
                new FrameworkPropertyMetadata(30)
            ); 
        #endregion

        #region Properties
        public double Radius
        {
            get
            {
                return (double)GetValue(RadiusProperty);
            }
            set
            {

                SetValue(RadiusProperty, value);
            }
        }

        public double RadiusVariation
        {
            get
            {
                return (double)GetValue(RadiusVariationProperty);
            }
            set
            {

                SetValue(RadiusVariationProperty, value);
            }
        }

        public Color StartColor
        {
            get
            {
                return (Color)GetValue(StartColorProperty);
            }
            set
            {

                SetValue(StartColorProperty, value);
            }
        }

        public Color EndColor
        {
            get
            {
                return (Color)GetValue(EndColorProperty);
            }
            set
            {

                SetValue(EndColorProperty, value);
            }
        }

        public Color StartColorVariation
        {
            get
            {
                return (Color)GetValue(StartColorVariationProperty);
            }
            set
            {

                SetValue(StartColorVariationProperty, value);
            }
        }

        public Color EndColorVariation
        {
            get
            {
                return (Color)GetValue(EndColorVariationProperty);
            }
            set
            {

                SetValue(EndColorVariationProperty, value);
            }
        }


        public bool BounceOffContainer
        {
            get { return _bounceOffContainer; }
            set { _bounceOffContainer = value; }
        }

        public bool GravitateToMouse
        {
            get { return _gravitateToMouse; }
            set
            {
                _gravitateToMouse = value;
            }
        }

        public double GravitateScale
        {
            get { return _gravitateScale; }
            set { _gravitateScale = value; }
        }

        public bool MouseDropsParticles
        {
            get { return _mouseDropsParticles; }
            set { _mouseDropsParticles = value; }
        }

        public double MouseDropDelay
        {
            get
            {
                return (double)GetValue(MouseDropDelayProperty);
            }
            set
            {

                SetValue(MouseDropDelayProperty, value);
            }
        }

        public double MouseDropDelayVariation
        {
            get
            {
                return (double)GetValue(MouseDropDelayVariationProperty);
            }
            set
            {

                SetValue(MouseDropDelayVariationProperty, value);
            }
        }

        public int ClickBurstSize
        {
            get
            {
                return (int)GetValue(ClickBurstSizeProperty);
            }
            set
            {

                SetValue(ClickBurstSizeProperty, value);
            }
        } 
        #endregion


        public FireworkEffect()
            : base()
        {

        }

        protected override void OnAttachChild(UIElement child)
        {
            CompositionTarget.Rendering += OnFrameCallback;

            child.PreviewMouseLeftButtonUp += OnMouseLeftButtonUp;
            child.PreviewMouseMove += OnMouseMove;

            _timeTracker = new TimeTracker();

        }

        protected override void OnDetachChild(UIElement child)
        {
            CompositionTarget.Rendering -= OnFrameCallback;

            child.PreviewMouseLeftButtonUp -= OnMouseLeftButtonUp;
            child.PreviewMouseMove -= OnMouseMove;

            _timeTracker = null;
        }

        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        protected void OnFrameCallback(object sender, EventArgs e)
        {
            UpdateParticles(_timeTracker.Update());
        }

        private void UpdateParticles(double deltatime)
        {
            //drop particles from mouse position
            if (_mouseDropsParticles && IsMouseOver)
            {
                _secondsUntilDrop -= deltatime;
                if (_secondsUntilDrop < 0.0)
                {
                    AddRandomBurst(_lastMousePosition - new Vector(Radius / 2.0, Radius / 2.0), 1);
                    _secondsUntilDrop = MouseDropDelay + (_random.NextDouble() * 2.0 - 1.0) * MouseDropDelayVariation;
                }
            }

            if (_particles.Count > 0)
                InvalidateVisual();

            //update all particles
            for (int i = 0; i < _particles.Count; )
            {
                //_particles[i]
                Particle p = _particles[i];

                if (_gravitateToMouse)
                {
                    p.Velocity += (_lastMousePosition - p.Location) * _gravitateScale;
                }
                else
                {
                    p.Velocity += _gravity;
                }
                p.Location += p.Velocity * deltatime;

                if (_bounceOffContainer)
                {
                    double radius = p.Diameter/2.0;
                    if (p.Location.X - radius < 0.0)
                    {
                        p.Location.X = radius;
                        p.Velocity.X *= -0.9;
                    }
                    else if (p.Location.X > ActualWidth - radius)
                    {
                        p.Location.X = ActualWidth - radius;
                        p.Velocity.X *= -0.9;
                    }
                    if (p.Location.Y - radius < 0.0)
                    {
                        p.Location.Y = radius;
                        p.Velocity.Y *= -0.9;
                    }
                    else if (p.Location.Y > ActualHeight - radius)
                    {
                        p.Location.Y = ActualHeight - radius;
                        p.Velocity.Y *= -0.9;
                    }
                }

                //only increment counter for live particles
                if (_timeTracker.ElapsedTime > p.DeathTime)
                    _particles.RemoveAt(i);
                else
                    i++;
            }

        }

        protected override void OnOverlayRender(DrawingContext drawingContext)
        {
            for (int i = 0; i < _particles.Count; i++)
            {
                Particle p = _particles[i];

                //figure out where in the particles life we are
                double particlelife = (_timeTracker.ElapsedTime - p.LifeTime).TotalSeconds / (p.DeathTime - p.LifeTime).TotalSeconds;
                Color currentcolor = Color.Multiply(p.StartColor, (float)(1.0 - particlelife)) + Color.Multiply(p.EndColor, (float)particlelife);
                Brush brush = new RadialGradientBrush(currentcolor, Color.FromArgb(0, currentcolor.R,currentcolor.G,currentcolor.B));
                
                RectangleGeometry rect = new RectangleGeometry(new Rect(new Point(p.Location.X - p.Diameter / 2.0,p.Location.Y - p.Diameter / 2.0), new Size(p.Diameter,p.Diameter)));
                drawingContext.DrawGeometry(brush, null, rect);
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            _lastMousePosition = e.GetPosition(this);
        }

        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddRandomBurst(e.GetPosition(this));
        }

        public void AddRandomBurst()
        {

            Point point = new Point(_random.NextDouble() * ActualWidth, _random.NextDouble() * ActualHeight);
            AddRandomBurst(point, ClickBurstSize);
        }

        public void AddRandomBurst(Point location)
        {
            AddRandomBurst(location, ClickBurstSize);
        }

        public void AddRandomBurst(Point location, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Particle p = new Particle();

                double radius = Radius + (_random.NextDouble() * 2.0 - 1.0) * RadiusVariation;
                double lifetime = _random.NextDouble() * 3.0 + 1.0;

                p.Location = location;
                p.Velocity = new Vector(_random.NextDouble() * 200.0 - 100.0, _random.NextDouble() * -200 + 100.0);
                p.LifeTime = _timeTracker.ElapsedTime;
                p.DeathTime = _timeTracker.ElapsedTime + TimeSpan.FromSeconds(lifetime);
                p.Diameter = 2.0 * radius;

                Color startColor = StartColor;
                Color startColorVariation = StartColorVariation;
                Color endColor = EndColor;
                Color endColorVariation = EndColorVariation;

                Color startRandColor = Color.FromScRgb(startColorVariation.ScA * (float)(_random.NextDouble() * 2.0 - 1.0),startColorVariation.ScR * (float)(_random.NextDouble() * 2.0 - 1.0),startColorVariation.ScG * (float)(_random.NextDouble() * 2.0 - 1.0),startColorVariation.ScB * (float)(_random.NextDouble() * 2.0 - 1.0));
                Color endRandColor = Color.FromScRgb(endColorVariation.ScA * (float)(_random.NextDouble() * 2.0 - 1.0), endColorVariation.ScR * (float)(_random.NextDouble() * 2.0 - 1.0), endColorVariation.ScG * (float)(_random.NextDouble() * 2.0 - 1.0), endColorVariation.ScB * (float)(_random.NextDouble() * 2.0 - 1.0));

                p.StartColor = startColor + startRandColor;
                p.EndColor = endColor + endRandColor;
                _particles.Add(p);
            }
        }        
    }
}