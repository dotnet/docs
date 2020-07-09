using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediaElementExample
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>

    public partial class PlaybackExample : Page
    {
        public PlaybackExample()
        {
            InitializeComponent();
        }

        private void PlaybackPageLoaded(object element, RoutedEventArgs args)
        {
            media.MediaOpened += new RoutedEventHandler(Media_MediaOpened);
            media.MediaFailed += new EventHandler<ExceptionRoutedEventArgs>(Media_MediaFailed);
            volumeSL.Value = 0.5;
        }

//<SnippetUIElementVisibility>
        private void PlayMedia(object sender, MouseButtonEventArgs args)
        {
            pauseBTN.Visibility = Visibility.Visible;
            playBTN.Visibility = Visibility.Collapsed;

            media.SpeedRatio = 1.0;
            media.Play();
        }
//</SnippetUIElementVisibility>

        private void PauseMedia(object sender, MouseButtonEventArgs args)
        {
            pauseBTN.Visibility = Visibility.Collapsed;
            playBTN.Visibility = Visibility.Visible;

            media.Pause();
        }

        private void StopMedia(object sender, MouseButtonEventArgs args)
        {
            pauseBTN.Visibility = Visibility.Collapsed;
            playBTN.Visibility = Visibility.Visible;

            media.Stop();
        }

        private void RewindMedia(object sender, MouseButtonEventArgs args)
        {
        }

        private void FastForwardMedia(object sender, MouseButtonEventArgs args)
        {
            pauseBTN.Visibility = Visibility.Collapsed;
            playBTN.Visibility = Visibility.Visible;
            media.SpeedRatio += .5;

            MediaCommands.MuteVolume.Execute(null, media);
        }

        private void MuteMedia(object sender, MouseButtonEventArgs args)
        {
            if (volBTN.Visibility == Visibility.Collapsed)
            {
                volBTN.Visibility = Visibility.Visible;
                muteBTN.Visibility = Visibility.Collapsed;

                media.IsMuted = true;
            }
            else
            {
                muteBTN.Visibility = Visibility.Visible;
                volBTN.Visibility = Visibility.Collapsed;

                media.IsMuted = false;
            }
        }

        private void ChangeMediaPosition(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            //if (media.Player.NaturalDuration.HasTimeSpan)
            //{
            //    //positionSL.Maximum is TimeSpan.TotalSeconds
            //    media.Player.Position = new TimeSpan(0, 0, (int)args.NewValue);
            //}
            //else
            //{
            //    //postionSL.Maximum is 100;
            //    media.Player.Position += new TimeSpan(0, 0, (int)args.NewValue);
            //}
        }

        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            media.Volume = args.NewValue;
        }

        private void Media_MediaOpened(object sender, System.EventArgs args)
        {
            //if (media.Player.NaturalDuration.HasTimeSpan)
            //    positionSL.Maximum = media.Player.NaturalDuration.TimeSpan.TotalSeconds;
            //else
            //{
            //    positionSL.Maximum = 100.0;
            //    positionSL.TickFrequency = 1;
            //    positionSL.TickPlacement = System.Windows.Controls.Primitives.TickPlacement.BottomRight;
            //}

            //volumeSL.Maximum = 1.0;
            //MediaCommands.TogglePlayPause.Execute(null, media);
        }

//<SnippetExceptionRoutedEventArgs>
        private void Media_MediaFailed(object sender, ExceptionRoutedEventArgs args)
        {
            MessageBox.Show(args.ErrorException.Message);
        }
//</SnippetExceptionRoutedEventArgs>

        private void QueryMediaCommand(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}