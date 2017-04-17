' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet4>
Imports System.Collections.Generic
Imports System.Linq

Module modMain
   Public Sub Main()
      Dim output As String = String.Join(" ", GetAlphabet(True).Where(Function(letter) _
                                                         letter >= "M"))
        
      Console.WriteLine(output)                                     
   End Sub
   
   Private Function GetAlphabet(upper As Boolean) As List(Of String)
      Dim alphabet As New List(Of String)
      Dim charValue As Integer = CInt(IIf(upper, 65, 97))
      For ctr As Integer = 0 To 25
         alphabet.Add(ChrW(charValue + ctr).ToString())
      Next
      Return alphabet 
   End Function
End Module
' The example displays the following output:
'      M N O P Q R S T U V W X Y Z
' </Snippet4>

