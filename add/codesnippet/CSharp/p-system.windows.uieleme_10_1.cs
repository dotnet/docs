        private void PlayMedia(object sender, MouseButtonEventArgs args)
        {
            pauseBTN.Visibility = Visibility.Visible;
            playBTN.Visibility = Visibility.Collapsed;

            media.SpeedRatio = 1.0;
            media.Play();
        }