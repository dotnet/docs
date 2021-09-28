' <snippet1>
Imports System.IO
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Threading.Tasks.Dataflow

' Demonstrates how to provide delegates to exectution dataflow blocks.
Friend Class DataflowExecutionBlocks
    ' Computes the number of zero bytes that the provided file
    ' contains.
    Private Shared Function CountBytes(ByVal path As String) As Integer
        Dim buffer(1023) As Byte
        Dim totalZeroBytesRead As Integer = 0
        Using fileStream = File.OpenRead(path)
            Dim bytesRead As Integer = 0
            Do
                bytesRead = fileStream.Read(buffer, 0, buffer.Length)
                totalZeroBytesRead += buffer.Count(Function(b) b = 0)
            Loop While bytesRead > 0
        End Using

        Return totalZeroBytesRead
    End Function

    Shared Sub Main(ByVal args() As String)
        ' Create a temporary file on disk.
        Dim tempFile As String = Path.GetTempFileName()

        ' Write random data to the temporary file.
        Using fileStream = File.OpenWrite(tempFile)
            Dim rand As New Random()
            Dim buffer(1023) As Byte
            For i As Integer = 0 To 511
                rand.NextBytes(buffer)
                fileStream.Write(buffer, 0, buffer.Length)
            Next i
        End Using

        ' Create an ActionBlock<int> object that prints to the console 
        ' the number of bytes read.
        Dim printResult = New ActionBlock(Of Integer)(Sub(zeroBytesRead) Console.WriteLine("{0} contains {1} zero bytes.", Path.GetFileName(tempFile), zeroBytesRead))

        ' Create a TransformBlock<string, int> object that calls the 
        ' CountBytes function and returns its result.
        Dim countBytes = New TransformBlock(Of String, Integer)(New Func(Of String, Integer)(AddressOf DataflowExecutionBlocks.CountBytes))

        ' Link the TransformBlock<string, int> object to the 
        ' ActionBlock<int> object.
        countBytes.LinkTo(printResult)

        ' Create a continuation task that completes the ActionBlock<int>
        ' object when the TransformBlock<string, int> finishes.
        countBytes.Completion.ContinueWith(Sub() printResult.Complete())

        ' Post the path to the temporary file to the 
        ' TransformBlock<string, int> object.
        countBytes.Post(tempFile)

        ' Requests completion of the TransformBlock<string, int> object.
        countBytes.Complete()

        ' Wait for the ActionBlock<int> object to print the message.
        printResult.Completion.Wait()

        ' Delete the temporary file.
        File.Delete(tempFile)
    End Sub
End Class

' Sample output:
'tmp4FBE.tmp contains 2081 zero bytes.
'
' </snippet1>


Friend Class Program2
    ' <snippet2>
    ' Asynchronously computes the number of zero bytes that the provided file 
    ' contains.
    Private Shared async Function CountBytesAsync(ByVal path As String) As Task(Of Integer)
        Dim buffer(1023) As Byte
        Dim totalZeroBytesRead As Integer = 0
        Using fileStream = New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, &H1000, True)
            Dim bytesRead As Integer = 0
            Do
                ' Asynchronously read from the file stream.
                bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length)
                totalZeroBytesRead += buffer.Count(Function(b) b = 0)
            Loop While bytesRead > 0
        End Using

        Return totalZeroBytesRead
    End Function
    ' </snippet2>

    Private Shared Sub Foo()
        ' <snippet3>
        ' Create a TransformBlock<string, int> object that calls the 
        ' CountBytes function and returns its result.
        Dim countBytesAsync = New TransformBlock(Of String, Integer)(async Function(path)
                                                                         ' Asynchronously read from the file stream.
                                                                         Dim buffer(1023) As Byte
                                                                         Dim totalZeroBytesRead As Integer = 0
                                                                         Using fileStream = New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, &H1000, True)
                                                                             Dim bytesRead As Integer = 0
                                                                             Do
                                                                                 bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length)
                                                                                 totalZeroBytesRead += buffer.Count(Function(b) b = 0)
                                                                             Loop While bytesRead > 0
                                                                         End Using
                                                                         Return totalZeroBytesRead
                                                                     End Function)
        ' </snippet3>
    End Sub
End Class
