' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Globalization

Module Example
   Public Sub Main()
      ' Define a custom NumberFormatInfo object with "~" as its negative sign.
      Dim nfi As New NumberFormatInfo()
      nfi.NegativeSign = "~"
      
      ' Initialize an array of SByte values.
      Dim bytes() As SByte = { -122, 17, 124 }

      ' Display the formatted result using the custom provider.
      Console.WriteLine("Using the custom NumberFormatInfo object:")
      For Each value As SByte In bytes
         Console.WriteLine(value.ToString(nfi))
      Next
      Console.WriteLine()
          
      ' Display the formatted result using the invariant culture.
      Console.WriteLine("Using the invariant culture:")
      For Each value As SByte In bytes
         Console.WriteLine(value.ToString(NumberFormatInfo.InvariantInfo))
      Next   
   End Sub
End Module
' The example displays the following output:
'       Using the custom NumberFormatInfo object:
'       ~122
'       17
'       124
'       
'       Using the invariant culture:
'       -122
'       17
'       124
' </Snippet3>
