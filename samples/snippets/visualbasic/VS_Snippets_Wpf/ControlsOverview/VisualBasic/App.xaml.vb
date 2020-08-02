
Imports System.Configuration
Imports System.Data
Imports System.Windows
Imports System.Xml


'/ <summary>
'/ Interaction logic for App.xaml
'/ </summary>

Partial Class App
    Inherits System.Windows.Application

    Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
        MyBase.OnStartup(e)
        Dim win2 As New AppInCode()
        win2.Show()

    End Sub
End Class


