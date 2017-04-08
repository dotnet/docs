Imports Microsoft.VisualBasic
Imports System
Imports System.Windows

Namespace VisualBasic
    Partial Public Class App
        Inherits Application
        Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
            MyBase.OnStartup(e)

            '<SnippetGetApplicationMainWindowCODE>
            ' Get the main window
            Dim mainWindow As Window = Me.MainWindow
            '</SnippetGetApplicationMainWindowCODE>
        End Sub
    End Class
End Namespace
