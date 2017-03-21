Private WithEvents Player As New SoundPlayer

Sub LoadSoundAsync()
    ' Note: You may need to change the location specified based on
    ' the location of the sound to be played.
    Me.Player.SoundLocation = "http://www.tailspintoys.com/sounds/stop.wav"
    Me.Player.LoadAsync ()
End Sub

Private Sub PlayWhenLoaded(ByVal sender As Object, ByVal e As _
    System.ComponentModel.AsyncCompletedEventArgs) Handles _
    Player.LoadCompleted
    If Me.Player.IsLoadCompleted = True Then
            Me.Player.PlaySync()
    End If
End Sub