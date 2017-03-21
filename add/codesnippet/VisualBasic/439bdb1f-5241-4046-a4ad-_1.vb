    Shared Sub Main()

        ' Create a synchronization object that gets 
        ' signaled when verification is complete.
        Dim manualEvent As New ManualResetEvent(False)

        ' Create random data to write to the file.
        Dim writeArray(100000) As Byte
        Dim randomGenerator As New Random()
        randomGenerator.NextBytes(writeArray)

        Dim fStream As New FileStream("Test#@@#.dat", _
            FileMode.Create, FileAccess.ReadWrite, _
            FileShare.None, 4096, True)

        ' Check that the FileStream was opened asynchronously.
        If fStream.IsAsync = True
            Console.WriteLine("fStream was opened asynchronously.")
        Else
            Console.WriteLine("fStream was not opened asynchronously.")
        End If

        ' Asynchronously write to the file.
        Dim asyncResult As IAsyncResult = fStream.BeginWrite( _
            writeArray, 0, writeArray.Length, _
            AddressOf EndWriteCallback , _
            New State(fStream, writeArray, manualEvent))

        ' Concurrently do other work and then wait
        ' for the data to be written and verified.
        manualEvent.WaitOne(5000, False)
    End Sub