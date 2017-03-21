         ' Get the current ResponseRestartDeadlockInterval property
         ' value.
            Dim respRestartDeadlock As TimeSpan = _
            processModelSection.ResponseRestartDeadlockInterval
         
         ' Set the ResponseRestartDeadlockInterval property to
         ' TimeSpan.Parse("04:00:00").
            processModelSection.ResponseRestartDeadlockInterval = _
            TimeSpan.Parse("04:00:00")
         