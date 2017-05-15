Imports System
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
 Private Sub PrintBindingMemberInfo()
     Dim thisControl As Control
     For Each thisControl In  Me.Controls
         Dim thisBinding As Binding
         For Each thisBinding In  thisControl.DataBindings
             ' Print the control's name and Binding information.
             Console.WriteLine(ControlChars.Cr + thisControl.ToString())
             Dim bInfo As BindingMemberInfo = thisBinding.BindingMemberInfo
             Console.WriteLine("Binding Path " + ControlChars.Tab _
                              + bInfo.BindingPath)
             Console.WriteLine("Binding Field " + ControlChars.Tab _
                              + bInfo.BindingField)
             Console.WriteLine("Binding Member " + ControlChars.Tab _
                              + bInfo.BindingMember)
         Next thisBinding
     Next thisControl
 End Sub
' </Snippet1>
End Class
