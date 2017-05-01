
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms



Class Form1
    Inherits Form 
    
    
    
    Public Sub New() 
        
        InitializeDialogAndButton()
    
    End Sub
    
    
    '<snippet1>
    Private openFileDialog1 As OpenFileDialog
    Private WithEvents button1 As Button

    Private Sub InitializeDialogAndButton() 
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.button1 = New System.Windows.Forms.Button()
        Me.button1.Location = New System.Drawing.Point(53, 37)
        Me.button1.AutoSize = True
        Me.button1.Text = "Show dialog with custom places."
        Me.button1.UseVisualStyleBackColor = True

        Me.Controls.Add(Me.button1)
    
    End Sub
    
    
    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles button1.Click

        ' Add Pictures custom place using GUID.
        openFileDialog1.CustomPlaces.Add("33E28130-4E1E-4676-835A-98395C3BC3BB")

        ' Add Links custom place using GUID
        openFileDialog1.CustomPlaces.Add(New FileDialogCustomPlace _
            (New Guid("BFB9D5E0-C6A9-404C-B2B2-AE6DB6AF4968")))

        ' Add Windows custom place using file path.
        openFileDialog1.CustomPlaces.Add("c:\Windows")

        openFileDialog1.ShowDialog()

    End Sub
    
    '</snippet1>
    
    ' <summary>
    ' The main entry point for the application.
    ' </summary>
    <STAThread()>  _
    Shared Sub Main() 
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New Form1())
    
    End Sub 'Main
End Class 'Form1
