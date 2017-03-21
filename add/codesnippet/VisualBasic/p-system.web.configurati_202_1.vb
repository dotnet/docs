         ' Get the current ShutdownTimeout property value.
            Dim shutDownTimeout As TimeSpan = _
            processModelSection.ShutdownTimeout
         
         ' Set the ShutdownTimeout property to
         ' TimeSpan.Parse("00:00:30").
            processModelSection.ShutdownTimeout = _
            TimeSpan.Parse("00:00:30")
         