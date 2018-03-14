' <Snippet2>
Imports System
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
        w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), _
            DateTime.Now.ToLongDateString())
        w.WriteLine("  :")
        w.WriteLine("  :{0}", logMessage)
        w.WriteLine ("-------------------------------")
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
' </Snippet2>
