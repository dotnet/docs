'<SnippetCustomEntryPointAndRunOL1CODE>

Imports Microsoft.VisualBasic
Imports System
Imports System.Windows

Namespace VisualBasic
    Public Class EntryPoint
        ' All WPF applications should execute on a single-threaded apartment (STA) thread
        <STAThread()>
              Public Shared Sub Main()
            Dim app As New Application()
            app.Run(New Window())
        End Sub
    End Class
End Namespace
'</SnippetCustomEntryPointAndRunOL1CODE>