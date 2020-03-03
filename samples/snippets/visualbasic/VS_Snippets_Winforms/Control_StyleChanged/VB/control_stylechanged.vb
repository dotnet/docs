' System.Windows.Forms.Control.StyleChanged

' The following example demonstrates the 'StyleChanged' event
' of 'Control' class. This example has the style of the form
' set when the form is loaded. This setting of the style
' raises the 'StyleChanged' event. The event handler associated
' with the 'StyleChanged' event pops a message box indicating
' the same.

Imports System.ComponentModel
Imports System.Windows.Forms

Public Class MyForm
   Inherits Form
   Private myButton1 As System.Windows.Forms.Button

   Private components As Container = Nothing

   Public Sub New()
      InitializeComponent()
   End Sub

   Protected Overrides Overloads Sub Dispose(disposing As Boolean)
      If disposing Then
         If (components IsNot Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Me.myButton1 = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      ' Set the properties of the 'myButton1'.
      Me.myButton1.Location = New System.Drawing.Point(24, 8)
      Me.myButton1.Name = "myButton1"
      Me.myButton1.Size = New System.Drawing.Size(192, 48)
      Me.myButton1.TabIndex = 0
      Me.myButton1.Text = "button1"
      AddHandler myButton1.Click , AddressOf MyButton1_Click
      ' Set the properties of the 'MyForm'.
      Me.ClientSize = New System.Drawing.Size(248, 61)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.myButton1})
      Me.Name = "MyForm"
      Me.Text = "MyForm"
      AddHandler Me.Load, AddressOf MyForm_Load
      RegisterEventHandler()
      Me.ResumeLayout(False)
   End Sub

   <STAThread()>  _
   Shared Sub Main()
      Application.Run(New MyForm())
   End Sub

   Private Sub MyButton1_Click(sender As Object, e As EventArgs)
      MessageBox.Show("The 'Control' has been clicked")
   End Sub

' <Snippet1>
   ' Set the 'FixedHeight' and 'FixedWidth' styles to false.
   Private Sub MyForm_Load(sender As Object, e As EventArgs)
      Me.SetStyle(ControlStyles.FixedHeight, False)
      Me.SetStyle(ControlStyles.FixedWidth, False)
   End Sub

   Private Sub RegisterEventHandler()
      AddHandler Me.StyleChanged, AddressOf MyForm_StyleChanged
   End Sub

   ' Handle the 'StyleChanged' event for the 'Form'.
   Private Sub MyForm_StyleChanged(sender As Object, e As EventArgs)
      MessageBox.Show("The style releated to the 'Form' has been changed")
   End Sub
' </Snippet1>
End Class