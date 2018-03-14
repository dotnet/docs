Imports System
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
Private Sub PrintBindingMemberInfo()
  Dim c As Control
  Dim b As Binding
  For Each c In  Me.Controls         
     For Each b In  c.DataBindings
        Console.WriteLine(ControlChars.Cr + c.ToString())
        Dim bInfo As BindingMemberInfo = b.BindingMemberInfo
        Console.WriteLine("Binding Path " + ControlChars.Tab _
                          + bInfo.BindingPath)
        Console.WriteLine("Binding Field " + ControlChars.Tab _
                          + bInfo.BindingField)
        Console.WriteLine("Binding Member " + ControlChars.Tab _
                          + bInfo.BindingMember)
      Next b
   Next c
End Sub
' </Snippet1>
End Class
