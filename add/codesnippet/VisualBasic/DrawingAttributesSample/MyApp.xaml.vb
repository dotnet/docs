' Interaction logic for MyApp.xaml
Partial Public Class MyApp
    Inherits Application

    Private Sub AppStartup(ByVal sender As Object, ByVal e As StartupEventArgs) Handles Me.Startup
        Dim mainWindow As Window1 = New Window1
        mainWindow.Show()
    End Sub

End Class

