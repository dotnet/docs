' <Snippet1>
Imports System
Imports System.IO
Imports System.Threading

Class FStream

' <Snippet2>
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
' </Snippet2>

    ' When BeginWrite is finished writing data to the file, the
    ' EndWriteCallback method is called to end the asynchronous 
    ' write operation and then read back and verify the data.
' <Snippet3>
    Private Shared Sub EndWriteCallback(asyncResult As IAsyncResult)
        Dim tempState As State = _
            DirectCast(asyncResult.AsyncState, State)
        Dim fStream As FileStream = tempState.FStream
        fStream.EndWrite(asyncResult)

        ' Asynchronously read back the written data.
        fStream.Position = 0
        asyncResult = fStream.BeginRead( _ 
            tempState.ReadArray, 0 , tempState.ReadArray.Length, _
            AddressOf EndReadCallback, tempState)

        ' Concurrently do other work, such as 
        ' logging the write operation.
    End Sub
 ' </Snippet3>

    ' When BeginRead is finished reading data from the file, the 
    ' EndReadCallback method is called to end the asynchronous 
    ' read operation and then verify the data.
 ' <Snippet4>
   Private Shared Sub EndReadCallback(asyncResult As IAsyncResult)
        Dim tempState As State = _
            DirectCast(asyncResult.AsyncState, State)
        Dim readCount As Integer = _
            tempState.FStream.EndRead(asyncResult)

        Dim i As Integer = 0
        While(i < readCount)
            If(tempState.ReadArray(i) <> tempState.WriteArray(i))
                Console.WriteLine("Error writing data.")
                tempState.FStream.Close()
                Return
            End If
            i += 1
        End While

        Console.WriteLine("The data was written to {0} and " & _
            "verified.", tempState.FStream.Name)
        tempState.FStream.Close()

        ' Signal the main thread that the verification is finished.
        tempState.ManualEvent.Set()
    End Sub
' </Snippet4>

    ' Maintain state information to be passed to 
    ' EndWriteCallback and EndReadCallback.
    Private Class State

        ' fStreamValue is used to read and write to the file.
        Dim fStreamValue As FileStream

        ' writeArrayValue stores data that is written to the file.
        Dim writeArrayValue As Byte()

        ' readArrayValue stores data that is read from the file.
        Dim readArrayValue As Byte()

        ' manualEvent signals the main thread 
        ' when verification is complete.
        Dim manualEventValue As ManualResetEvent 

        Sub New(aStream As FileStream, anArray As Byte(), _
            manualEvent As ManualResetEvent)

            fStreamValue     = aStream
            writeArrayValue  = anArray
            manualEventValue = manualEvent
            readArrayValue   = New Byte(anArray.Length - 1){}
        End Sub    

            Public ReadOnly Property FStream() As FileStream
                Get
                    Return fStreamValue
                End Get
            End Property

            Public ReadOnly Property WriteArray() As Byte()
                Get
                    Return writeArrayValue
                End Get
            End Property

            Public ReadOnly Property ReadArray() As Byte()
                Get
                    Return readArrayValue
                End Get
            End Property

            Public ReadOnly Property ManualEvent() As ManualResetEvent
                Get
                    Return manualEventValue
                End Get
            End Property
    End Class 
   
End Class
' </Snippet1>