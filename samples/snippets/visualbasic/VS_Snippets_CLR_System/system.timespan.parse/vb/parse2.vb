' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization
Imports System.Threading

Module Example
   Public Sub Main()
      Dim values() As String = { "6", "6:12", "6:12:14", "6:12:14:45", 
                                 "6.12:14:45", "6:12:14:45.3448", 
                                 "6:12:14:45,3448", "6:34:14:45" }
      Dim cultures() As CultureInfo = { New CultureInfo("en-US"), 
                                        New CultureInfo("ru-RU"),
                                        CultureInfo.InvariantCulture }
      
      Dim header As String = String.Format("{0,-17}", "String")
      For Each culture As CultureInfo In cultures
         header += If(culture.Equals(CultureInfo.InvariantCulture), 
                      String.Format("{0,20}", "Invariant"),
                      String.Format("{0,20}", culture.Name))
      Next
      Console.WriteLine(header)
      Console.WriteLine()
      
      For Each value As String In values
         Console.Write("{0,-17}", value)
         For Each culture As CultureInfo In cultures
            Try
               Dim ts As TimeSpan = TimeSpan.Parse(value, culture)
               Console.Write("{0,20}", ts.ToString("c"))
            Catch e As FormatException
               Console.Write("{0,20}", "Bad Format")
            Catch e As OverflowException
               Console.Write("{0,20}", "Overflow")
            End Try      
         Next
         Console.WriteLine()                                
      Next
   End Sub
End Module
' The example displays the following output:
'    String                          en-US               ru-RU           Invariant
'    
'    6                          6.00:00:00          6.00:00:00          6.00:00:00
'    6:12                         06:12:00            06:12:00            06:12:00
'    6:12:14                      06:12:14            06:12:14            06:12:14
'    6:12:14:45                 6.12:14:45          6.12:14:45          6.12:14:45
'    6.12:14:45                 6.12:14:45          6.12:14:45          6.12:14:45
'    6:12:14:45.3448    6.12:14:45.3448000          Bad Format  6.12:14:45.3448000
'    6:12:14:45,3448            Bad Format  6.12:14:45.3448000          Bad Format
'    6:34:14:45                   Overflow            Overflow            Overflow
' </Snippet2>
