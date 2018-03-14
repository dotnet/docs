Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace ScrollableControl
   Public Class Form1
      Inherits System.Windows.Forms.Form
      Private WithEvents panel1 As System.Windows.Forms.Panel
      Private WithEvents button1 As System.Windows.Forms.Button
      Private components As System.ComponentModel.Container = Nothing
      
      Public Sub New()
         InitializeComponent()
      End Sub 'New
      
      
     Private Sub InitializeComponent() '
         Me.panel1 = New System.Windows.Forms.Panel()
         Me.button1 = New System.Windows.Forms.Button()
         Me.panel1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' panel1
         ' 
         Me.panel1.AutoScroll = True
         Me.panel1.AutoScrollMargin = New System.Drawing.Size(5, 5)
         Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me.panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1})
         Me.panel1.DockPadding.All = 10
         Me.panel1.Location = New System.Drawing.Point(40, 64)
         Me.panel1.Name = "panel1"
         Me.panel1.Size = New System.Drawing.Size(272, 104)
         Me.panel1.TabIndex = 0
         ' 
         ' button1
         ' 
         Me.button1.Location = New System.Drawing.Point(416, 184)
         Me.button1.Name = "button1"
         Me.button1.Size = New System.Drawing.Size(104, 40)
         Me.button1.TabIndex = 1
         Me.button1.Text = "button1"
         ' 
         ' Form1
         ' 
         Me.ClientSize = New System.Drawing.Size(336, 205)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.panel1})
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.panel1.ResumeLayout(False)
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent
       
      <STAThread()> _
      Shared Sub Main()
         Application.Run(New Form1())
      End Sub 'Main
      
' <snippet1>
Private Sub button1_Click(sender As Object, _
   e As EventArgs) Handles button1.Click
   ' Add a button to top left corner of the 
   ' scrollable area, allowing for the offset. 
   panel1.AutoScroll = True
   Dim myButton As New Button()
   myButton.Location = New Point( _
      0 + panel1.AutoScrollPosition.X, _
      0 + panel1.AutoScrollPosition.Y)
   panel1.Controls.Add(myButton)
End Sub
' </snippet1>

   End Class 'Form1
End Namespace 'ScrollableControl