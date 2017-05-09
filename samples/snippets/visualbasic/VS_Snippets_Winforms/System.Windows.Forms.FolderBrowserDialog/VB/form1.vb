'<Snippet1>
' The following example displays an application that provides the ability to 
' open rich text files (rtf) into the RichTextBox. The example demonstrates 
' using the FolderBrowserDialog to set the default directory for opening files.
' The OpenFileDialog class is used to open the file.
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO

Public Class FolderBrowserDialogExampleForm 
    Inherits Form
    
    Private folderBrowserDialog1 As FolderBrowserDialog
    Private openFileDialog1 As OpenFileDialog 
    
    Private richTextBox1 As RichTextBox

    Private mainMenu1 As MainMenu
    Private fileMenuItem As MenuItem
    Private WithEvents folderMenuItem As MenuItem, _
                       closeMenuItem As MenuItem, _
                       openMenuItem As MenuItem
    
    Private openFileName As String, folderName As String

    Private fileOpened As Boolean = False

    Public Sub New()
        Me.mainMenu1 = New System.Windows.Forms.MainMenu() 
        Me.fileMenuItem = New System.Windows.Forms.MenuItem() 
        Me.openMenuItem = New System.Windows.Forms.MenuItem() 
        Me.folderMenuItem = New System.Windows.Forms.MenuItem() 
        Me.closeMenuItem = New System.Windows.Forms.MenuItem() 

        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog() 
        Me.folderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog() 
        Me.richTextBox1 = New System.Windows.Forms.RichTextBox() 

        Me.mainMenu1.MenuItems.Add(Me.fileMenuItem) 
        Me.fileMenuItem.MenuItems.AddRange( _
                    New System.Windows.Forms.MenuItem() {Me.openMenuItem, _
                                                         Me.closeMenuItem, _
                                                         Me.folderMenuItem}) 
        Me.fileMenuItem.Text = "File" 

        Me.openMenuItem.Text = "Open..." 

        Me.folderMenuItem.Text = "Select Directory..." 

        Me.closeMenuItem.Text = "Close" 
        Me.closeMenuItem.Enabled = False 

        Me.openFileDialog1.DefaultExt = "rtf" 
        Me.openFileDialog1.Filter = "rtf files (*.rtf)|*.rtf" 

        ' Set the Help text description for the FolderBrowserDialog.
        Me.folderBrowserDialog1.Description = _
            "Select the directory that you want to use As the default." 

        ' Do not allow the user to create New files via the FolderBrowserDialog.
        Me.folderBrowserDialog1.ShowNewFolderButton = False 

        ' Default to the My Documents folder.
        Me.folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Personal 

        Me.richTextBox1.AcceptsTab = True 
        Me.richTextBox1.Location = New System.Drawing.Point(8, 8) 
        Me.richTextBox1.Size = New System.Drawing.Size(280, 344) 
        Me.richTextBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or _
                                 AnchorStyles.Bottom Or AnchorStyles.Right 

        Me.ClientSize = New System.Drawing.Size(296, 360) 
        Me.Controls.Add(Me.richTextBox1) 
        Me.Menu = Me.mainMenu1 
        Me.Text = "RTF Document Browser" 
    End Sub
    
    <STAThread()> _
    Shared Sub Main()
        Application.Run(New FolderBrowserDialogExampleForm())
    End Sub

    ' Bring up a dialog to open a file.
    Private Sub openMenuItem_Click(sender As object, e As System.EventArgs) _
        Handles openMenuItem.Click
        ' If a file is not opened, then set the initial directory to the
        ' FolderBrowserDialog.SelectedPath value.
        If (not fileOpened) Then
            openFileDialog1.InitialDirectory = folderBrowserDialog1.SelectedPath 
            openFileDialog1.FileName = nothing 
        End If

        ' Display the openFile dialog.
        Dim result As DialogResult = openFileDialog1.ShowDialog() 

        ' OK button was pressed.
        If (result = DialogResult.OK) Then
            openFileName = openFileDialog1.FileName 
            Try
                ' Output the requested file in richTextBox1.
                Dim s As Stream = openFileDialog1.OpenFile() 
                richTextBox1.LoadFile(s, RichTextBoxStreamType.RichText) 
                s.Close()     
            
                fileOpened = True 

            Catch exp As Exception
                MessageBox.Show("An error occurred while attempting to load the file. The error is:" _
                                + System.Environment.NewLine + exp.ToString() + System.Environment.NewLine) 
                fileOpened = False 
            End Try
            Invalidate() 

            closeMenuItem.Enabled = fileOpened 

        ' Cancel button was pressed.
        ElseIf (result = DialogResult.Cancel) Then
            return 
        End If
    End Sub

    ' Close the current file.
    Private Sub closeMenuItem_Click(sender As object, e As System.EventArgs) _
        Handles closeMenuItem.Click
        richTextBox1.Text = "" 
        fileOpened = False 

        closeMenuItem.Enabled = False 
    End Sub

    ' Bring up a dialog to chose a folder path in which to open or save a file.
    Private Sub folderMenuItem_Click(sender As object, e As System.EventArgs) _
        Handles folderMenuItem.Click
        ' Show the FolderBrowserDialog.
        Dim result As DialogResult = folderBrowserDialog1.ShowDialog() 

        If ( result = DialogResult.OK ) Then
            folderName = folderBrowserDialog1.SelectedPath 
            If (not fileOpened) Then
                ' No file is opened, bring up openFileDialog in selected path.
                openFileDialog1.InitialDirectory = folderName 
                openFileDialog1.FileName = nothing
                openMenuItem.PerformClick() 
            End If
        End If
    End Sub

End Class
'</Snippet1>