Imports System
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
Private Sub PrintBindingMemberInfo()
   Console.WriteLine(ControlChars.Cr + " BindingMemberInfo")
   Dim thisControl As Control
   Dim thisBinding As Binding
   For Each thisControl In  Me.Controls    
      For Each thisBinding In  thisControl.DataBindings
         Dim bInfo As BindingMemberInfo =  _
         thisBinding.BindingMemberInfo
         Console.WriteLine(ControlChars.Tab + _
         " BindingPath: "  + bInfo.BindingPath)
         Console.WriteLine(ControlChars.Tab + _
         " BindingField: " + bInfo.BindingField)
         Console.WriteLine(ControlChars.Tab + _
         " BindingMember: "  + bInfo.BindingMember)
         Console.WriteLine()
      Next thisBinding
   Next thisControl
End Sub
' </Snippet1>
End Class
