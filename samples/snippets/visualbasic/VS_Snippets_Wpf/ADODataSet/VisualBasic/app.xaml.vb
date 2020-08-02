Imports System.Configuration
Imports System.Data
Imports System.Windows
Imports System.Xml

Namespace SDKSample
    ''' <summary>
    ''' Interaction logic for app.xaml
    ''' </summary>

    Partial Public Class app
        Inherits Application
        Private Sub AppStartingUp(ByVal sender As Object, ByVal e As StartupEventArgs)
            Dim mainWindow As New Window1()
            mainWindow.Show()
        End Sub
    End Class
End Namespace
