Imports System.IO
Imports System.Diagnostics

Module Module1
    Sub Main()
        Using process As New Process()
            process.StartInfo.FileName = "ipconfig.exe"
            process.StartInfo.UseShellExecute = False
            process.StartInfo.RedirectStandardOutput = True
            process.Start()

            ' Synchronously read the standard output of the spawned process. 
            Dim reader As StreamReader = process.StandardOutput
            Dim output As String = reader.ReadToEnd()
            Console.WriteLine(output)

            process.WaitForExit()
        End Using

        Console.WriteLine(Environment.NewLine + Environment.NewLine + "Press any key to exit.")
        Console.ReadLine()
    End Sub
End Module