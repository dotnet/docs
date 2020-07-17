Imports System.Threading

Namespace DockPanel_SetDock
    Public Class app
        Inherits Application

        Private dp1 As DockPanel
        Private txt1 As TextBlock
        Private _mainWindow As Window

        Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
            MyBase.OnStartup(e)
            CreateAndShowMainWindow()
        End Sub

        Private Sub CreateAndShowMainWindow()
            ' Create the application's main window
            _mainWindow = New Window()
            ' <Snippet1>
            ' Create the Panel DockPanel
            dp1 = New DockPanel()

            ' Create a Text Control and then set its Dock property
            txt1 = New TextBlock()
            DockPanel.SetDock(txt1, Dock.Top)
            txt1.Text = "The Dock Property is set to " & DockPanel.GetDock(txt1).ToString()
            dp1.Children.Add(txt1)
            _mainWindow.Content = dp1
            _mainWindow.Show()
            '</Snippet1>
        End Sub
    End Class

    Friend NotInheritable Class EntryClass
        <STAThread()>
        Shared Sub Main()
            Dim app As New app()
            app.Run()
        End Sub
    End Class

End Namespace

