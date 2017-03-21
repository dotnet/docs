If My.Computer.Clipboard.ContainsAudio Then
   Dim song = My.Computer.Clipboard.GetAudioStream
   My.Computer.Audio.Play(song, AudioPlayMode.WaitToComplete)
End If