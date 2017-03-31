' <Snippet1>
Imports System.IO
Imports System.IO.MemoryMappedFiles
Imports System.Threading
Module Module1

    ' Process A:
    Sub Main()
        Using mmf As MemoryMappedFile = MemoryMappedFile.CreateNew("testmap", 10000)
            Dim mutexCreated As Boolean
            Dim mTex As Mutex = New Mutex(True, "testmapmutex", mutexCreated)
            ' <Snippet2>
            Using Stream As MemoryMappedViewStream = mmf.CreateViewStream()
                Dim writer As BinaryWriter = New BinaryWriter(Stream)
                writer.Write(1)
            End Using
            ' </Snippet2>
            mTex.ReleaseMutex()
            Console.WriteLine("Start Process B and press ENTER to continue.")
            Console.ReadLine()

            Console.WriteLine("Start Process C and press ENTER to continue.")
            Console.ReadLine()

            mTex.WaitOne()
            Using Stream As MemoryMappedViewStream = mmf.CreateViewStream()
                Dim reader As BinaryReader = New BinaryReader(Stream)
                Console.WriteLine("Process A says: {0}", reader.ReadBoolean())
                Console.WriteLine("Process B says: {0}", reader.ReadBoolean())
                Console.WriteLine("Process C says: {0}", reader.ReadBoolean())
            End Using
            mTex.ReleaseMutex()

        End Using

    End Sub

End Module
' </Snippet1>