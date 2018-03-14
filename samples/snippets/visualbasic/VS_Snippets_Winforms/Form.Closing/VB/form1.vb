
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
   Private strMyOriginalText As String = ""
   Private button1 As System.Windows.Forms.Button
   Private textBox1 As System.Windows.Forms.TextBox
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
    
   
   '
   ' TODO: Add any constructor code after InitializeComponent call
   '
   
   
   
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
      Me.textBox1 = New System.Windows.Forms.TextBox()
      Me.SuspendLayout()
      ' 
      ' button1
      ' 
      Me.button1.Location = New System.Drawing.Point(200, 64)
      Me.button1.Name = "button1"
      Me.button1.TabIndex = 0
      Me.button1.Text = "button1"
      ' 
      ' textBox1
      ' 
      Me.textBox1.Location = New System.Drawing.Point(48, 64)
      Me.textBox1.Name = "textBox1"
      Me.textBox1.TabIndex = 1
      Me.textBox1.Text = "textBox1"
      ' 
      ' Form1
      ' 
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.textBox1, Me.button1})
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
   
   
   '<Snippet1>
   Private Sub Form1_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
      ' Determine if text has changed in the textbox by comparing to original text.
      If textBox1.Text <> strMyOriginalText Then
         ' Display a MsgBox asking the user to save changes or abort.
         If MessageBox.Show("Do you want to save changes to your text?", "My Application", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            ' Cancel the Closing event from closing the form.
            e.Cancel = True
         End If ' Call method to save file...
      End If
   End Sub 'Form1_Closing
End Class 'Form1
'</Snippet1>