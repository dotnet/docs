' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Globalization

Module Example
   Public Sub Main()
      ' Define a custom culture that uses "++" as a positive sign. 
      Dim ci As CultureInfo = New CultureInfo("")
      ci.NumberFormat.PositiveSign = "++"
      ' Create an array of cultures.
      Dim cultures() As CultureInfo = { ci, CultureInfo.InvariantCulture }
      ' Create an array of strings to parse.
      Dim values() As String = { "++1403", "-0", "+0", "+16034", _
                                 Int16.MinValue.ToString(), "14.0", "18012" }
      ' Parse the strings using each culture.
      For Each culture As CultureInfo In cultures
         Console.WriteLine("Parsing with the '{0}' culture.", culture.Name)
         For Each value As String In values
            Try
               Dim number As UShort = UInt16.Parse(value, culture)
               Console.WriteLine("   Converted '{0}' to {1}.", value, number)
            Catch e As FormatException
               Console.WriteLine("   The format of '{0}' is invalid.", value)
            Catch e As OverflowException
               Console.WriteLine("   '{0}' is outside the range of a UInt16 value.", value)
            End Try               
         Next
      Next
   End Sub
End Module
' The example displays the following output:
'       Parsing with the  culture.
'          Converted '++1403' to 1403.
'          Converted '-0' to 0.
'          The format of '+0' is invalid.
'          The format of '+16034' is invalid.
'          '-32768' is outside the range of a UInt16 value.
'          The format of '14.0' is invalid.
'          Converted '18012' to 18012.
'       Parsing with the '' culture.
'          The format of '++1403' is invalid.
'          Converted '-0' to 0.
'          Converted '+0' to 0.
'          Converted '+16034' to 16034.
'          '-32768' is outside the range of a UInt16 value.
'          The format of '14.0' is invalid.
'          Converted '18012' to 18012.
' </Snippet3>
