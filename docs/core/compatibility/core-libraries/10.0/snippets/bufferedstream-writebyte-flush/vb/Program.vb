Imports System
Imports System.IO

Module Program
    Sub Main()
        ' Main entry point
    End Sub
End Module

' <PreviousBehavior>
Module PreviousBehaviorExample
    Sub Example()
        Dim streamWithFlush As New StreamWithFlush()
        Dim bufferedStream As New BufferedStream(streamWithFlush, bufferSize:=4)

        ' Write 4 bytes to fill the buffer
        bufferedStream.WriteByte(1)
        bufferedStream.WriteByte(2)
        bufferedStream.WriteByte(3)
        bufferedStream.WriteByte(4) ' In .NET 9 and earlier, this caused an implicit flush
    End Sub

    Class StreamWithFlush
        Inherits MemoryStream

        Public Overrides Sub Flush()
            Console.WriteLine("Flush was called.")
            MyBase.Flush()
        End Sub
    End Class
End Module
' </PreviousBehavior>

Module BeforeExample
    Sub Example()
        ' <Before>
        Dim bufferedStream As New BufferedStream(New MemoryStream(), bufferSize:=4)
        bufferedStream.WriteByte(1)
        bufferedStream.WriteByte(2)
        bufferedStream.WriteByte(3)
        bufferedStream.WriteByte(4) ' Implicit flush occurred here in .NET 9 and earlier
        ' </Before>
    End Sub
End Module

Module AfterExample
    Sub Example()
        ' <After>
        Dim bufferedStream As New BufferedStream(New MemoryStream(), bufferSize:=4)
        bufferedStream.WriteByte(1)
        bufferedStream.WriteByte(2)
        bufferedStream.WriteByte(3)
        bufferedStream.WriteByte(4)
        bufferedStream.Flush() ' Explicit flush
        ' </After>
    End Sub
End Module

