imports System
imports System.Windows.Forms


Public Class Form1

 Protected text1 As TextBox
' <Snippet1>
Private Sub PrintBindingInfo()
   Dim bc As BindingsCollection = Text1.DataBindings
   Dim i As Integer 
   For i = 0 to bc.Count - 1
      Console.WriteLine(bc(i).BindingMemberInfo.BindingMember)
   Next i
End Sub

' </Snippet1>
End Class
