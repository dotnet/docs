' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim cultureNames() As String = { "en-US", "fr-FR" }
      Dim styles() As NumberStyles = { NumberStyles.Integer, _
                                       NumberStyles.Integer Or NumberStyles.AllowDecimalPoint }
      Dim values() As String = { "1702", "+1702.0", "+1702,0", "-1032.00", _
                                 "-1032,00", "1045.1", "1045,1" }
      
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
                                    UInt16.Parse(value, style, ci))
               Catch e As FormatException
                  Console.WriteLine("      Unable to parse '{0}'.", value)   
               Catch e As OverflowException
                  Console.WriteLine("      '{0}' is out of range of the UInt16 type.", _
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
'             Converted '1702' to 1702.
'             Unable to parse '+1702.0'.
'             Unable to parse '+1702,0'.
'             Unable to parse '-1032.00'.
'             Unable to parse '-1032,00'.
'             Unable to parse '1045.1'.
'             Unable to parse '1045,1'.
'          Style: Integer, AllowDecimalPoint
'             Converted '1702' to 1702.
'             Converted '+1702.0' to 1702.
'             Unable to parse '+1702,0'.
'             '-1032.00' is out of range of the UInt16 type.
'             Unable to parse '-1032,00'.
'             '1045.1' is out of range of the UInt16 type.
'             Unable to parse '1045,1'.
'       Parsing strings using the French (France) culture
'          Style: Integer
'             Converted '1702' to 1702.
'             Unable to parse '+1702.0'.
'             Unable to parse '+1702,0'.
'             Unable to parse '-1032.00'.
'             Unable to parse '-1032,00'.
'             Unable to parse '1045.1'.
'             Unable to parse '1045,1'.
'          Style: Integer, AllowDecimalPoint
'             Converted '1702' to 1702.
'             Unable to parse '+1702.0'.
'             Converted '+1702,0' to 1702.
'             Unable to parse '-1032.00'.
'             '-1032,00' is out of range of the UInt16 type.
'             Unable to parse '1045.1'.
'             '1045,1' is out of range of the UInt16 type.
' </Snippet4>
