      Dim dTime As Date = #8/5/1980#

      ' tSpan is 17 days, 4 hours, 2 minutes and 1 second.
      Dim tSpan As New TimeSpan(17, 4, 2, 1)

      Dim result1, result2 As Date

      ' Result gets 8/22/1980 4:02:01 AM.
      result1 = Date.op_Addition(dTime, tSpan)
      
      result2 = dTime + tSpan 