
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


'/ <summary>
'/ Summary description for Form1.
'/ </summary>

Public Class Form1
   Inherits System.Windows.Forms.Form
   Private checkBox1 As System.Windows.Forms.CheckBox
   Private button1 As System.Windows.Forms.Button
   '/ <summary>
   '/ Required designer variable.
   '/ </summary>
   Private components As System.ComponentModel.IContainer
   
   
   Public Sub New()
      '
      ' Required for Windows Form Designer support
      '
      InitializeComponent()
   End Sub 'New
    
   '
   ' TODO: Add any constructor code after InitializeComponent call
   '
   
   '/ <summary>
   '/ Clean up any resources being used.
   '/ </summary>
   '
   'ToDo: Error processing original source shown below
   '
   '  #region Windows Form Designer generated code
   '-----^--- Pre-processor directives not translated
   '/ <summary>
   '/ Required method for Designer support - do not modify
   '/ the contents of this method with the code editor.
   '/ </summary>
   Private Sub InitializeComponent()
      Me.button1 = New System.Windows.Forms.Button()
      Me.checkBox1 = New System.Windows.Forms.CheckBox()
      Me.SuspendLayout()
      ' 
      ' button1
      ' 
      Me.button1.Location = New System.Drawing.Point(200, 20)
      Me.button1.Name = "button1"
      Me.button1.Size = New System.Drawing.Size(84, 24)
      Me.button1.TabIndex = 1
      Me.button1.Text = "button1"
      ' 
      ' checkBox1
      ' 
      Me.checkBox1.Location = New System.Drawing.Point(204, 60)
      Me.checkBox1.Name = "checkBox1"
      Me.checkBox1.TabIndex = 0
      Me.checkBox1.Text = "checkBox1"
      ' 
      ' Form1
      ' 
      Me.ClientSize = New System.Drawing.Size(292, 273)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1, Me.checkBox1})
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)
   End Sub 'InitializeComponent
    
   '
   'ToDo: Error processing original source shown below
   '      }
   '  #endregion
   '-----^--- Pre-processor directives not translated
   '/ <summary>
   '/ The main entry point for the application.
   '/ </summary>
   <STAThread()>  _
   Shared Sub Main()
      Application.Run(New Form1())
   End Sub 'Main
   
   
   '<snippet1>
   ' This example assumes that the Form_Load event handling method
   ' is connected to the Load event of the form.
   Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
      ' Create the ToolTip and associate with the Form container.
      Dim toolTip1 As New ToolTip()
      
      ' Set up the delays for the ToolTip.
      toolTip1.AutoPopDelay = 5000
      toolTip1.InitialDelay = 1000
      toolTip1.ReshowDelay = 500
      ' Force the ToolTip text to be displayed whether or not the form is active.
      toolTip1.ShowAlways = True
      
      ' Set up the ToolTip text for the Button and Checkbox.
      toolTip1.SetToolTip(Me.button1, "My button1")
      toolTip1.SetToolTip(Me.checkBox1, "My checkBox1")
   End Sub
   '</snippet1>
End Class 'Form1 