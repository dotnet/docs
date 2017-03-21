      ' Get the current PollTime property value.
      Dim pollTimeValue As Int32 = sqlCdd.PollTime
      
      ' Set the PollTime property to 1000 milliseconds.
      sqlCdd.PollTime = 1000
      