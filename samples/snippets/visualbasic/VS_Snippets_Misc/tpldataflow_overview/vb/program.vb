Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Threading.Tasks.Dataflow

Namespace Overview
   Friend Class Program
      Private Shared Sub ShowBufferBlock()
         ' <snippet1>
         ' Create a BufferBlock<int> object.
         Dim bufferBlock = New BufferBlock(Of Integer)()

         ' Post several messages to the block.
         For i As Integer = 0 To 2
            bufferBlock.Post(i)
         Next i

         ' Receive the messages back from the block.
         For i As Integer = 0 To 2
            Console.WriteLine(bufferBlock.Receive())
         Next i

'          Output:
'            0
'            1
'            2
'          
         ' </snippet1>
      End Sub

      Private Shared Sub ShowBroadcastBlock()
         ' <snippet2>
         ' Create a BroadcastBlock<double> object.
         Dim broadcastBlock = New BroadcastBlock(Of Double)(Nothing)

         ' Post a message to the block.
         broadcastBlock.Post(Math.PI)

         ' Receive the messages back from the block several times.
         For i As Integer = 0 To 2
            Console.WriteLine(broadcastBlock.Receive())
         Next i

'          Output:
'            3.14159265358979
'            3.14159265358979
'            3.14159265358979
'          
         ' </snippet2>
      End Sub

      Private Shared Sub ShowWriteOnceBlock()
         ' <snippet3>
         ' Create a WriteOnceBlock<string> object.
         Dim writeOnceBlock = New WriteOnceBlock(Of String)(Nothing)

         ' Post several messages to the block in parallel. The first 
         ' message to be received is written to the block. 
         ' Subsequent messages are discarded.
         Parallel.Invoke(Function() writeOnceBlock.Post("Message 1"), Function() writeOnceBlock.Post("Message 2"), Function() writeOnceBlock.Post("Message 3"))

         ' Receive the message from the block.
         Console.WriteLine(writeOnceBlock.Receive())

'          Sample output:
'            Message 2
'          
         ' </snippet3>
      End Sub

      Private Shared Sub ShowActionBlock()
         ' <snippet4>
         ' Create an ActionBlock<int> object that prints values
         ' to the console.
         Dim actionBlock = New ActionBlock(Of Integer)(Function(n) WriteLine(n))

         ' Post several messages to the block.
         For i As Integer = 0 To 2
            actionBlock.Post(i * 10)
         Next i

         ' Set the block to the completed state and wait for all 
         ' tasks to finish.
         actionBlock.Complete()
         actionBlock.Completion.Wait()

'          Output:
'            0
'            10
'            20
'          
         ' </snippet4>
      End Sub

      Private Shared Function WriteLine(ByVal n As Object)
        Console.WriteLine(n)
        Return Nothing
      End Function

      Private Shared Sub ShowTransformBlock()
         ' <snippet5>
         ' Create a TransformBlock<int, double> object that 
         ' computes the square root of its input.
         Dim transformBlock = New TransformBlock(Of Integer, Double)(Function(n) Math.Sqrt(n))

         ' Post several messages to the block.
         transformBlock.Post(10)
         transformBlock.Post(20)
         transformBlock.Post(30)

         ' Read the output messages from the block.
         For i As Integer = 0 To 2
            Console.WriteLine(transformBlock.Receive())
         Next i

'          Output:
'            3.16227766016838
'            4.47213595499958
'            5.47722557505166
'          
         ' </snippet5>
      End Sub

      Private Shared Sub ShowTransformManyBlock()
         ' <snippet6>
         ' Create a TransformManyBlock<string, char> object that splits
         ' a string into its individual characters.
         Dim transformManyBlock = New TransformManyBlock(Of String, Char)(Function(s) s.ToCharArray())

         ' Post two messages to the first block.
         transformManyBlock.Post("Hello")
         transformManyBlock.Post("World")

         ' Receive all output values from the block.
         For i As Integer = 0 To ("Hello" & "World").Length - 1
            Console.WriteLine(transformManyBlock.Receive())
         Next i

'          Output:
'            H
'            e
'            l
'            l
'            o
'            W
'            o
'            r
'            l
'            d
'          
         ' </snippet6>
      End Sub

      Private Shared Sub ShowBatchBlock()
         ' <snippet7>
         ' Create a BatchBlock<int> object that holds ten
         ' elements per batch.
         Dim batchBlock = New BatchBlock(Of Integer)(10)

         ' Post several values to the block.
         For i As Integer = 0 To 12
            batchBlock.Post(i)
         Next i
         ' Set the block to the completed state. This causes
         ' the block to propagate out any any remaining
         ' values as a final batch.
         batchBlock.Complete()

         ' Print the sum of both batches.

         Console.WriteLine("The sum of the elements in batch 1 is {0}.", batchBlock.Receive().Sum())

         Console.WriteLine("The sum of the elements in batch 2 is {0}.", batchBlock.Receive().Sum())

'          Output:
'            The sum of the elements in batch 1 is 45.
'            The sum of the elements in batch 2 is 33.
'          
         ' </snippet7>
      End Sub

      Private Shared Sub ShowJoinBlock()
         ' <snippet8>
         ' Create a JoinBlock<int, int, char> object that requires
         ' two numbers and an operator.
         Dim joinBlock = New JoinBlock(Of Integer, Integer, Char)()

         ' Post two values to each target of the join.

         joinBlock.Target1.Post(3)
         joinBlock.Target1.Post(6)

         joinBlock.Target2.Post(5)
         joinBlock.Target2.Post(4)

         joinBlock.Target3.Post("+"c)
         joinBlock.Target3.Post("-"c)

         ' Receive each group of values and apply the operator part
         ' to the number parts.

         For i As Integer = 0 To 1
            Dim data = joinBlock.Receive()
            Select Case data.Item3
               Case "+"c
                  Console.WriteLine("{0} + {1} = {2}", data.Item1, data.Item2, data.Item1 + data.Item2)
               Case "-"c
                  Console.WriteLine("{0} - {1} = {2}", data.Item1, data.Item2, data.Item1 - data.Item2)
               Case Else
                  Console.WriteLine("Unknown operator '{0}'.", data.Item3)
            End Select
         Next i

