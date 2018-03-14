' <snippet1>
Imports System
Imports System.Threading.Tasks
Imports System.Threading.Tasks.Dataflow

' Demonstrates a basic producer and consumer pattern that uses dataflow.
Friend Class DataflowProducerConsumer
   ' Demonstrates the production end of the producer and consumer pattern.
   Private Shared Sub Produce(ByVal target As ITargetBlock(Of Byte()))
      ' Create a Random object to generate random data.
      Dim rand As New Random()

      ' In a loop, fill a buffer with random data and
      ' post the buffer to the target block.
      For i As Integer = 0 To 99
         ' Create an array to hold random byte data.
         Dim buffer(1023) As Byte

         ' Fill the buffer with random bytes.
         rand.NextBytes(buffer)

         ' Post the result to the message block.
         target.Post(buffer)
      Next i

      ' Set the target to the completed state to signal to the consumer
      ' that no more data will be available.
      target.Complete()
   End Sub

   ' Demonstrates the consumption end of the producer and consumer pattern.
   Private Shared async Function ConsumeAsync(ByVal source As ISourceBlock(Of Byte())) As Task(Of Integer)
      ' Initialize a counter to track the number of bytes that are processed.
      Dim bytesProcessed As Integer = 0

      ' Read from the source buffer until the source buffer has no 
      ' available output data.
      Do While await source.OutputAvailableAsync()
         Dim data() As Byte = source.Receive()

         ' Increment the count of bytes received.
         bytesProcessed += data.Length
      Loop

      Return bytesProcessed
   End Function

   Shared Sub Main(ByVal args() As String)
      ' Create a BufferBlock<byte[]> object. This object serves as the 
      ' target block for the producer and the source block for the consumer.
      Dim buffer = New BufferBlock(Of Byte())()

      ' Start the consumer. The Consume method runs asynchronously. 
      Dim consumer = ConsumeAsync(buffer)

      ' Post source data to the dataflow block.
      Produce(buffer)

      ' Wait for the consumer to process all data.
      consumer.Wait()

      ' Print the count of bytes processed to the console.
      Console.WriteLine("Processed {0} bytes.", consumer.Result)
   End Sub
End Class

' Output:
'Processed 102400 bytes.
'
' </snippet1>

Friend Class Program2
   ' <snippet2>
   ' Demonstrates the consumption end of the producer and consumer pattern.
   Private Shared async Function ConsumeAsync(ByVal source As IReceivableSourceBlock(Of Byte())) As Task(Of Integer)
      ' Initialize a counter to track the number of bytes that are processed.
      Dim bytesProcessed As Integer = 0

      ' Read from the source buffer until the source buffer has no 
      ' available output data.
      Do While await source.OutputAvailableAsync()
         Dim data() As Byte
         Do While source.TryReceive(data)
            ' Increment the count of bytes received.
            bytesProcessed += data.Length
         Loop
      Loop

      Return bytesProcessed
   End Function
   ' </snippet2>
End Class
