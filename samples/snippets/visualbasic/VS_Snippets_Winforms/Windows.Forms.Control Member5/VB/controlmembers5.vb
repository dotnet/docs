Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace ControlMembers4
   Public Class Form1
      Inherits System.Windows.Forms.Form
      Private WithEvents button1 As System.Windows.Forms.Button
      Private WithEvents button2 As System.Windows.Forms.Button
      Private WithEvents button3 As System.Windows.Forms.Button
      Private components As System.ComponentModel.Container = Nothing
      
      
      Public Sub New()
         InitializeComponent()
      End Sub 'New
      
      
      
      Private Sub InitializeComponent() '
         Me.button1 = New System.Windows.Forms.Button()
         Me.button2 = New System.Windows.Forms.Button()
         Me.button3 = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' button1
         ' 
         Me.button1.Location = New System.Drawing.Point(40, 48)
         Me.button1.Name = "button1"
         Me.button1.TabIndex = 0
         Me.button1.Text = "button1"
         ' 
         ' button2
         ' 
         Me.button2.Location = New System.Drawing.Point(40, 112)
         Me.button2.Name = "button2"
         Me.button2.TabIndex = 1
         Me.button2.Text = "button2"
         ' 
         ' button3
         ' 
         Me.button3.Location = New System.Drawing.Point(40, 184)
         Me.button3.Name = "button3"
         Me.button3.TabIndex = 2
         Me.button3.Text = "button3"
         ' 
         ' Form1
         ' 
         Me.AutoScroll = True
         Me.ClientSize = New System.Drawing.Size(368, 325)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button3, Me.button2, Me.button1})
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent
       
      <STAThread()> _
      Shared Sub Main()
         Application.Run(New Form1())
      End Sub 'Main
      
      
      Private Sub button3_Click(sender As Object, e As System.EventArgs) Handles button3.Click
         Me.SizeControls()
      End Sub 'button3_Click
      
      
' Control.Size/Control.ClientSize/Control.SetClientSizeCore
' <snippet3>
Private Sub SizeControls()
   ' Resize the buttons two different ways.
   button1.Size = New Size(75, 25)
   button2.ClientSize = New Size(100, 50)
   
   ' Resize the form.
   Me.SetClientSizeCore(300, 300)
End Sub
' </snippet3>


      Private Sub button1_Click(sender As Object, e As System.EventArgs) Handles button1.Click
         Me.ResizeForm()
      End Sub 'button1_Click
      
      
' Control.ClientRectangle/Control.Bounds/Rectangle.Inflate/
' Control.ScrollControlIntoView/Control.AutoScroll 
' <snippet2>
Private Sub ResizeForm()
   ' Enable auto-scrolling for the form.
   Me.AutoScroll = True
   
   ' Resize the form.
   Dim r As Rectangle = Me.ClientRectangle
   ' Subtract 100 pixels from each side of the Rectangle.
   r.Inflate(- 100, - 100)
   Me.Bounds = Me.RectangleToScreen(r)
   
   ' Make sure button2 is visible.
   Me.ScrollControlIntoView(button2)
End Sub
' </snippet2>
      
      Private Sub button2_Click(sender As Object, e As System.EventArgs) Handles button2.Click
         Me.AutoSizeControl(CType(sender, Control), 5)
      End Sub 'button2_Click
      
      
' Control.CreateGraphics/Control.Text/Control.Font/
' Control.Height/Control.Width/Control.ClientSize 
' <snippet1>
Private Sub AutoSizeControl(control As Control, textPadding As Integer)
   ' Create a Graphics object for the Control.
   Dim g As Graphics = control.CreateGraphics()
   
   ' Get the Size needed to accommodate the formatted Text.
   Dim preferredSize As Size = g.MeasureString( _
     control.Text, control.Font).ToSize()
   
   ' Pad the text and resize the control.
   control.ClientSize = New Size( _
     preferredSize.Width + textPadding * 2, _
     preferredSize.Height + textPadding * 2)
   
   ' Clean up the Graphics object.
   g.Dispose()
End Sub
' </snippet1>
      
   End Class
End Namespace