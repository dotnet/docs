
Imports System
Imports System.Windows
Imports System.Data
Imports System.Xml
Imports System.Configuration


'/ <summary>
'/ Interaction logic for MyApp.xaml
'/ </summary>
Namespace StrokeSnippets_VB

    Class MyApp
        Inherits Application
        '
        'ToDo: Error processing original source shown below
        '
        '    public partial class MyApp : Application
        '------------^--- 'class', 'struct', 'interface' or 'delegate' expected
        '
        'ToDo: Error processing original source shown below
        '
        '    public partial class MyApp : Application
        '--------------------^--- Syntax error: ';' expected
        Private Sub AppStartingUp(ByVal sender As Object, ByVal e As StartupEventArgs)
            Dim mainWindow As New Window1()
            mainWindow.Show()

        End Sub 'AppStartingUp
    End Class 'MyApp 
    '
    'ToDo: Error processing original source shown below
    '    }
    '}
    '-^--- expression expected
End Namespace