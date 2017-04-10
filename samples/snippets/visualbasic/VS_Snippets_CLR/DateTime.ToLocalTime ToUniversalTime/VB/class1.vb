Option Strict On

' <Snippet1>
Module Example
    Sub Main()
      Dim localDateTime, univDateTime As DateTime
      
      Console.WriteLine("Enter a date and time.")
      Dim strDateTime As String = Console.ReadLine()
      Try
         localDateTime = DateTime.Parse(strDateTime)
         univDateTime = localDateTime.ToUniversalTime()
         Console.WriteLine("{0} local time is {1} universal time.", 
                           localDateTime, univDateTime)
      Catch exp As FormatException
         Console.WriteLine("Invalid format.")
      End Try

      Console.WriteLine("Enter a date and time in universal time.")
      strDateTime = Console.ReadLine()
      Try
         univDateTime = DateTime.Parse(strDateTime)
         localDateTime = univDateTime.ToLocalTime()
  
         Console.WriteLine("{0} universal time is {1} local time.", _
                           univDateTime, localDateTime)
      Catch exp As FormatException
         Console.WriteLine("Invalid format.")
      End Try
    End Sub
End Module
' The example displays output like the following when run on a 
' computer whose culture is en-US in the Pacific Standard Time zone:
'     Enter a date and time.
'     12/10/2015 6:18 AM
'     12/10/2015 6:18:00 AM local time is 12/10/2015 2:18:00 PM universal time.
'     Enter a date and time in universal time.
'     12/20/2015 6:42:00
'     12/20/2015 6:42:00 AM universal time is 12/19/2015 10:42:00 PM local time.
' </Snippet1>