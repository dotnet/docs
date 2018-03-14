'<SnippetCustomEntryPointAndRunCODE>

Imports Microsoft.VisualBasic
Imports System
Imports System.Windows

Namespace VisualBasic
    Public Class EntryPoint
        ' All WPF applications should execute on a single-threaded apartment (STA) thread
        <STAThread()>
              Public Shared Sub Main()
            Dim app As New CustomApplication()
            app.Run()
        End Sub
    End Class

    Public Class CustomApplication
        Inherits Application
        Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
            MyBase.OnStartup(e)

            Dim window As New Window()
            window.Show()
        End Sub
    End Class
End Namespace
'</SnippetCustomEntryPointAndRunCODE>