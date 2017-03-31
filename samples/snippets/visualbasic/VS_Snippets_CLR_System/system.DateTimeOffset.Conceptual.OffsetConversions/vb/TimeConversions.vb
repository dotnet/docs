' Visual Basic .NET Document
Option Strict On

Imports System.Globalization

Module modMain
   Public Sub Main()
      Console.WriteLine(ReturnTimeOnServer("9/1/2007 5:32:07 -05:00"))
   End Sub
   
   ' <Snippet1>
   Public Function ReturnTimeOnServer(clientString As String) As DateTimeOffset
      Dim format As String = "M/d/yyyy H:m:s zzz"
      Dim serverOffset As TimeSpan = TimeZoneInfo.Local.GetUtcOffset(DateTimeOffset.Now)
      
      Try      
         Dim clientTime As DateTimeOffset = DateTimeOffset.ParseExact(clientString, format, CultureInfo.InvariantCulture)
         Dim serverTime As DateTimeOffset = clientTime.ToOffset(serverOffset)
         Return serverTime
      Catch e As FormatException
         Return DateTimeOffset.MinValue
      End Try    
   End Function
   ' </Snippet1>
End Module

