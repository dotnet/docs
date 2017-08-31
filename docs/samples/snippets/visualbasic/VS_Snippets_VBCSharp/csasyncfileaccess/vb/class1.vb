' Using Async for File Access

'<Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks
'</Snippet1>


Public Class Class1

    '<Snippet2>
    Public Async Sub ProcessWrite()
        Dim filePath = "temp2.txt"
        Dim text = "Hello World" & ControlChars.CrLf

        Await WriteTextAsync(filePath, text)
    End Sub

    Private Async Function WriteTextAsync(filePath As String, text As String) As Task
        Dim encodedText As Byte() = Encoding.Unicode.GetBytes(text)

        Using sourceStream As New FileStream(filePath,
            FileMode.Append, FileAccess.Write, FileShare.None,
            bufferSize:=4096, useAsync:=True)

            Await sourceStream.WriteAsync(encodedText, 0, encodedText.Length)
        End Using
    End Function
    '</Snippet2>


    Private Async Function WriteTextAsync2(filePath As String, text As String) As Task
        Dim encodedText As Byte() = Encoding.Unicode.GetBytes(text)

        Using sourceStream As New FileStream(filePath,
            FileMode.Append, FileAccess.Write, FileShare.None,
            bufferSize:=4096, useAsync:=True)

            '<Snippet3>
            Dim theTask As Task = sourceStream.WriteAsync(encodedText, 0, encodedText.Length)
            Await theTask
            '</Snippet3>
        End Using
    End Function


    '<Snippet4>
    Public Async Sub ProcessRead()
        Dim filePath = "temp2.txt"

        If File.Exists(filePath) = False Then
            Debug.WriteLine("file not found: " & filePath)
        Else
            Try
                Dim text As String = Await ReadTextAsync(filePath)
                Debug.WriteLine(text)
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
        End If
    End Sub

    Private Async Function ReadTextAsync(filePath As String) As Task(Of String)

        Using sourceStream As New FileStream(filePath,
            FileMode.Open, FileAccess.Read, FileShare.Read,
            bufferSize:=4096, useAsync:=True)

            Dim sb As New StringBuilder

            Dim buffer As Byte() = New Byte(&H1000) {}
            Dim numRead As Integer
            numRead = Await sourceStream.ReadAsync(buffer, 0, buffer.Length)
            While numRead <> 0
                Dim text As String = Encoding.Unicode.GetString(buffer, 0, numRead)
                sb.Append(text)

                numRead = Await sourceStream.ReadAsync(buffer, 0, buffer.Length)
            End While

            Return sb.ToString
        End Using
    End Function
    '</Snippet4>


    '<Snippet5>
    Public Async Sub ProcessWriteMult()
        Dim folder = "tempfolder\"
        Dim tasks As New List(Of Task)
        Dim sourceStreams As New List(Of FileStream)

        Try
            For index = 1 To 10
                Dim text = "In file " & index.ToString & ControlChars.CrLf

                Dim fileName = "thefile" & index.ToString("00") & ".txt"
                Dim filePath = folder & fileName

                Dim encodedText As Byte() = Encoding.Unicode.GetBytes(text)

                Dim sourceStream As New FileStream(filePath,
                    FileMode.Append, FileAccess.Write, FileShare.None,
                    bufferSize:=4096, useAsync:=True)

                Dim theTask As Task = sourceStream.WriteAsync(encodedText, 0, encodedText.Length)
                sourceStreams.Add(sourceStream)

                tasks.Add(theTask)
            Next

            Await Task.WhenAll(tasks)
        Finally
            For Each sourceStream As FileStream In sourceStreams
                sourceStream.Close()
            Next
        End Try
    End Sub
    '</Snippet5>

End Class
