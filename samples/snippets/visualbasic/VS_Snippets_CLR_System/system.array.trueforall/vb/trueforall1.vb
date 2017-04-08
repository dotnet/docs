' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim values() As String = { "Y2K", "A2000", "DC2A6", "MMXIV", "0C3" }
      'Dim values2() As String = { "Y2", "A2000", "DC2A6", "MMXIV_0", "0C3" }

      If Array.TrueForAll(values, Function(value) 
                                     Dim s As Integer
                                     Return Int32.TryParse(value.Substring(value.Length - 1), s)
                                  End Function) Then
         Console.WriteLine("All elements end with an integer.")
      Else
         Console.WriteLine("Not all elements end with an integer.")
      End If   
   End Sub
End Module
' The example displays the following output:
'       Not all elements end with an integer.
' </Snippet1>
