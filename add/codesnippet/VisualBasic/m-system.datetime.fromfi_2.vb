   Public Function FileAge(ByVal fileCreationTime As Long) As System.TimeSpan
      Dim now As System.DateTime
      now = System.DateTime.Now

      Try
         Dim fCreationTime As System.DateTime
         Dim fAge As System.TimeSpan
         fCreationTime = System.DateTime.FromFileTime(fileCreationTime)
         fAge = now.Subtract(fCreationTime)
         Return fAge
      Catch exp As ArgumentOutOfRangeException
         ' fileCreationTime is not valid, so re-throw the exception.
         Throw
      End Try
   End Function