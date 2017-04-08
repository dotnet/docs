using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;


namespace Microsoft.Samples.Animation
{
    public partial class SampleViewer : Page
    {
        public SampleViewer()
        {
            InitializeComponent();
            MyAnimatingSizeExampleFrame.Content = new AnimatingSizeExample();
            MyRotateAboutCenterExampleFrame.Content = new RotateAboutCenterExample();
        }
    }

    public class ElapsedTimeControl : Control
    {
        private Clock theClock;
        private Nullable<TimeSpan> previousTime;

        public ElapsedTimeControl()
        {}

        public Clock Clock
        {
            get { return theClock; }
            set
            {
                if (theClock != null)
                {
                    theClock.CurrentTimeInvalidated -= new EventHandler(onClockTimeInvalidated);
                }

                theClock = value;

                if (theClock != null)
                {
                    theClock.CurrentTimeInvalidated += new EventHandler(onClockTimeInvalidated);
                }
            }
        }

        private void onClockTimeInvalidated(object sender, EventArgs args)
        {
            SetValue(CurrentTimeProperty, theClock.CurrentTime);
        }

        public static readonly DependencyProperty CurrentTimeProperty =
            DependencyProperty.Register(
                "CurrentTime",
                typeof(Nullable<TimeSpan>),
                typeof(ElapsedTimeControl),
                new FrameworkPropertyMetadata(
                    (Nullable<TimeSpan>)null,
                    new PropertyChangedCallback(currentTime_Changed)));


        private static void currentTime_Changed(DependencyObject d,
            DependencyPropertyChangedEventArgs args)
        {
            //((ElapsedTimeControl)d).onCurrentTimeChanged(oldValue, newValue);
        }

        private void onCurrentTimeChanged(object oldValue, object newValue)
        {
            if (previousTime != null && ((TimeSpan)previousTime).Milliseconds != ((TimeSpan)theClock.CurrentTime).Milliseconds){
                SetValue(CurrentTimeAsStringProperty, theClock.CurrentTime.ToString());
                previousTime = (TimeSpan)theClock.CurrentTime;
            }
            else if (previousTime == null)
            {
                SetValue(CurrentTimeAsStringProperty, theClock.CurrentTime.ToString());
                previousTime = (TimeSpan)theClock.CurrentTime;
            }

        }

        public static readonly DependencyProperty CurrentTimeAsStringProperty =
            DependencyProperty.Register("CurrentTimeAsString", typeof(string),
                typeof(ElapsedTimeControl));
    }
}
