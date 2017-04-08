Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.IO
Imports System.Security

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
        Me.Text = "Form1"
    End Sub

    '<snippet1>

    Private Function OpenFile() As FileStream

        ' Displays an OpenFileDialog and shows the read/only files.

        Dim DlgOpenFile As New OpenFileDialog()
        DlgOpenFile.ShowReadOnly = True

        If DlgOpenFile.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim path As New String("")

            ' If ReadOnlyChecked is true, uses the OpenFile method to
            ' open the file with read/only access.
            Try
                If (DlgOpenFile.ReadOnlyChecked = True) Then
                    Return DlgOpenFile.OpenFile()
                Else
                    ' Otherwise, opens the file with read/write access.
                    Path = DlgOpenFile.FileName
                    Return New FileStream(Path, System.IO.FileMode.Open, _
                            System.IO.FileAccess.ReadWrite)
                End If
            Catch SecEx As SecurityException
                ' The user lacks appropriate permissions to read files, discover paths, etc.
                MessageBox.Show("Security error. Please contact your administrator for details.\n\n" & _
                    "Error message: " & SecEx.Message * "\n\n" & _
                    "Details (send to Support):\n\n" & SecEx.StackTrace)
            Catch Ex As Exception
                ' Could not load the image - probably related to Windows file system permissions.
                MessageBox.Show("Cannot display the image: " & path.Substring(path.LastIndexOf("\\")) & _
                         ". You may not have permission to read the file, or " & _
                        "it may be corrupt.\n\nReported error: " + ex.Message)
            End Try
        End If

        Return Nothing
    End Function

    '</snippet1>

#End Region

End Class