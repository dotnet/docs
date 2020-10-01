' <snippet1>
Imports System.Threading.Tasks
Imports System.Threading.Tasks.Dataflow

Friend Class DataflowProducerConsumer
    Private Shared Sub Produce(ByVal target As ITargetBlock(Of Byte()))
        Dim rand As New Random()

        For i As Integer = 0 To 99
            Dim buffer(1023) As Byte
            rand.NextBytes(buffer)
            target.Post(buffer)
        Next i

        target.Complete()
    End Sub

    Private Shared Async Function ConsumeAsync(
        ByVal source As ISourceBlock(Of Byte())) As Task(Of Integer)
        Dim bytesProcessed As Integer = 0

        Do While Await source.OutputAvailableAsync()
            Dim data() As Byte = Await source.ReceiveAsync()
            bytesProcessed += data.Length
        Loop

        Return bytesProcessed
    End Function

    Shared Sub Main()
        Dim buffer = New BufferBlock(Of Byte())()
        Dim consumer = ConsumeAsync(buffer)
        Produce(buffer)

        Dim result = consumer.GetAwaiter().GetResult()

        Console.WriteLine($"Processed {result:#,#} bytes.")
    End Sub
End Class

' Sample output:
'     Processed 102,400 bytes.
' </snippet1>

Friend Class Program2
    ' <snippet2>
    Private Shared Async Function ConsumeAsync(
        ByVal source As IReceivableSourceBlock(Of Byte())) As Task(Of Integer)
        Dim bytesProcessed As Integer = 0
        
        Do While Await source.OutputAvailableAsync()
            Dim data() As Byte
            Do While source.TryReceive(data)
                bytesProcessed += data.Length
            Loop
        Loop

        Return bytesProcessed
    End Function
    ' </snippet2>
End Class
