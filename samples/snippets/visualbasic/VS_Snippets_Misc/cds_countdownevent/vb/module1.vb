Option Strict On
Option Explicit On
Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading
Imports System.Threading.Tasks

Module Module1

    Class Data
        Public Num As Integer
        Private _p1 As Integer
        Sub New(ByVal i As Integer)
            Num = i
        End Sub

        Public Sub Data()

        End Sub
    End Class
    Class Program

        Shared Sub Main()

            SnippetOne()
            Console.WriteLine("Press enter to exit.")
            Console.ReadLine()
        End Sub

        Shared Sub ProcessData(ByVal obj As Object)
            Dim d As Data = CType(obj, Data)
            Thread.SpinWait(5000000)
            Console.WriteLine("Processed {0}", d.Num)
        End Sub

        Shared Function GetData() As IEnumerable(Of Data)
            Dim nums = New List(Of Data)
            For i As Integer = 1 To 5
                nums.Add(New Data(i))
            Next
            Return nums
        End Function

        Shared Sub SnippetOne()
            '<snippet01>
            Dim source As IEnumerable(Of Data) = GetData()
            Dim e = New CountdownEvent(1)

            ' Fork work:
            For Each element As Data In source
                ' Dynamically increment signal count.
                e.AddCount()

                ThreadPool.QueueUserWorkItem(Sub(state)
                                                 Try
                                                     ProcessData(state)
                                                 Finally
                                                     e.Signal()
                                                 End Try
                                             End Sub,
                                              element)
            Next
            ' Decrement the signal count by the one we added
            ' in the constructor.
            e.Signal()

            ' The first element could also be run on this thread.
            ' ProcessData(New Data(0))

            ' Join with work:
            e.Wait()

            '</snippet01>
        End Sub

    End Class



End Module
