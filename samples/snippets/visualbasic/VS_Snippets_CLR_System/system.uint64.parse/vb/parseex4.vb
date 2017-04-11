' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim cultureNames() As String = { "en-US", "fr-FR" }
      Dim styles() As NumberStyles = { NumberStyles.Integer, _
                                       NumberStyles.Integer Or NumberStyles.AllowDecimalPoint }
      Dim values() As String = { "170209", "+170209.0", "+170209,0", "-103214.00", _
                                 "-103214,00", "104561.1", "104561,1" }
      
      ' Parse strings using each culture
      For Each cultureName As String In cultureNames
         Dim ci As New CultureInfo(cultureName)
         Console.WriteLine("Parsing strings using the {0} culture", ci.DisplayName)
         ' Use each style.
         For Each style As NumberStyles In styles
            Console.WriteLine("   Style: {0}", style.ToString())
            ' Parse each numeric string.
            For Each value As String In values
               Try
                  Console.WriteLine("      Converted '{0}' to {1}.", value, _
                                    UInt64.Parse(value, style, ci))
               Catch e As FormatException
                  Console.WriteLine("      Unable to parse '{0}'.", value)   
               Catch e As OverflowException
                  Console.WriteLine("      '{0}' is out of range of the UInt64 type.", _
                                    value)         
               End Try
            Next
         Next
      Next                                    
   End Sub
End Module
' The example displays the following output:
'       Style: Integer
'          Converted '170209' to 170209.
'          Unable to parse '+170209.0'.
'          Unable to parse '+170209,0'.
'          Unable to parse '-103214.00'.
'          Unable to parse '-103214,00'.
'          Unable to parse '104561.1'.
'          Unable to parse '104561,1'.
'       Style: Integer, AllowDecimalPoint
'          Converted '170209' to 170209.
'          Converted '+170209.0' to 170209.
'          Unable to parse '+170209,0'.
'          '-103214.00' is out of range of the UInt64 type.
'          Unable to parse '-103214,00'.
'          '104561.1' is out of range of the UInt64 type.
'          Unable to parse '104561,1'.
'    Parsing strings using the French (France) culture
'       Style: Integer
'          Converted '170209' to 170209.
'          Unable to parse '+170209.0'.
'          Unable to parse '+170209,0'.
'          Unable to parse '-103214.00'.
'          Unable to parse '-103214,00'.
'          Unable to parse '104561.1'.
'          Unable to parse '104561,1'.
'       Style: Integer, AllowDecimalPoint
'          Converted '170209' to 170209.
'          Unable to parse '+170209.0'.
'          Converted '+170209,0' to 170209.
'          Unable to parse '-103214.00'.
'          '-103214,00' is out of range of the UInt64 type.
'          Unable to parse '104561.1'.
'          '104561,1' is out of range of the UInt64 type.
' </Snippet4>
