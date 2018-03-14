' The following code example demonstrates using the 
' RichTextBox1.SaveFile and RichTextBox.LoadFile methods with streams.
' It also demonstrates using the FileDialog.FileName, 
' SaveFileDialog.CreatePrompt, SaveFileDialog.OverwritePrompt, and 
' TextBox.Click members.
'<snippet1>
Imports System
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

Partial Public Class Form1
    Inherits Form

    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog

    Public Sub New()
        MyBase.New()
        Me.RichTextBox1 = New RichTextBox
        Me.Button1 = New Button
        Me.RichTextBox2 = New RichTextBox
        Me.Button2 = New Button
        Me.SaveFileDialog1 = New SaveFileDialog
        Me.SuspendLayout()
        Me.RichTextBox1.Location = New Point(24, 64)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = "Type something here."
        Me.Button1.Location = New Point(96, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New Size(96, 24)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Save To Stream"
        Me.RichTextBox2.Location = New Point(152, 64)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.TabIndex = 3
        Me.RichTextBox2.Text = "It will be added to the stream and appear here."
        Me.Button2.Location = New Point(104, 200)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New Size(88, 32)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Save Stream To File"
        Me.ClientSize = New Size(292, 266)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.RichTextBox2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    ' Declare a new memory stream.
    Dim userInput As New MemoryStream

    ' Save the content of RichTextBox1 to the memory stream, appending
    'a LineFeed character.  
    Private Sub Button1_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles Button1.Click
        RichTextBox1.SaveFile(userInput, RichTextBoxStreamType.PlainText)
        userInput.WriteByte(13)

        ' Display the entire contents of the stream,
        ' by setting its position to 0, to RichTextBox2.
        userInput.Position = 0
        RichTextBox2.LoadFile(userInput, RichTextBoxStreamType.PlainText)
    End Sub

    ' Shows the use of a SaveFileDialog to save a MemoryStream to a file.
    Private Sub Button2_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles Button2.Click

        ' Set the properties on SaveFileDialog1 so the user is 
        ' prompted to create the file if it doesn't exist 
        ' or overwrite the file if it does exist.
        SaveFileDialog1.CreatePrompt = True
        SaveFileDialog1.OverwritePrompt = True

        ' Set the file name to myText.txt, set the type filter
        ' to text files, and set the initial directory to the 
        ' MyDocuments folder.
        SaveFileDialog1.FileName = "myText"
        ' DefaultExt is only used when "All files" is selected from 
        ' the filter box and no extension is specified by the user.
        SaveFileDialog1.DefaultExt = "txt"
        SaveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
        SaveFileDialog1.InitialDirectory = _
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

        ' Call ShowDialog and check for a return value of DialogResult.OK,
        ' which indicates that the file was saved. 
        Dim result As DialogResult = SaveFileDialog1.ShowDialog()
        Dim fileStream As Stream

        If (result = DialogResult.OK) Then
            ' Open the file, copy the contents of memoryStream to fileStream,
            ' and close fileStream. Set the memoryStream.Position value to 0 to 
            ' copy the entire stream. 
            fileStream = SaveFileDialog1.OpenFile()
            userInput.Position = 0
            userInput.WriteTo(fileStream)
            fileStream.Close()
        End If
    End Sub

End Class
'</snippet1>
