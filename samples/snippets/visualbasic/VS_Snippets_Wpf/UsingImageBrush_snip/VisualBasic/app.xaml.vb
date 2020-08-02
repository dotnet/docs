Imports System.Configuration
Imports System.Data
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Xml

Namespace Microsoft.Samples.Graphics.UsingImageBrush
    ''' <summary>
    ''' Interaction logic for Application.xaml
    ''' </summary>

    Partial Public Class app
        Inherits Application

        Private Sub AppStartingUp(ByVal sender As Object, ByVal e As StartupEventArgs)
            AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException

            Dim mainWindow As Window = New MyWindow()
            mainWindow.Show()
            mainWindow.Height = 600
            Me.MainWindow.Width = 800

        End Sub

        Private Sub CurrentDomain_UnhandledException(ByVal sender As Object, ByVal args As UnhandledExceptionEventArgs)
            MessageBox.Show("Unhandled exception: " & args.ExceptionObject.ToString())
        End Sub

    End Class
End Namespace
