    Sub PlayBackgroundSoundResource()
        My.Computer.Audio.Play(My.Resources.Waterfall, 
            AudioPlayMode.WaitToComplete)
    End Sub