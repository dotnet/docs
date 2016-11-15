    Sub PlayLoopingBackgroundSoundFile()
        My.Computer.Audio.Play("C:\Waterfall.wav", 
            AudioPlayMode.BackgroundLoop)
    End Sub