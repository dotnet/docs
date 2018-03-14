'<snippet1>
Imports System
Imports System.IO
Imports System.Diagnostics

Class IORedirExample
    Public Shared Sub Main()
        Dim args() As String = Environment.GetCommandLineArgs()
        If args.Length > 1
            ' This is the code for the spawned process
            Console.WriteLine("Hello from the redirected process!")
        Else
            ' This is the code for the base process
            Dim myProcess As New Process()
            ' Start a new instance of this program but specify the 'spawned' version.
            Dim myProcessStartInfo As New ProcessStartInfo(args(0), "spawn")
            myProcessStartInfo.UseShellExecute = False
            myProcessStartInfo.RedirectStandardOutput = True
            myProcess.StartInfo = myProcessStartInfo
            myProcess.Start()
            Dim myStreamReader As StreamReader = myProcess.StandardOutput
            ' Read the standard output of the spawned process.
            Dim myString As String = myStreamReader.ReadLine()
            Console.WriteLine(myString)

            myProcess.WaitForExit()
            myProcess.Close()
        End If
    End Sub
End Class
'</snippet1>
'<snippet2>
Imports System
Imports System.IO
Imports System.Diagnostics

Module Module1
    Sub Main()
        Dim process As New Process()
        process.StartInfo.FileName = "ipconfig.exe"
        process.StartInfo.UseShellExecute = False
        process.StartInfo.RedirectStandardOutput = True
        process.Start()

        ' Synchronously read the standard output of the spawned process. 
        Dim reader As StreamReader = process.StandardOutput
        Dim output As String = reader.ReadToEnd()
        Console.WriteLine(output)

        process.WaitForExit()
        process.Close()

        Console.WriteLine(Environment.NewLine + Environment.NewLine + "Press any key to exit.")
        Console.ReadLine()
    End Sub
End Module
'</snippet2>
