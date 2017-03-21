         ' Get the current IdleTimeout property value.
            Dim idleTimeout As TimeSpan = _
            processModelSection.IdleTimeout
         
         ' Set the IdleTimeout property to TimeSpan.Parse("12:00:00").
            processModelSection.IdleTimeout = _
            TimeSpan.Parse("12:00:00")
         