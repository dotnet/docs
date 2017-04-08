' <Snippet1>
Imports Microsoft.VisualBasic
Imports System
Imports System.Web.Compilation
Imports System.IO

Namespace Samples.Process
    Public Class postProcessTest
        Implements IAssemblyPostProcessor

        Sub Main()

        End Sub

        Public Sub PostProcessAssembly(ByVal path As String) _
            Implements IAssemblyPostProcessor.PostProcessAssembly
            Dim sw As StreamWriter
            sw = File.CreateText("c:\compile\MyTest.txt")
            sw.WriteLine("Compiled assembly:")
            sw.WriteLine(path)
            sw.Close()
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose

        End Sub
    End Class
End Namespace
' </Snippet1>