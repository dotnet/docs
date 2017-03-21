         ' Get the current PingTimeout property value.
            Dim pingTimeout As TimeSpan = _
            processModelSection.PingTimeout
         
         ' Set the PingTimeout property to TimeSpan.Parse("00:00:30").
            processModelSection.PingTimeout = _
            TimeSpan.Parse("00:00:30")
         