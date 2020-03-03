'<snippet01>
Option Strict On
Option Explicit On

Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks

Module SimpleBlocking

    Class Program
        Shared Sub Main()
            ' Increase or decrease this value as desired.
            Dim itemsToAdd As Integer = 500

            ' Preserve all the display output for Adds and Takes
            Console.SetBufferSize(80, (itemsToAdd * 2) + 3)

            ' A bounded collection. Increase, decrease, or remove the 
            ' maximum capacity argument to see how it impacts behavior.
            Dim numbers = New BlockingCollection(Of Integer)(50)

            ' A simple blocking consumer with no cancellation.
            Task.Factory.StartNew(Sub()
                                      Dim i As Integer = -1
                                      While numbers.IsCompleted = False
                                          Try
                                              i = numbers.Take()
                                          Catch ioe As InvalidOperationException
                                              Console.WriteLine("Adding was completed!")
                                              Exit While
                                          End Try
                                          Console.WriteLine("Take:{0} ", i)
                                          ' Simulate a slow consumer. This will cause
                                          ' collection to fill up fast and thus Adds wil block.
                                          Thread.SpinWait(100000)
                                      End While
                                      Console.WriteLine(vbCrLf & "No more items to take. Press the Enter key to exit.")
                                  End Sub)

            ' A simple blocking producer with no cancellation.
            Task.Factory.StartNew(Sub()
                                      For i As Integer = 0 To itemsToAdd
                                          numbers.Add(i)
                                          Console.WriteLine("Add:{0} Count={1}", i, numbers.Count)
                                      Next

                                      'See documentation for this method.
                                      numbers.CompleteAdding()
                                  End Sub)

            'Keep the console window open in debug mode.
            Console.ReadLine()
        End Sub
    End Class

End Module
'</snippet01>
