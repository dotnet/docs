' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Public Class Person
   Public Property Name As String
   Public Property BirthDate As DateTime
   Public Property Height As Double
   Public Property Weight As Double
   Public Property Gender As Char
   Public Property Remarks As String
   
   Public Function GetDescription() As Object()
      Return { Name, Gender, Height, Weight, BirthDate}
   End Function
End Class

Module Example
   Public Sub Main()
      Dim p1 As New Person() With { .Name = "John", .Gender = "M"c,
                                    .BirthDate = New DateTime(1992, 5, 10), 
                                    .Height = 73.5, .Weight = 207 }
      p1.Remarks = "Client since 1/3/2012"
      Console.Write("{0}: {1}, born {4:d}  Height {2} inches, Weight {3} lbs  ", 
                    p1.GetDescription())
      If String.IsNullOrEmpty(p1.Remarks) Then
         Console.WriteLine()
      Else
         Console.WriteLine("{1}Remarks: {0}", p1.Remarks,
                           If(Console.CursorLeft + p1.Remarks.Length + 10 > Console.WindowWidth,
                              vbCrLf + "   ", ""))
      End If   
   End Sub
End Module
' The example displays the following output:
'   John: M, born 5/10/1992  Height 73.5 inches, Weight 207 lbs  Remarks: Client since 1/3/2012
' </Snippet1>
