' <Snippet1>
Imports System
Imports System.Windows
Imports System.Windows.Controls


Class Program
    Inherits Application
    Private win As Window
    Private ic As InkCanvas


    Protected Overrides Sub OnStartup(ByVal args As StartupEventArgs)
        MyBase.OnStartup(args)
        win = New Window()
        ic = New InkCanvas()
        win.Content = ic
        win.Show()

    End Sub 'OnStartup

End Class 'Program

Module Module1

    Sub Main()
        Dim prog As New Program()
        prog.Run()

    End Sub

End Module
' </Snippet1>