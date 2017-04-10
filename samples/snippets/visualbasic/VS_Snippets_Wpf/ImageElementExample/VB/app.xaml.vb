
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.Windows.Navigation
Imports System.Data
Imports System.Xml
Imports System.Configuration

Namespace ImageElementExample

    ' <summary>
    ' Interaction logic for app.xaml
    ' </summary>

    Partial Class app
        Inherits Application
        Private Sub AppStartingUp(ByVal sender As Object, ByVal e As StartupEventArgs)
            Dim mainWindow As New SampleViewer()
            mainWindow.Show()

        End Sub 'AppStartingUp
    End Class 'app
End Namespace 'ImageElementExample