   Private Sub HandleInnerException()
      Dim timeZoneName As String = "Any Standard Time"
      Dim tz As TimeZoneInfo
      Try
         tz = RetrieveTimeZone(timeZoneName)
         Console.WriteLine("The time zone display name is {0}.", tz.DisplayName)
      Catch e As TimeZoneNotFoundException
         Console.WriteLine("{0} thrown by application", e.GetType().Name)
         Console.WriteLine("   Message: {0}", e.Message)
         If e.InnerException IsNot Nothing Then
            Console.WriteLine("   Inner Exception Information:")
            Dim innerEx As Exception = e.InnerException
            Do
               Console.WriteLine("      {0}: {1}", innerEx.GetType().Name, innerEx.Message)
               innerEx = innerEx.InnerException
            Loop While innerEx IsNot Nothing
         End If            
      End Try   
   End Sub
   
   Private Function RetrieveTimeZone(tzName As String) As TimeZoneInfo
      Try
         Return TimeZoneInfo.FindSystemTimeZoneById(tzName)
      Catch ex1 As TimeZoneNotFoundException
         Throw New TimeZoneNotFoundException( _
               String.Format("The time zone '{0}' cannot be found.", tzName), _
               ex1) 
      Catch ex2 As InvalidTimeZoneException
         Throw New InvalidTimeZoneException( _
               String.Format("The time zone {0} contains invalid data.", tzName), _
               ex2) 
      End Try      
   End Function