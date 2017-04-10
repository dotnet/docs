' Visual Basic .NET Document
'
' Int32.Parse(string, NumberStyles)
'
Option Strict On

' <Snippet2>
Imports System.Globalization

Module ParseInt32
   Public Sub Main()
      Convert("104.0", NumberStyles.AllowDecimalPoint)    
      Convert("104.9", NumberStyles.AllowDecimalPoint)
      Convert(" $17,198,064.42", NumberStyles.AllowCurrencySymbol Or _
                                 NumberStyles.Number)
      Convert("103E06", NumberStyles.AllowExponent)  
      Convert("-1,345,791", NumberStyles.AllowThousands)
      Convert("(1,345,791)", NumberStyles.AllowThousands Or _
                             NumberStyles.AllowParentheses)
   End Sub
   
   Private Sub Convert(value As String, style As NumberStyles)
      Try
         Dim number As Integer = Int32.Parse(value, style)
         Console.WriteLine("Converted '{0}' to {1}.", value, number)
      Catch e As FormatException
         Console.WriteLine("Unable to convert '{0}'.", value)
      Catch e As OverflowException
         Console.WriteLine("'{0}' is out of range of the Int32 type.", value)   
      End Try
   End Sub
End Module
' The example displays the following output to the console:
'       Converted '104.0' to 104.
'       '104.9' is out of range of the Int32 type.
'       ' $17,198,064.42' is out of range of the Int32 type.
'       Converted '103E06' to 103000000.
'       Unable to convert '-1,345,791'.
'       Converted '(1,345,791)' to -1345791.
' </Snippet2>