'          Output:
'            3 + 5 = 8
'            6 - 4 = 2
'          
         ' </snippet8>
      End Sub

      Private Shared Sub ShowBatchedJoinBlock()
         ' <snippet9>
         ' For demonstration, create a Func<int, int> that 
         ' returns its argument, or throws ArgumentOutOfRangeException
         ' if the argument is less than zero.
         Dim DoWork As Func(Of Integer, Integer) = Function(n)
            If n < 0 Then
               Throw New ArgumentOutOfRangeException()
            End If
            Return n
         End Function

         ' Create a BatchedJoinBlock<int, Exception> object that holds 
         ' seven elements per batch.
         Dim batchedJoinBlock = New BatchedJoinBlock(Of Integer, Exception)(7)

         ' Post several items to the block.
         For Each i As Integer In New Integer() { 5, 6, -7, -22, 13, 55, 0 }
            Try
               ' Post the result of the worker to the 
               ' first target of the block.
               batchedJoinBlock.Target1.Post(DoWork(i))
            Catch e As ArgumentOutOfRangeException
               ' If an error occurred, post the Exception to the 
               ' second target of the block.
               batchedJoinBlock.Target2.Post(e)
            End Try
         Next i

         ' Read the results from the block.
         Dim results = batchedJoinBlock.Receive()

         ' Print the results to the console.

         ' Print the results.
         For Each n As Integer In results.Item1
            Console.WriteLine(n)
         Next n
         ' Print failures.
         For Each e As Exception In results.Item2
            Console.WriteLine(e.Message)
         Next e

'          Output:
'            5
'            6
'            13
'            55
'            0
'            Specified argument was out of the range of valid values.
'            Specified argument was out of the range of valid values.
'          
         ' </snippet9>
      End Sub

      Private Shared Sub ShowCompletion()
         ' <snippet10>
         ' Create an ActionBlock<int> object that prints its input
         ' and throws ArgumentOutOfRangeException if the input
         ' is less than zero.
         Dim throwIfNegative = New ActionBlock(Of Integer)(Sub(n)
             Console.WriteLine("n = {0}", n)
             If n < 0 Then
                 Throw New ArgumentOutOfRangeException()
             End If
         End Sub)

         ' Post values to the block.
         throwIfNegative.Post(0)
         throwIfNegative.Post(-1)
         throwIfNegative.Post(1)
         throwIfNegative.Post(-2)
         throwIfNegative.Complete()

         ' Wait for completion in a try/catch block.
         Try
            throwIfNegative.Completion.Wait()
         Catch ae As AggregateException
            ' If an unhandled exception occurs during dataflow processing, all
            ' exceptions are propagated through an AggregateException object.
            ae.Handle(Function(e)
                Console.WriteLine("Encountered {0}: {1}", e.GetType().Name, e.Message)
                Return True
            End Function)
         End Try

'          Output:
'         n = 0
'         n = -1
'         Encountered ArgumentOutOfRangeException: Specified argument was out of the range
'          of valid values.
'         
         ' </snippet10>      
      End Sub

      Private Shared Sub ShowCompletionStatus()
         ' <snippet11>
         ' Create an ActionBlock<int> object that prints its input
         ' and throws ArgumentOutOfRangeException if the input
         ' is less than zero.
         Dim throwIfNegative = New ActionBlock(Of Integer)(Sub(n)
             Console.WriteLine("n = {0}", n)
             If n < 0 Then
                 Throw New ArgumentOutOfRangeException()
             End If
         End Sub)

         ' Create a continuation task that prints the overall 
         ' task status to the console when the block finishes.
         throwIfNegative.Completion.ContinueWith(Sub(task) Console.WriteLine("The status of the completion task is '{0}'.", task.Status))

         ' Post values to the block.
         throwIfNegative.Post(0)
         throwIfNegative.Post(-1)
         throwIfNegative.Post(1)
         throwIfNegative.Post(-2)
         throwIfNegative.Complete()

         ' Wait for completion in a try/catch block.
         Try
            throwIfNegative.Completion.Wait()
         Catch ae As AggregateException
            ' If an unhandled exception occurs during dataflow processing, all
            ' exceptions are propagated through an AggregateException object.
            ae.Handle(Function(e)
                Console.WriteLine("Encountered {0}: {1}", e.GetType().Name, e.Message)
                Return True
            End Function)
         End Try

'          Output:
'         n = 0
'         n = -1
'         The status of the completion task is 'Faulted'.
'         Encountered ArgumentOutOfRangeException: Specified argument was out of the range
'          of valid values.
'         
         ' </snippet11>      
      End Sub

      Shared Sub Main(ByVal args() As String)
         'ShowBufferBlock();
         'ShowBroadcastBlock();
         'ShowWriteOnceBlock();
         'ShowActionBlock();
         'ShowTransformBlock();
         'ShowTransformManyBlock();
         'ShowBatchBlock();
         'ShowJoinBlock();
         'ShowBatchedJoinBlock();

         'ShowCompletion();
         'ShowCompletionStatus();
      End Sub
   End Class
End Namespace
