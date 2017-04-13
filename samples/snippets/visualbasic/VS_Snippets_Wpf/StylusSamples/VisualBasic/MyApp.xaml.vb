
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
    Private Sub AppStartingUp(ByVal sender As Object, ByVal e As StartupEventArgs)
        Dim mainWindow As New Window1()
        mainWindow.Show()

        Dim secondWindow As New Window2()
        secondWindow.Show()

    End Sub 'AppStartingUp
End Class 'MyApp 
'
'ToDo: Error processing original source shown below
'    }
'}
'-^--- expression expected