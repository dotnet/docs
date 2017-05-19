Option Strict On
Option Explicit On

Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks


Module IntroSnippetsBC

    ' Dummy methods and classes
    Class Data
    End Class
    Sub Process(ByVal d As Data)
    End Sub
    Function GetData() As Data
        Return New Data()
    End Function

    Sub Main()
        Dim moreItemsToAdd As Boolean = False

        '<snippet04>
        ' A bounded collection. It can hold no more 
        ' than 100 items at once.
        Dim dataItems = New BlockingCollection(Of Data)(100)

        ' A simple blocking consumer with no cancellation.
        Task.Factory.StartNew(Sub()
                                  While dataItems.IsCompleted = False
                                      Dim dataItem As Data = Nothing
                                      Try
                                          dataItem = dataItems.Take()
                                      Catch e As InvalidOperationException
                                          ' IOE means that Take() was called on a completed collection.
                                          ' In this example, we can simply catch the exception since the 
                                          ' loop will break on the next iteration.
                                      End Try
                                      If (dataItem IsNot Nothing) Then
                                          Process(dataItem)
                                      End If
                                  End While
                                  Console.WriteLine(vbCrLf & "No more items to take.")
                              End Sub)

        ' A simple blocking producer with no cancellation.
        Task.Factory.StartNew(Sub()
                                  While moreItemsToAdd = True
                                      Dim item As Data = GetData()

                                      ' Blocks if numbers.Count = dataItems.BoundedCapacity
                                      dataItems.Add(item)
                                  End While

                                  ' Let consumer know we are done.
                                  dataItems.CompleteAdding()
                              End Sub)
        '</snippet04>

    End Sub

    Sub NonBlockingProducer(ByVal bc As BlockingCollection(Of Integer), ByVal ct As CancellationToken)
        Dim itemToAdd As Integer = 0
        Dim moreItems As Boolean = True
        Dim success As Boolean = False

        '<snippet05>
        Do While moreItems = True
            ' Cancellation causes OCE. We know how to handle it.
            Try
                success = bc.TryAdd(itemToAdd, 2, ct)
            Catch ex As OperationCanceledException
                bc.CompleteAdding()
                Exit Do
            End Try
        Loop
        '</snippet05>

    End Sub


End Module
