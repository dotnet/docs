'<snippet04>
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Collections.Concurrent
Module Module1
    Public Class OrderableListPartitioner(Of TSource)
        Inherits OrderablePartitioner(Of TSource)


        Private ReadOnly m_input As IList(Of TSource)

        Public Sub New(ByVal input As IList(Of TSource))
            MyBase.New(True, False, True)
            m_input = input
        End Sub

        ' Must override to return true.
        Public Overrides ReadOnly Property SupportsDynamicPartitions As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides Function GetOrderablePartitions(ByVal partitionCount As Integer) As IList(Of IEnumerator(Of KeyValuePair(Of Long, TSource)))
            Dim dynamicPartitions = GetOrderableDynamicPartitions()
            Dim partitions(partitionCount - 1) As IEnumerator(Of KeyValuePair(Of Long, TSource))

            For i = 0 To partitionCount - 1
                partitions(i) = dynamicPartitions.GetEnumerator()
            Next

            Return partitions
        End Function

        Public Overrides Function GetOrderableDynamicPartitions() As IEnumerable(Of KeyValuePair(Of Long, TSource))
            Return New ListDynamicPartitions(m_input)
        End Function

        Private Class ListDynamicPartitions
            Implements IEnumerable(Of KeyValuePair(Of Long, TSource))

            Private m_input As IList(Of TSource)

            Friend Sub New(ByVal input As IList(Of TSource))
                m_input = input
            End Sub

            Public Function GetEnumerator() As IEnumerator(Of KeyValuePair(Of Long, TSource)) Implements IEnumerable(Of KeyValuePair(Of Long, TSource)).GetEnumerator
                Return New ListDynamicPartitionsEnumerator(m_input)
            End Function

            Public Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator
                Return CType(Me, IEnumerable).GetEnumerator()
            End Function
        End Class

        Private Class ListDynamicPartitionsEnumerator
            Implements IEnumerator(Of KeyValuePair(Of Long, TSource))

            Private m_input As IList(Of TSource)
            Shared m_pos As Integer = 0
            Private m_current As KeyValuePair(Of Long, TSource)

            Public Sub New(ByVal input As IList(Of TSource))
                m_input = input
                m_pos = 0
                Me.disposedValue = False
            End Sub

            Public ReadOnly Property Current As KeyValuePair(Of Long, TSource) Implements IEnumerator(Of KeyValuePair(Of Long, TSource)).Current
                Get
                    Return m_current
                End Get
            End Property

            Public ReadOnly Property Current1 As Object Implements IEnumerator.Current
                Get
                    Return Me.Current
                End Get
            End Property

            Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
                Dim elemIndex = Interlocked.Increment(m_pos) - 1
                If elemIndex >= m_input.Count Then
                    Return False
                End If

                m_current = New KeyValuePair(Of Long, TSource)(elemIndex, m_input(elemIndex))
                Return True
            End Function

            Public Sub Reset() Implements IEnumerator.Reset
                m_pos = 0
            End Sub

            Private disposedValue As Boolean ' To detect redundant calls

            Protected Overridable Sub Dispose(ByVal disposing As Boolean)
                If Not Me.disposedValue Then
                    m_input = Nothing
                    m_current = Nothing
                End If
                Me.disposedValue = True
            End Sub

            Public Sub Dispose() Implements IDisposable.Dispose
                Dispose(True)
                GC.SuppressFinalize(Me)
            End Sub

        End Class

    End Class

    Class ConsumerClass

        Shared Sub Main()

            Console.BufferHeight = 20000
            Dim nums = Enumerable.Range(0, 2000).ToArray()

            Dim partitioner = New OrderableListPartitioner(Of Integer)(nums)

            ' Use with Parallel.ForEach
            Parallel.ForEach(partitioner, Sub(i) Console.Write("{0}:{1}  ", i, Thread.CurrentThread.ManagedThreadId))

            Console.WriteLine("PLINQ -----------------------------------")


            ' create a new partitioner, since Enumerators are not reusable.
            Dim partitioner2 = New OrderableListPartitioner(Of Integer)(nums)
            ' Use with PLINQ
            Dim query = From num In partitioner2.AsParallel()
                        Where num Mod 8 = 0
                        Select num

            For Each v In query
                Console.Write("{0}  ", v)
            Next

            Console.WriteLine("press any key")
            Console.ReadKey()
        End Sub
    End Class

End Module
'</snippet04>