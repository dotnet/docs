
' The following code example demonstrates using 
' the following members: LostFocus, OpenFileDialog.Multiselect, 
' FileNames, Title, ErrorProvider.GetError, PictureBox.Image,
' Application.DoEvents, and System.Drawing.Image.FromStream.




Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()
        InitializePictureBox()
        InitializeOpenFileDialog()

        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.Label2 = New System.Windows.Forms.Label

        Me.SuspendLayout()
        Me.OpenFileDialog1.Filter = "Images " _
            & "(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*"
        Me.OpenFileDialog1.Multiselect = True
        Me.OpenFileDialog1.Title = "My Image Browser"
        Me.TextBox1.Location = New System.Drawing.Point(16, 56)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(150, 20)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = ""
        Me.Button1.Location = New System.Drawing.Point(184, 48)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 32)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Find pictures"
        Me.ErrorProvider1.ContainerControl = Me
        Me.Label2.Location = New System.Drawing.Point(24, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(150, 23)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Enter image file directory:"
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents FileButton As System.Windows.Forms.Button
    Private Sub InitializeComponent()
        Me.FileButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'FileButton
        '
        Me.FileButton.Location = New System.Drawing.Point(80, 40)
        Me.FileButton.Name = "FileButton"
        Me.FileButton.TabIndex = 0
        Me.FileButton.Text = "Button2"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.FileButton)
        Me.Name = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
    


    '<snippet3>
    '<snippet2>
    Private Sub TextBox1_Validating(ByVal sender As Object, _
    ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles TextBox1.Validating

        ' If nothing is entered,
        ' an ArgumentException is caught; if an invalid directory is entered, 
        ' a DirectoryNotFoundException is caught. An appropriate error message 
        ' is displayed in either case.
        Try
            Dim directory As New System.IO.DirectoryInfo(TextBox1.Text)
            directory.GetFiles()
            ErrorProvider1.SetError(TextBox1, "")

        Catch ex1 As System.ArgumentException
            ErrorProvider1.SetError(TextBox1, "Please enter a directory")

        Catch ex2 As System.IO.DirectoryNotFoundException
            ErrorProvider1.SetError(TextBox1, _
            "The directory does not exist." & _
            "Try again with a different directory.")
        End Try

    End Sub
    '</snippet3>

    ' This method handles the LostFocus event for TextBox1 by setting the 
    ' dialog's InitialDirectory property to the text in TextBox1.
    Private Sub TextBox1_LostFocus(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        OpenFileDialog1.InitialDirectory = TextBox1.Text
    End Sub


    ' This method demonstrates using the ErrorProvider.GetError method 
    ' to check for an error before opening the dialog box.
    Private Sub Button1_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles Button1.Click

        'If there is no error, then open the dialog box.
        If ErrorProvider1.GetError(TextBox1) = "" Then
            Dim dialogResult As DialogResult = OpenFileDialog1.ShowDialog()
        End If

    End Sub
    '</snippet2>

    ' These methods demonstrate  the handling of the FileOk event and the 
    ' use of the Application.DoEvents method.  
    ' A user selects graphics files from an OpenFileDialog object.  
    ' The files are displayed in the form.  The Application.DoEvents
    ' method forces a repaint of the form for each graphics file opened.
    '<snippet1>
    Private Sub InitializePictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox1.BorderStyle = _
            System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        Me.PictureBox1.Location = New System.Drawing.Point(72, 112)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(160, 136)
        Me.PictureBox1.TabStop = False
    End Sub

    '<snippet6>
    Private Sub InitializeOpenFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog

        ' Set the file dialog to filter for graphics files.
        Me.OpenFileDialog1.Filter = _
        "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*"

        ' Allow the user to select multiple images.
        Me.OpenFileDialog1.Multiselect = True
        Me.OpenFileDialog1.Title = "My Image Browser"
    End Sub

    Private Sub fileButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles FileButton.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    '</snippet6>

    ' This method handles the FileOK event.  It opens each file 
    ' selected and loads the image from a stream into PictureBox1.
    Private Sub OpenFileDialog1_FileOk(ByVal sender As Object, _
    ByVal e As System.ComponentModel.CancelEventArgs) _
     Handles OpenFileDialog1.FileOk

        Me.Activate()
        Dim file, files() As String
        files = OpenFileDialog1.FileNames

        ' Open each file and display the image in PictureBox1.
        ' Call Application.DoEvents to force a repaint after each
        ' file is read.        
        For Each file In files
            Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(file)
            Dim fileStream As System.IO.FileStream = fileInfo.OpenRead()
            PictureBox1.Image = System.Drawing.Image.FromStream(fileStream)
            Application.DoEvents()
            fileStream.Close()

            ' Call Sleep so the picture is briefly displayed, 
            'which will create a slide-show effect.
            System.Threading.Thread.Sleep(2000)
        Next
        PictureBox1.Image = Nothing
    End Sub

    '</snippet1>

End Class


