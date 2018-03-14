' <Snippet1>
Imports System
Imports System.Diagnostics
Imports System.ComponentModel

Namespace MyProcessSample
    Class MyProcess
        Public Shared Sub Main()
            Dim myProcess As New Process()

            Try
                myProcess.StartInfo.UseShellExecute = False
                ' You can start any process, HelloWorld is a do-nothing example.
                myProcess.StartInfo.FileName = "C:\\HelloWorld.exe"
                myProcess.StartInfo.CreateNoWindow = True
                myProcess.Start()
                ' This code assumes the process you are starting will terminate itself. 
                ' Given that is is started without a window so you cannot terminate it 
                ' on the desktop, it must terminate itself or you can do it programmatically
                ' from this application using the Kill method.
            Catch e As Exception
                Console.WriteLine((e.Message))
            End Try
        End Sub 'Main
    End Class
End Namespace
' </Snippet1>