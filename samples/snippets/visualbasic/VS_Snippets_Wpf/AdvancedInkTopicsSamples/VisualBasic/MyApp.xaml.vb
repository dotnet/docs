
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
    'public MyApp()
    '    : base()
    '{
    '    Window1 win = new Window1();
    '    win.Show();
    '}
    Private Sub AppStartup(ByVal sender As Object, ByVal args As StartupEventArgs)
        Dim mainWindow As New Window1()
        mainWindow.Show()

    End Sub 'AppStartup
End Class 'MyApp 
'
'ToDo: Error processing original source shown below
'    }
'}
'-^--- expression expected