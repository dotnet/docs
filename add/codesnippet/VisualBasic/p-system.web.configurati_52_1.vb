      ' Get the current PollTime property value.
      Dim pollTimeValue As Int32 = sqlDs.PollTime
      
      ' Set the PollTime property to 500 milliseconds.
      sqlDs.PollTime = 500
      