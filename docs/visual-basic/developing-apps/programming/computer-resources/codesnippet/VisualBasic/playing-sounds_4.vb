    Sub PlayLoopingBackgroundSoundResource()
        My.Computer.Audio.Play(My.Resources.Waterfall, 
              AudioPlayMode.BackgroundLoop)
    End Sub