' GOES IN TPL_Exceptions!!!
'<snippet08> 
' How to: Handle Exceptions in Parallel Loops

Imports System.Collections.Concurrent
Imports System.Threading.Tasks

Module ExceptionsInLoops

    Sub Main()

        ' Create some random data to process in parallel.
        ' There is a good probability this data will cause some exceptions to be thrown.
        Dim data(1000) As Byte
        Dim r As New Random()
        r.NextBytes(data)

        Try
            ProcessDataInParallel(data)
        Catch ae As AggregateException
            ' This is where you can choose which exceptions to handle.
            For Each ex As Exception In ae.InnerExceptions
                If (TypeOf (ex) Is ArgumentException) Then
                    Console.WriteLine(ex.Message)
                Else
                    Throw ex
                End If
            Next
        End Try
        Console.WriteLine("Press any key to exit.")
        Console.ReadKey()
    End Sub
    Sub ProcessDataInParallel(ByVal data As Byte())

        ' Use ConcurrentQueue to enable safe enqueueing from multiple threads.
        Dim exceptions As New ConcurrentQueue(Of Exception)

        ' Execute the complete loop and capture all exceptions.
        Parallel.ForEach(Of Byte)(data, Sub(d)
                                            Try
                                                ' Cause a few exceptions, but not too many.
                                                If d < &H3 Then
                                                    Throw New ArgumentException(String.Format("value is {0:x}. Element must be greater than &H3", d))
                                                Else
                                                    Console.Write(d & " ")
                                                End If
                                            Catch ex As Exception
                                                ' Store the exception and continue with the loop. 
                                                exceptions.Enqueue(ex)
                                            End Try
                                        End Sub)

        ' Throw the exceptions here after the loop completes.
        If exceptions.Count > 0 Then
            Throw New AggregateException(exceptions)
        End If
    End Sub
End Module
'</snippet08>
