'<Snippet4>
Imports System
Imports System.IO
Imports System.Diagnostics
Imports System.Text

Module Module1
    Dim lineCount As Integer = 0
    Dim output As StringBuilder = New StringBuilder()

    Sub Main()
        Dim process As New Process()
        process.StartInfo.FileName = "ipconfig.exe"
        process.StartInfo.UseShellExecute = False
        process.StartInfo.RedirectStandardOutput = True
        AddHandler process.OutputDataReceived, AddressOf OutputHandler
        process.Start()

        ' Asynchronously read the standard output of the spawned process. 
        ' This raises OutputDataReceived events for each line of output.
        process.BeginOutputReadLine()
        process.WaitForExit()

        Console.WriteLine(output)

        process.WaitForExit()
        process.Close()

        Console.WriteLine(Environment.NewLine + Environment.NewLine + "Press any key to exit.")
        Console.ReadLine()
    End Sub

    Sub OutputHandler(sender As Object, e As DataReceivedEventArgs)
        If Not String.IsNullOrEmpty(e.Data) Then
            lineCount += 1

            ' Add the text to the collected output.
            output.Append(Environment.NewLine + "[" + lineCount.ToString() + "]: " + e.Data)
        End If
    End Sub
End Module
'</Snippet4>