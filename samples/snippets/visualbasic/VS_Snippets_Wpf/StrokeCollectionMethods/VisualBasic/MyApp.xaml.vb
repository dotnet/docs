
Imports System
Imports System.Windows
Imports System.Data
Imports System.Xml
Imports System.Configuration


'/ <summary>
'/ Interaction logic for MyApp.xaml
'/ </summary>
Namespace CustomInkControlSample
    Class MyApp
        Inherits Application

        Private Sub AppStartingUp(ByVal sender As Object, ByVal e As StartupEventArgs)
            'Dim mainWindow As New Window1()
            'mainWindow.Show()
            'mainWindow.WindowState = WindowState.Maximized

            Dim secondWindow As New Window2()
            secondWindow.Show()

            'Dim thirdWindow As New Window3()
            'thirdWindow.Show()

        End Sub 'AppStartingUp
    End Class 'MyApp 
End Namespace