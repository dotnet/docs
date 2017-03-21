         ' Get the current ClientConnectedCheck property value.
            Dim clConnectCheck As TimeSpan = _
            processModelSection.ClientConnectedCheck
         
         ' Set the ClientConnectedCheck property to
         ' TimeSpan.Parse("00:15:00").
            processModelSection.ClientConnectedCheck = _
            TimeSpan.Parse("00:15:00")
         