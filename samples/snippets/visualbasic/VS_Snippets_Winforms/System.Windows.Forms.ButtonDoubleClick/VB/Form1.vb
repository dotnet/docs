 '<snippet1>
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Private WithEvents button1 As DoubleClickButton
    Private initialStyle As FormBorderStyle
    
    Public Sub New() 
        Me.SuspendLayout()
        initialStyle = Me.FormBorderStyle
        Me.ClientSize = New System.Drawing.Size(292, 266)
        button1 = New DoubleClickButton()
        button1.Location = New Point(40, 40)
        button1.AutoSize = True
        button1.Text = "Click or Double Click"
        Me.Controls.Add(button1)
        Me.Name = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    
    End Sub 'New
    
    
    ' Handle the double click event.
    Private Sub button1_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles button1.DoubleClick

        ' Change the border style back to the initial style.
        Me.FormBorderStyle = initialStyle
        MessageBox.Show("Rolled back single click change.")

    End Sub
    
    
    ' Handle the click event.
    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
         Handles button1.Click

        Me.FormBorderStyle = FormBorderStyle.FixedToolWindow

    End Sub


    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())

    End Sub
End Class
'<snippet2>

Public Class DoubleClickButton
    Inherits Button
    
    Public Sub New() 
        ' Set the style so a double click event occurs.
        SetStyle(ControlStyles.StandardClick Or ControlStyles.StandardDoubleClick, True)
    
    End Sub 'New
End Class 'DoubleClickButton
'</snippet2>
'</snippet1>