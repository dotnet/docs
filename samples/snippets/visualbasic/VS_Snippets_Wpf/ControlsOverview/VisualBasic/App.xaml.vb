
Imports System
Imports System.Windows
Imports System.Data
Imports System.Xml
Imports System.Configuration


'/ <summary>
'/ Interaction logic for App.xaml
'/ </summary>

Partial Class App
    Inherits System.Windows.Application

    Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
        MyBase.OnStartup(e)
        Dim win2 As New AppInCode()
        win2.Show()

    End Sub 'OnStartup 
End Class 'App


