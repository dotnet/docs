' <Snippet2>
Imports System.IO

Class DirAppend
    Public Shared Sub Main()
        Using w As StreamWriter = File.AppendText("log.txt")
            Log("Test1", w)
            Log("Test2", w)
        End Using

        Using r As StreamReader = File.OpenText("log.txt")
            DumpLog(r)
        End Using
    End Sub

    Public Shared Sub Log(logMessage As String, w As TextWriter)
        w.Write(vbCrLf + "Log Entry : ")
        w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}")
        w.WriteLine("  :")
        w.WriteLine($"  :{logMessage}")
        w.WriteLine("-------------------------------")
    End Sub

    Public Shared Sub DumpLog(r As StreamReader)
        Dim line As String
        line = r.ReadLine()
        While Not (line Is Nothing)
            Console.WriteLine(line)
            line = r.ReadLine()
        End While
    End Sub
End Class

' The example creates a file named "log.txt" and writes the following lines to it,
' or appends them to the existing "log.txt" file:

' Log Entry : <current long time string> <current long date string>
'  :
'  :Test1
' -------------------------------

' Log Entry : <current long time string> <current long date string>
'  :
'  :Test2
' -------------------------------

' It then writes the contents of "log.txt" to the console.
' </Snippet2>
