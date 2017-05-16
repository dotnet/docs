' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Module Example
   Public Sub Main()
      Dim result As String = String.Empty
      For ctr As Integer = &h10107 To &h10110     ' Range of Aegean numbers.
         result += Char.ConvertFromUtf32(ctr)
      Next         
      Console.WriteLine("The string contains {0} characters.", result.Length) 
   End Sub
End Module
' The example displays the following output:
'     The string contains 20 characters.
' </Snippet3>
