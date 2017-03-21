'<SnippetWindowRestoreBoundsCODEBEHIND1>

Imports System
Imports System.ComponentModel
Imports System.IO
Imports System.IO.IsolatedStorage
Imports System.Windows

'</SnippetWindowRestoreBoundsCODEBEHIND1>
Namespace WindowRestoreBoundsSnippets
    '<SnippetWindowRestoreBoundsCODEBEHIND2>
    Partial Public Class MainWindow
        Inherits Window

        Private filename As String = "settings.txt"

        Public Sub New()
            InitializeComponent()

            ' Refresh restore bounds from previous window opening
            Dim storage As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForAssembly()
            Try
                Using stream As New IsolatedStorageFileStream(Me.filename, FileMode.Open, storage)
                    Using reader As New StreamReader(stream)

                        ' Read restore bounds value from file
                        Dim restoreBounds As Rect = Rect.Parse(reader.ReadLine())
                        Me.Left = restoreBounds.Left
                        Me.Top = restoreBounds.Top
                        Me.Width = restoreBounds.Width
                        Me.Height = restoreBounds.Height
                    End Using
                End Using
            Catch ex As FileNotFoundException
                ' Handle when file is not found in isolated storage, which is when:
                ' * This is first application session
                ' * The file has been deleted
            End Try

        End Sub

        Private Sub MainWindow_Closing(ByVal sender As Object, ByVal e As CancelEventArgs)
            ' Save restore bounds for the next time this window is opened
            Dim storage As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForAssembly()
            Using stream As New IsolatedStorageFileStream(Me.filename, FileMode.Create, storage)
                Using writer As New StreamWriter(stream)
                    ' Write restore bounds value to file
                    writer.WriteLine(Me.RestoreBounds.ToString())
                End Using
            End Using
        End Sub
    End Class
    '</SnippetWindowRestoreBoundsCODEBEHIND2>
End Namespace