    ' Demonstrates SetAudio, ContainsAudio, and GetAudioStream.
    Public Function SwapClipboardAudio( _
        ByVal replacementAudioStream As System.IO.Stream) _
        As System.IO.Stream

        Dim returnAudioStream As System.IO.Stream = Nothing

        If (Clipboard.ContainsAudio()) Then
            returnAudioStream = Clipboard.GetAudioStream()
            Clipboard.SetAudio(replacementAudioStream)
        End If

        Return returnAudioStream

    End Function