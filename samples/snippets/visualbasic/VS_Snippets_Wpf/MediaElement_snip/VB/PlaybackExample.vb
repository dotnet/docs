
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace MediaElementExample

    '/ <summary>
    '/ Interaction logic for Page1.xaml
    '/ </summary>

    Partial Class PlaybackExample
        Inherits Page

        Public Sub New()
            InitializeComponent()

        End Sub


        Private Sub PlaybackPageLoaded(ByVal element As Object, ByVal args As RoutedEventArgs)
            AddHandler media.MediaOpened, AddressOf Media_MediaOpened
            AddHandler media.MediaFailed, AddressOf Media_MediaFailed
            volumeSL.Value = 0.5

        End Sub


        '<SnippetUIElementVisibility>
        Private Sub PlayMedia(ByVal sender As Object, ByVal args As MouseButtonEventArgs)
            pauseBTN.Visibility = System.Windows.Visibility.Visible
            playBTN.Visibility = System.Windows.Visibility.Collapsed

            media.SpeedRatio = 1.0
            media.Play()

        End Sub

        '</SnippetUIElementVisibility>
        Private Sub PauseMedia(ByVal sender As Object, ByVal args As MouseButtonEventArgs)
            pauseBTN.Visibility = System.Windows.Visibility.Collapsed
            playBTN.Visibility = System.Windows.Visibility.Visible

            media.Pause()

        End Sub


        Private Sub StopMedia(ByVal sender As Object, ByVal args As MouseButtonEventArgs)
            pauseBTN.Visibility = System.Windows.Visibility.Collapsed
            playBTN.Visibility = System.Windows.Visibility.Visible

            media.Stop()

        End Sub


        Private Sub RewindMedia(ByVal sender As Object, ByVal args As MouseButtonEventArgs)

        End Sub


        Private Sub FastForwardMedia(ByVal sender As Object, ByVal args As MouseButtonEventArgs)
            pauseBTN.Visibility = System.Windows.Visibility.Collapsed
            playBTN.Visibility = System.Windows.Visibility.Visible
            media.SpeedRatio += 0.5

            MediaCommands.MuteVolume.Execute(Nothing, media)

        End Sub


        Private Sub MuteMedia(ByVal sender As Object, ByVal args As MouseButtonEventArgs)
            If volBTN.Visibility = System.Windows.Visibility.Collapsed Then
                volBTN.Visibility = System.Windows.Visibility.Visible
                muteBTN.Visibility = System.Windows.Visibility.Collapsed

                media.IsMuted = True
            Else
                muteBTN.Visibility = System.Windows.Visibility.Visible
                volBTN.Visibility = System.Windows.Visibility.Collapsed

                media.IsMuted = False
            End If

        End Sub


        Private Sub ChangeMediaPosition(ByVal sender As Object, ByVal args As RoutedPropertyChangedEventArgs(Of Double))
            If (media.NaturalDuration.HasTimeSpan) Then
                '    positionSL.Maximum is TimeSpan.TotalSeconds
                media.Position = New TimeSpan(0, 0, CType(args.NewValue, Integer))
            Else
                '    postionSL.Maximum is 100;
                media.Position += New TimeSpan(0, 0, CType(args.NewValue, Integer))

            End If
        End Sub

        Private Sub ChangeMediaVolume(ByVal sender As Object, ByVal args As RoutedPropertyChangedEventArgs(Of Double))
            If (True) Then
                media.Volume = args.NewValue
            End If
        End Sub


        Private Sub Media_MediaOpened(ByVal sender As Object, ByVal args As RoutedEventArgs)
            If (True) Then
            End If 'if (media.Player.NaturalDuration.HasTimeSpan)
            '    positionSL.Maximum = media.Player.NaturalDuration.TimeSpan.TotalSeconds;
            'else
            '{
            '    positionSL.Maximum = 100.0;
            '    positionSL.TickFrequency = 1;
            '    positionSL.TickPlacement = System.Windows.Controls.Primitives.TickPlacement.BottomRight;
            '}
            'volumeSL.Maximum = 1.0;
            'MediaCommands.TogglePlayPause.Execute(null, media);
        End Sub
        '<SnippetExceptionRoutedEventArgs>
        Private Sub Media_MediaFailed(ByVal sender As Object, ByVal args As ExceptionRoutedEventArgs)
            If (True) Then
                MessageBox.Show(args.ErrorException.Message)
            End If
        End Sub
        '</SnippetExceptionRoutedEventArgs>
        Private Sub QueryMediaCommand(ByVal sender As Object, ByVal args As CanExecuteRoutedEventArgs)
            If (True) Then
                args.CanExecute = True
            End If
        End Sub
    End Class
End Namespace 'MediaElementExample