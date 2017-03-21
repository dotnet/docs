         ' Get the current LogLevel property value.
            Dim comLogLevel As ProcessModelLogLevel = _
            processModelSection.LogLevel
         
         ' Set the LogLevel property to ProcessModelLogLevel.All.
         processModelSection.LogLevel = ProcessModelLogLevel.All
         