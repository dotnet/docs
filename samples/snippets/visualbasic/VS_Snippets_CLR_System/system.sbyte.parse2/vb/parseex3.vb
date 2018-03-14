' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim nf As New NumberFormatInfo()
      nf.NegativeSign = "~" 
      
      Dim values() As String = { "-103", "+12", "~16", "  1", "~255" }
      Dim providers() As IFormatProvider = { nf, CultureInfo.InvariantCulture }
      
      For Each provider As IFormatProvider In providers
         Console.WriteLine("Conversions using {0}:", CObj(provider).GetType().Name)
         For Each value As String In values
            Try
               Console.WriteLine("   Converted '{0}' to {1}.", _
                                 value, SByte.Parse(value, provider))
            Catch e As FormatException
               Console.WriteLine("   Unable to parse '{0}'.", value)   
            Catch e As OverflowException
               Console.WriteLine("   '{0}' is out of range of the SByte type.", value)         
            End Try
         Next
      Next      
   End Sub
End Module
' The example displays '
'       Conversions using NumberFormatInfo:
'          Unable to parse '-103'.
'          Converted '+12' to 12.
'          Converted '~16' to -16.
'          Converted '  1' to 1.
'          '~255' is out of range of the SByte type.
'       Conversions using CultureInfo:
'          Converted '-103' to -103.
'          Converted '+12' to 12.
'          Unable to parse '~16'.
'          Converted '  1' to 1.
'          Unable to parse '~255'.
' </Snippet3>
