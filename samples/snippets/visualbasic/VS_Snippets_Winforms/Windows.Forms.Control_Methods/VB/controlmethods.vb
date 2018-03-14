Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace SetBoundsCore
   Public Class MyUserControl
      Inherits System.Windows.Forms.UserControl
      Private components As System.ComponentModel.Container = Nothing
      
      Public Sub New()
         InitializeComponent()
      End Sub 'New
      
      Private Sub InitializeComponent()
         ' 
         ' MyUserControl
         ' 
         Me.BackColor = System.Drawing.SystemColors.Desktop
         Me.Name = "MyUserControl"
         Me.Size = New System.Drawing.Size(224, 88)
      End Sub 'InitializeComponent
       

' <snippet1>
Protected Overrides Sub SetBoundsCore(x As Integer, _
  y As Integer, width As Integer, _
  height As Integer, specified As BoundsSpecified)
   ' Set a fixed height and width for the control.
   MyBase.SetBoundsCore(x, y, 150, 75, specified)
End Sub
' </snippet1>
      
' <snippet2>
Protected Overrides Sub SetClientSizeCore(x As Integer, y As Integer)
   ' Keep the client size square.
   If x > y Then
      MyBase.SetClientSizeCore(x, x)
   Else
      MyBase.SetClientSizeCore(y, y)
   End If
End Sub
' </snippet2>
      
' <snippet3>
Protected Overrides Sub ScaleCore(dx As Single, dy As Single)
   ' Scale all child controls.
   Me.SuspendLayout()
   
   Dim myClientSize As Size = Me.ClientSize
   myClientSize.Height = CInt(myClientSize.Height * dx)
   myClientSize.Width = CInt(myClientSize.Width * dy)
   
   ' Scale the child controls because
   ' MyBase.ScaleCore was not called. 
   Dim childControl As Control
   For Each childControl In  Me.Controls
      childControl.Scale(dx, dy)
   Next childControl
   Me.ResumeLayout()
   
   Me.ClientSize = myClientSize
End Sub
' </snippet3>


   End Class 'MyUserControl 
End Namespace 'SetBoundsCore