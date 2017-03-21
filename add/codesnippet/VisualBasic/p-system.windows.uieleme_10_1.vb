        Private Sub PlayMedia(ByVal sender As Object, ByVal args As MouseButtonEventArgs)
            pauseBTN.Visibility = System.Windows.Visibility.Visible
            playBTN.Visibility = System.Windows.Visibility.Collapsed

            media.SpeedRatio = 1.0
            media.Play()

        End Sub 'PlayMedia
