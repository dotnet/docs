
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


Public Class Form1
   Inherits System.Windows.Forms.Form
   Private groupBox1 As System.Windows.Forms.GroupBox
   Private WithEvents button1 As System.Windows.Forms.Button
   '/ <summary>
   '/ Required designer variable.
   '/ </summary>
   Private components As System.ComponentModel.Container = Nothing
   
   
   Public Sub New()
      '
      ' Required for Windows Form Designer support
      '
      InitializeComponent()
   End Sub 'New
    
   
   '/ <summary>
   '/ Required method for Designer support - do not modify
   '/ the contents of this method with the code editor.
   '/ </summary>
   Private Sub InitializeComponent()
      Me.groupBox1 = New System.Windows.Forms.GroupBox()
      Me.button1 = New System.Windows.Forms.Button()
      Me.groupBox1.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' groupBox1
      ' 
      Me.groupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1})
      Me.groupBox1.Location = New System.Drawing.Point(32, 24)
      Me.groupBox1.Name = "groupBox1"
      Me.groupBox1.Size = New System.Drawing.Size(240, 184)
      Me.groupBox1.TabIndex = 0
      Me.groupBox1.TabStop = False
      Me.groupBox1.Text = "groupBox1"
      ' 
      ' button1
      ' 
      Me.button1.Location = New System.Drawing.Point(144, 48)
      Me.button1.Name = "button1"
      Me.button1.TabIndex = 0
      Me.button1.Text = "button1"
      ' 
      ' Form1
      ' 
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.groupBox1})
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.groupBox1.ResumeLayout(False)
      Me.ResumeLayout(False)
   End Sub 'InitializeComponent
    
  
   '/ <summary>
   '/ The main entry point for the application.
   '/ </summary>
   <STAThread()>  _
   Shared Sub Main()
      Application.Run(New Form1())
   End Sub 'Main
   
   
   '<Snippet1>
   ' This example uses the Parent property and the Find method of Control to set
   ' properties on the parent control of a Button and its Form. The example assumes
   ' that a Button control named button1 is located within a GroupBox control. The 
   ' example also assumes that the Click event of the Button control is connected to
   ' the event handler method defined in the example.
   Private Sub button1_Click(sender As Object, e As System.EventArgs) Handles button1.Click
      ' Get the control the Button control is located in. In this case a GroupBox.
      Dim control As Control = button1.Parent
      ' Set the text and backcolor of the parent control.
      control.Text = "My Groupbox"
      control.BackColor = Color.Blue
      ' Get the form that the Button control is contained within.
      Dim myForm As Form = button1.FindForm()
      ' Set the text and color of the form containing the Button.
      myForm.Text = "The Form of My Control"
      myForm.BackColor = Color.Red
   End Sub
   '</Snippet1>
End Class 'Form1 