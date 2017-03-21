         ' Get the current PingFrequency property value.
            Dim pingFreq As TimeSpan = _
            processModelSection.PingFrequency
         
         ' Set the PingFrequency property to
         ' TimeSpan.Parse("00:01:00").
            processModelSection.PingFrequency = _
            TimeSpan.Parse("00:01:00")
         