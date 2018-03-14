Imports System
Imports System.Windows

Public Class App
    Inherits Application

    ' Methods
    Private Sub AppStartingUp(ByVal sender As Object, ByVal e As StartupEventArgs)
        Dim mainWindow As New Window1
        mainWindow.Show()
    End Sub

End Class


