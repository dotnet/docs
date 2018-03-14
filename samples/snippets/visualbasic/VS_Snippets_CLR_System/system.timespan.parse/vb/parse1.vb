' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization
Imports System.Threading

Module Example
   Public Sub Main()
      Dim values() As String = { "6", "6:12", "6:12:14", "6:12:14:45", 
                                 "6.12:14:45", "6:12:14:45.3448", 
                                 "6:12:14:45,3448", "6:34:14:45" }
      Dim cultureNames() As String = { "hr-HR", "en-US"}
      
      ' Change the current culture.
      For Each cultureName As String In cultureNames
         Thread.CurrentThread.CurrentCulture = New CultureInfo(cultureName)
         Console.WriteLine("Current Culture: {0}", 
                           Thread.CurrentThread.CurrentCulture.Name)
         For Each value As String In values
            Try
               Dim ts As TimeSpan = TimeSpan.Parse(value)
               Console.WriteLine("{0} --> {1}", value, ts.ToString("c"))
            Catch e As FormatException
               Console.WriteLine("{0}: Bad Format", value)
            Catch e As OverflowException
               Console.WriteLine("{0}: Overflow", value)
            End Try      
         Next 
         Console.WriteLine()                                
      Next
   End Sub
End Module
' The example displays the following output:
'       Current Culture: hr-HR
'       6 --> 6.00:00:00
'       6:12 --> 06:12:00
'       6:12:14 --> 06:12:14
'       6:12:14:45 --> 6.12:14:45
'       6.12:14:45 --> 6.12:14:45
'       6:12:14:45.3448: Bad Format
'       6:12:14:45,3448 --> 6.12:14:45.3448000
'       6:34:14:45: Overflow
'       
'       Current Culture: en-US
'       6 --> 6.00:00:00
'       6:12 --> 06:12:00
'       6:12:14 --> 06:12:14
'       6:12:14:45 --> 6.12:14:45
'       6.12:14:45 --> 6.12:14:45
'       6:12:14:45.3448 --> 6.12:14:45.3448000
'       6:12:14:45,3448: Bad Format
'       6:34:14:45: Overflow
' </Snippet1>
