' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim name1 As String = "Jack Smith"
      Dim name2 = "John Doe"
      
      ' Get position of space character.
      Dim index1 As Integer = name1.IndexOf(" ")
      index1 = CInt(IIf(index1 < 0, 0, index1 - 1))
      
      Dim index2 As Integer = name2.IndexOf(" ")
      index1 = CInt(IIf(index1 < 0, 0, index1 - 1))
      
      Dim length As Integer = Math.Max(name1.Length, name2.Length)
      
      Console.WriteLIne("Sorted alphabetically by last name:")
      If String.Compare(name1, index1, name2, index2, length, _
                        New CultureInfo("en-US"), CompareOptions.IgnoreCase) < 0 Then
         Console.WriteLine("{0}{1}{2}", name1, vbCrLf, name2)
      Else
         Console.WriteLine("{0}{1}{2}", name2, vbCrLf, name1)
      End If
   End Sub
End Module
' The example displays the following output;
'       Sorted alphabetically by last name:
'       John Doe
'       Jack Smith
' </Snippet1>
