' <Snippet1>
Imports System
Imports System.IO
Class Test
    
Public Shared Sub Main()
    ' Specify a file to read from and to create.
    Dim pathSource As String = "c:\tests\source.txt"
    Dim pathNew As String = "c:\tests\newfile.txt"
    Try 
        Using fsSource As FileStream = New FileStream(pathSource, _
            FileMode.Open, FileAccess.Read)
            ' Read the source file into a byte array.
                Dim bytes() As Byte = New Byte((fsSource.Length) - 1) {}
                Dim numBytesToRead As Integer = CType(fsSource.Length,Integer)
                Dim numBytesRead As Integer = 0

                While (numBytesToRead > 0)
                    ' Read may return anything from 0 to numBytesToRead.
                    Dim n As Integer = fsSource.Read(bytes, numBytesRead, _
                        numBytesToRead)
                    ' Break when the end of the file is reached.
                    If (n = 0) Then
                        Exit While
                    End If
                    numBytesRead = (numBytesRead + n)
                    numBytesToRead = (numBytesToRead - n)

                End While
            numBytesToRead = bytes.Length

            ' Write the byte array to the other FileStream.
            Using fsNew As FileStream = New FileStream(pathNew, _
                FileMode.Create, FileAccess.Write)
                fsNew.Write(bytes, 0, numBytesToRead)
            End Using
        End Using
    Catch ioEx As FileNotFoundException
        Console.WriteLine(ioEx.Message)
    End Try
End Sub
End Class
' </Snippet1>

