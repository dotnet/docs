
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
    Private WithEvents textBox1 As System.Windows.Forms.TextBox
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
    '/ Clean up any resources being used.
    '/ </summary>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub 'Dispose
   

    Private Sub InitializeComponent()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        ' 
        ' textBox1
        ' 
        Me.textBox1.Location = New System.Drawing.Point(64, 48)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(200, 20)
        Me.textBox1.TabIndex = 0
        Me.textBox1.Text = "textBox1"
        ' 
        ' Form1
        ' 
        Me.ClientSize = New System.Drawing.Size(376, 342)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.textBox1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
    End Sub 'InitializeComponent
    
    <STAThread()>  _
    Shared Sub Main()
        Application.Run(New Form1())
    End Sub 'Main
   
   
    '<Snippet1>
    ' Boolean flag used to determine when a character other than a number is entered.
    Private nonNumberEntered As Boolean = False
   
   
    ' Handle the KeyDown event to determine the type of character entered into the control.
    Private Sub textBox1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) _
         Handles textBox1.KeyDown
        ' Initialize the flag to false.
        nonNumberEntered = False
      
        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If
        'If shift key was pressed, it's not a number.
        If Control.ModifierKeys = Keys.Shift Then
            nonNumberEntered = true
        End If
    End Sub 'textBox1_KeyDown
   
   
    ' This event occurs after the KeyDown event and can be used 
    ' to prevent characters from entering the control.
    Private Sub textBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) _
        Handles textBox1.KeyPress
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        End If
    End Sub 'textBox1_KeyPress
'</Snippet1>
End Class 'Form1 
