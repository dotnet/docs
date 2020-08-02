Imports System.Configuration
Imports System.Data
Imports System.Windows
Imports System.Xml

Namespace SDKSample
    ''' <summary>
    ''' Interaction logic for App.xaml
    ''' </summary>

    Partial Public Class App
        Inherits Application
        Private Sub AppStartingUp(ByVal sender As Object, ByVal e As StartupEventArgs)
            Dim mainWindow As New Window1()
            mainWindow.InitializeComponent()
            mainWindow.Show()
        End Sub
    End Class
End Namespace
