Imports System.Windows
Imports System.Data
Imports System.Xml
Imports System.Configuration
Imports System.Windows.Input
Imports System.Windows.Media

Namespace SDKSample
    ''' <summary>
    ''' Interaction logic for app.xaml
    ''' </summary>

    Partial Public Class app
        Inherits Application
        Private Sub AppStartingUp(sender As Object, e As StartupEventArgs)
            Dim mainWindow As New Window1()
            mainWindow.Show()

        End Sub

    End Class
End Namespace
