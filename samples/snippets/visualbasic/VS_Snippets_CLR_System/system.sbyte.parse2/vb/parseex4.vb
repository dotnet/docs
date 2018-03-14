' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim cultureNames() As String = { "en-US", "fr-FR" }
      Dim styles() As NumberStyles = { NumberStyles.Integer, _
                                       NumberStyles.Integer Or NumberStyles.AllowDecimalPoint }
      Dim values() As String = { "-17", "-17.0", "-17,0", "+103.00", "+103,00" }
      
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
                                    SByte.Parse(value, style, ci))
               Catch e As FormatException
                  Console.WriteLine("      Unable to parse '{0}'.", value)   
               Catch e As OverflowException
                  Console.WriteLine("      '{0}' is out of range of the SByte type.", _
                                    value)         
               End Try
            Next
         Next
      Next                                    
   End Sub
End Module
' The example displays the following output:
'       Parsing strings using the English (United States) culture
'          Style: Integer
'             Converted '-17' to -17.
'             Unable to parse '-17.0'.
'             Unable to parse '-17,0'.
'             Unable to parse '+103.00'.
'             Unable to parse '+103,00'.
'          Style: Integer, AllowDecimalPoint
'             Converted '-17' to -17.
'             Converted '-17.0' to -17.
'             Unable to parse '-17,0'.
'             Converted '+103.00' to 103.
'             Unable to parse '+103,00'.
'       Parsing strings using the French (France) culture
'          Style: Integer
'             Converted '-17' to -17.
'             Unable to parse '-17.0'.
'             Unable to parse '-17,0'.
'             Unable to parse '+103.00'.
'             Unable to parse '+103,00'.
'          Style: Integer, AllowDecimalPoint
'             Converted '-17' to -17.
'             Unable to parse '-17.0'.
'             Converted '-17,0' to -17.
'             Unable to parse '+103.00'.
'             Converted '+103,00' to 103.
' </Snippet4>
