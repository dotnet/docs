Imports System.Collections
Imports System.Collections.Generic

'<snippet1>
Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks

Module OrderablePartitionerDemo


    ' Simple partitioner that will extract one (index,item) pair at a time, 
    ' in a thread-safe fashion, from the underlying collection.
    Class SingleElementOrderablePartitioner(Of T)
        Inherits OrderablePartitioner(Of T)
        ' The collection being wrapped by this Partitioner
        Private m_referenceEnumerable As IEnumerable(Of T)

        ' Class used to wrap m_index for the purpose of sharing access to it
        ' between an InternalEnumerable and multiple InternalEnumerators
        Private Class [Shared](Of U)
            Friend Value As U

            Public Sub New(ByVal item As U)
                Value = item
            End Sub
        End Class

        ' Internal class that serves as a shared enumerable for the
        ' underlying collection.
        Private Class InternalEnumerable
            Implements IEnumerable(Of KeyValuePair(Of Long, T))
            Implements IDisposable

            Private m_reader As IEnumerator(Of T)
            Private m_disposed As Boolean = False
            Private m_index As [Shared](Of Long) = Nothing

            ' These two are used to implement Dispose() when static partitioning is being performed
            Private m_activeEnumerators As Integer
            Private m_downcountEnumerators As Boolean

            ' "downcountEnumerators" will be true for static partitioning, false for
            ' dynamic partitioning. 
            Public Sub New(ByVal reader As IEnumerator(Of T), ByVal downcountEnumerators As Boolean)
                m_reader = reader
                m_index = New [Shared](Of Long)(0)
                m_activeEnumerators = 0
                m_downcountEnumerators = downcountEnumerators
            End Sub

            Public Function GetEnumerator() As IEnumerator(Of KeyValuePair(Of Long, T)) _
                Implements IEnumerable(Of System.Collections.Generic.KeyValuePair(Of Long, T)).GetEnumerator

                If m_disposed Then
                    Throw New ObjectDisposedException("InternalEnumerable: Can't call GetEnumerator() after disposing")
                End If

                ' For static partitioning, keep track of the number of active enumerators.
                If m_downcountEnumerators Then
                    Interlocked.Increment(m_activeEnumerators)
                End If

                Return New InternalEnumerator(m_reader, Me, m_index)
            End Function

            Private Function GetEnumerator2() As IEnumerator Implements IEnumerable.GetEnumerator
                Return DirectCast(Me, IEnumerable(Of KeyValuePair(Of Long, T))).GetEnumerator()
            End Function

            Public Sub Dispose() Implements IDisposable.Dispose
                If Not m_disposed Then
                    ' Only dispose the source enumerator if you are doing dynamic partitioning
                    If Not m_downcountEnumerators Then
                        m_reader.Dispose()
                    End If
                    m_disposed = True
                End If
            End Sub

            ' Called from Dispose() method of spawned InternalEnumerator. During
            ' static partitioning, the source enumerator will be automatically
            ' disposed once all requested InternalEnumerators have been disposed.
            Public Sub DisposeEnumerator()
                If m_downcountEnumerators Then
                    If Interlocked.Decrement(m_activeEnumerators) = 0 Then
                        m_reader.Dispose()
                    End If
                End If
            End Sub
        End Class

        ' Internal class that serves as a shared enumerator for 
        ' the underlying collection.
        Private Class InternalEnumerator
            Implements IEnumerator(Of KeyValuePair(Of Long, T))
            Private m_current As KeyValuePair(Of Long, T)
            Private m_source As IEnumerator(Of T)
            Private m_controllingEnumerable As InternalEnumerable
            Private m_index As [Shared](Of Long) = Nothing
            Private m_disposed As Boolean = False


            Public Sub New(ByVal source As IEnumerator(Of T), ByVal controllingEnumerable As InternalEnumerable, ByVal index As [Shared](Of Long))
                m_source = source
                m_current = Nothing
                m_controllingEnumerable = controllingEnumerable
                m_index = index
            End Sub

            Private ReadOnly Property Current2() As Object Implements IEnumerator.Current
                Get
                    Return m_current
                End Get
            End Property

            Private ReadOnly Property Current() As KeyValuePair(Of Long, T) Implements IEnumerator(Of KeyValuePair(Of Long, T)).Current
                Get
                    Return m_current
                End Get
            End Property

            Private Sub Reset() Implements IEnumerator.Reset
                Throw New NotSupportedException("Reset() not supported")
            End Sub

            ' This method is the crux of this class. Under lock, it calls
            ' MoveNext() on the underlying enumerator, grabs Current and index, 
            ' and increments the index.
            Private Function MoveNext() As Boolean Implements IEnumerator.MoveNext
                Dim rval As Boolean = False
                SyncLock m_source
                    rval = m_source.MoveNext()
                    If rval Then
                        m_current = New KeyValuePair(Of Long, T)(m_index.Value, m_source.Current)
                        m_index.Value = m_index.Value + 1
                    Else
                        m_current = Nothing
                    End If
                End SyncLock
                Return rval
            End Function

            Private Sub Dispose() Implements IDisposable.Dispose
                If Not m_disposed Then
                    ' Delegate to parent enumerable's DisposeEnumerator() method
                    m_controllingEnumerable.DisposeEnumerator()
                    m_disposed = True
                End If
            End Sub

        End Class

        ' Constructor just grabs the collection to wrap
        Public Sub New(ByVal enumerable As IEnumerable(Of T))
            MyBase.New(True, True, True)

            ' Verify that the source IEnumerable is not null
            If enumerable Is Nothing Then
                Throw New ArgumentNullException("enumerable")
            End If

            m_referenceEnumerable = enumerable
        End Sub

        ' Produces a list of "numPartitions" IEnumerators that can each be
        ' used to traverse the underlying collection in a thread-safe manner.
        ' This will return a static number of enumerators, as opposed to
        ' GetOrderableDynamicPartitions(), the result of which can be used to produce
        ' any number of enumerators.
        Public Overloads Overrides Function GetOrderablePartitions(ByVal numPartitions As Integer) As IList(Of IEnumerator(Of KeyValuePair(Of Long, T)))
            If numPartitions < 1 Then
                Throw New ArgumentOutOfRangeException("NumPartitions")
            End If

            Dim list As New List(Of IEnumerator(Of KeyValuePair(Of Long, T)))(numPartitions)

            ' Since we are doing static partitioning, create an InternalEnumerable with reference
            ' counting of spawned InternalEnumerators turned on. Once all of the spawned enumerators
            ' are disposed, dynamicPartitions will be disposed.
            Dim dynamicPartitions = New InternalEnumerable(m_referenceEnumerable.GetEnumerator(), True)
            For i As Integer = 0 To numPartitions - 1
                list.Add(dynamicPartitions.GetEnumerator())
            Next

            Return list
        End Function

        ' Returns an instance of our internal Enumerable class. GetEnumerator()
        ' can then be called on that (multiple times) to produce shared enumerators.
        Public Overloads Overrides Function GetOrderableDynamicPartitions() As IEnumerable(Of KeyValuePair(Of Long, T))
            ' Since we are doing dynamic partitioning, create an InternalEnumerable with reference
            ' counting of spawned InternalEnumerators turned off. This returned InternalEnumerable
            ' will need to be explicitly disposed.
            Return New InternalEnumerable(m_referenceEnumerable.GetEnumerator(), False)
        End Function

        ' Must be set to true if GetDynamicPartitions() is supported.
        Public Overloads Overrides ReadOnly Property SupportsDynamicPartitions() As Boolean
            Get
                Return True
            End Get
        End Property
    End Class

    Class Program
        Shared Sub Main()
            '
            ' First a fairly simple visual test
            '
            Dim someCollection = New String() {"four", "score", "and", "twenty", "years", "ago"}
            Dim someOrderablePartitioner = New SingleElementOrderablePartitioner(Of String)(someCollection)
            Parallel.ForEach(someOrderablePartitioner,
                             Sub(item, state, index)
                                 Console.WriteLine("ForEach: item = {0}, index = {1}, thread id = {2}", item, index, Thread.CurrentThread.ManagedThreadId)
                             End Sub)

            '
            ' Now a test of static partitioning, using 2 partitions and 2 tasks
            '
            Dim staticPartitioner = someOrderablePartitioner.GetOrderablePartitions(2)

            ' staticAction will consume the shared enumerable
            Dim partitionerListIndex As Integer = 0
            Dim staticAction As Action =
                Sub()
                    Dim myIndex As Integer = Interlocked.Increment(partitionerListIndex) - 1
                    Dim enumerator = staticPartitioner(myIndex)
                    While enumerator.MoveNext()
                        Console.WriteLine("Static partitioning: item = {0}, index = {1}, thread id = {2}", enumerator.Current.Value, enumerator.Current.Key, Thread.CurrentThread.ManagedThreadId)
                    End While
                    enumerator.Dispose()
                End Sub

            ' Now launch two of them
            Parallel.Invoke(staticAction, staticAction)

            '
            ' Now a more rigorous test of dynamic partitioning (used by Parallel.ForEach)
            '
            Console.WriteLine("OrderablePartitioner test: testing for index mismatches")
            Dim src As List(Of Integer) = Enumerable.Range(0, 100000).ToList()
            Dim myOP As New SingleElementOrderablePartitioner(Of Integer)(src)

            Dim counter As Integer = 0
            Dim mismatch As Boolean = False
            Parallel.ForEach(myOP,
                             Sub(item, state, index)
                                 If item <> index Then
                                     mismatch = True
                                 End If
                                 Interlocked.Increment(counter)
                             End Sub)

            If mismatch Then
                Console.WriteLine("OrderablePartitioner Test: index mismatch detected")
            End If



            Console.WriteLine("OrderablePartitioner test: counter = {0}, should be 100000", counter)
        End Sub
    End Class
End Module
'</snippet1>