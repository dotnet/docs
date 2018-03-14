using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media.Animation;
using System.Reflection;
using System.Xml;

namespace BrushesIntroduction
{
    /// <summary>
    /// Interaction logic for SampleViewer.xaml
    /// </summary>

    public partial class SampleViewer : Page
    {
        public SampleViewer()
        {
            InitializeComponent();  
        }

        private void transitionAnimationStateChanged(object sender, EventArgs args)
        {
            AnimationClock transitionAnimationClock = (AnimationClock)sender;


            if (transitionAnimationClock.CurrentState == ClockState.Filling)
            {
                fadeEnded();
            }
        }


        // <SnippetBeginAnimationHandoff>  
        private void myFrameNavigated(object sender, NavigationEventArgs args)
        {
            DoubleAnimation myFadeInAnimation = (DoubleAnimation)this.Resources["MyFadeInAnimationResource"];
            myFrame.BeginAnimation(Frame.OpacityProperty, myFadeInAnimation, HandoffBehavior.SnapshotAndReplace);
        }
        // </SnippetBeginAnimationHandoff>

        private void fadeEnded()
        {

            XmlElement el = (XmlElement)myPageList.SelectedItem;
            XmlAttribute att = el.Attributes["Uri"];
            if (att != null)
            {
                myFrame.Navigate(new Uri(att.Value, UriKind.Relative));
            }
            else
            {
                myFrame.Content = null;
            }
        }

        public static RoutedUICommand ExitCommand = 
            new RoutedUICommand("Exit", "Exit", typeof(SampleViewer));

        private void executeExitCommand(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }










}