
Imports System.Windows
Imports System.Data
Imports System.Xml
Imports System.Configuration


'/ <summary>
'/ Interaction logic for MyApp.xaml
'/ </summary>

Class MyApp
    Inherits Application

    Dim win As New Window1()

    Protected Overrides Sub OnStartup(ByVal args As StartupEventArgs)
        MyBase.OnStartup(args)
        win.Show()

    End Sub
End Class
'
'ToDo: Error processing original source shown below
'    }
'}
'-^--- expression expected