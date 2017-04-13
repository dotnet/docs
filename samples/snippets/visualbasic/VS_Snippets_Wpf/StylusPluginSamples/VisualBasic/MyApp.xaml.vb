
Imports System
Imports System.Windows
Imports System.Data
Imports System.Xml
Imports System.Configuration


'/ <summary>
'/ Interaction logic for MyApp.xaml
'/ </summary>

Class MyApp
    Inherits Application

    Private Sub AppStartup(ByVal sender As Object, ByVal args As StartupEventArgs)

        Dim mainWindow As New Window1()
        mainWindow.Show()

        'Dim secondWindow As New Window2()
        'secondWindow.Show()
    End Sub 'AppStartup 
End Class 'MyApp 