Namespace SDKSample

    Partial Public Class MediaElementWindow
        Inherits System.Windows.Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub OnMouseDownPauseMedia(ByVal sender As Object, ByVal args As MouseButtonEventArgs)
            Me.myMediaElement.Pause()
        End Sub

        Private Sub OnMouseDownPlayMedia(ByVal sender As Object, ByVal args As MouseButtonEventArgs)
            Me.myMediaElement.Play()
            Me.InitializePropertyValues()
        End Sub

        Private Sub OnMouseDownStopMedia(ByVal sender As Object, ByVal args As MouseButtonEventArgs)
            Me.myMediaElement.Stop()
        End Sub

        Private Sub ChangeMediaVolume(ByVal sender As Object, ByVal args As RoutedPropertyChangedEventArgs(Of Double))
        End Sub

        Private Sub InitializePropertyValues()
        End Sub

    End Class

End Namespace