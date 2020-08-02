Imports System.Configuration
Imports System.Data
Imports System.Windows
Imports System.Xml

Namespace AdornersMiscCode
    ''' <summary>
    ''' Interaction logic for MyApp.xaml
    ''' </summary>

    Partial Public Class MyApp
        Inherits Application

        Private Sub AppStartup(ByVal sender As Object, ByVal args As StartupEventArgs)
            Dim mainWindow As New Window1()
            mainWindow.Show()
        End Sub

    End Class
End Namespace
