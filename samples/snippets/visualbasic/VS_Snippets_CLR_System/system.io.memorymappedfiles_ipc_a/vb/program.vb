' <Snippet1>
Imports System.IO
Imports System.IO.MemoryMappedFiles
Imports System.Threading

Module Module1
    ' Process B:
    Sub Main()
        Try
            Using mmf As MemoryMappedFile = MemoryMappedFile.OpenExisting("testmap")
                Dim mTex As Mutex = Mutex.OpenExisting("testmapmutex")
                mTex.WaitOne()
                Using Stream As MemoryMappedViewStream = mmf.CreateViewStream(1, 0)
                    Dim writer As BinaryWriter = New BinaryWriter(Stream)
                    writer.Write(0)
                End Using
                mTex.ReleaseMutex()
            End Using
        Catch noFile As FileNotFoundException
            Console.WriteLine("Memory-mapped file does not exist. Run Process A first." & vbCrLf & noFile.Message)
        End Try

    End Sub

End Module
' </Snippet1>
