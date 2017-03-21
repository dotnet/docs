         ' Get the current ResponseDeadlockInterval property value.
            Dim respDeadlock As TimeSpan = _
            processModelSection.ResponseDeadlockInterval
         
         ' Set the ResponseDeadlockInterval property to
         ' TimeSpan.Parse("00:05:00").
            processModelSection.ResponseDeadlockInterval = _
            TimeSpan.Parse("00:05:00")
         