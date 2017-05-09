' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim style As NumberStyles
      Dim number As SByte

      ' Parse value with no styles allowed.
      Dim values1() As String = { " 121 ", "121", "-121" }
      style = NumberStyles.None
      Console.WriteLine("Styles: {0}", style.ToString())
      For Each value As String In values1
         Try
            number = SByte.Parse(value, style)
            Console.WriteLine("   Converted '{0}' to {1}.", value, number)
         Catch e As FormatException
            Console.WriteLine("   Unable to parse '{0}'.", value)   
         End Try
      Next
      Console.WriteLine()
            
      ' Parse value with trailing sign.
      style = NumberStyles.Integer Or NumberStyles.AllowTrailingSign
      Dim values2() As String = { " 103+", " 103 +", "+103", "(103)", "   +103  " }
      Console.WriteLine("Styles: {0}", style.ToString())
      For Each value As String In values2
         Try
            number = SByte.Parse(value, style)
            Console.WriteLine("   Converted '{0}' to {1}.", value, number)
         Catch e As FormatException
            Console.WriteLine("   Unable to parse '{0}'.", value)   
         Catch e As OverflowException
            Console.WriteLine("   '{0}' is out of range of the SByte type.", value)         
         End Try
      Next      
      Console.WriteLine()
   End Sub
End Module
' The example displays the following output:
'       Styles: None
'          Unable to parse ' 121 '.
'          Converted '121' to 121.
'          Unable to parse '-121'.
'       
'       Styles: Integer, AllowTrailingSign
'          Converted ' 103+' to 103.
'          Converted ' 103 +' to 103.
'          Converted '+103' to 103.
'          Unable to parse '(103)'.
'          Converted '   +103  ' to 103.
' </Snippet2>
