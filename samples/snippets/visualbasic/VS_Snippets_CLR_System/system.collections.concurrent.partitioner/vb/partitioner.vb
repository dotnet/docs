Imports System.Collections
Imports System.Collections.Generic
'<snippet1>
Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks

Module PartitionerDemo
    ' Simple partitioner that will extract one item at a time, in a thread-safe fashion,
    ' from the underlying collection.
    Class SingleElementPartitioner(Of T)
        Inherits Partitioner(Of T)
        ' The collection being wrapped by this Partitioner
        Private m_referenceEnumerable As IEnumerable(Of T)

        ' Internal class that serves as a shared enumerable for the
        ' underlying collection.
        Private Class InternalEnumerable
            Implements IEnumerable(Of T)
            Implements IDisposable

            Private m_reader As IEnumerator(Of T)
            Private m_disposed As Boolean = False

            ' These two are used to implement Dispose() when static partitioning is being performed
            Private m_activeEnumerators As Integer
            Private m_downcountEnumerators As Boolean

            ' "downcountEnumerators" will be true for static partitioning, false for
            ' dynamic partitioning. 
            Public Sub New(ByVal reader As IEnumerator(Of T), ByVal downcountEnumerators As Boolean)
                m_reader = reader
                m_activeEnumerators = 0
                m_downcountEnumerators = downcountEnumerators
            End Sub

            Public Function GetEnumerator() As IEnumerator(Of T) Implements IEnumerable(Of T).GetEnumerator
                If m_disposed Then
                    Throw New ObjectDisposedException("InternalEnumerable: Can't call GetEnumerator() after disposing")
                End If

                ' For static partitioning, keep track of the number of active enumerators.
                If m_downcountEnumerators Then
                    Interlocked.Increment(m_activeEnumerators)
                End If

                Return New InternalEnumerator(m_reader, Me)
            End Function

            Private Function GetEnumerator2() As IEnumerator Implements IEnumerable.GetEnumerator
                Return DirectCast(Me, IEnumerable(Of T)).GetEnumerator()
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
            Implements IEnumerator(Of T)

            Private m_current As T
            Private m_source As IEnumerator(Of T)
            Private m_controllingEnumerable As InternalEnumerable
            Private m_disposed As Boolean = False

            Public Sub New(ByVal source As IEnumerator(Of T), ByVal controllingEnumerable As InternalEnumerable)
                m_source = source
                m_current = Nothing
                m_controllingEnumerable = controllingEnumerable
            End Sub

            Private ReadOnly Property Current2() As Object Implements IEnumerator.Current
                Get
                    Return m_current
                End Get
            End Property

            Private ReadOnly Property Current() As T Implements IEnumerator(Of T).Current
                Get
                    Return m_current
                End Get
            End Property

            Private Sub Reset() Implements IEnumerator.Reset
                Throw New NotSupportedException("Reset() not supported")
            End Sub

            ' This method is the crux of this class. Under lock, it calls
            ' MoveNext() on the underlying enumerator and grabs Current.
            Private Function MoveNext() As Boolean Implements IEnumerator.MoveNext
                Dim rval As Boolean = False
                SyncLock m_source
                    rval = m_source.MoveNext()
                    m_current = If(rval, m_source.Current, Nothing)
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

            ' Verify that the source IEnumerable is not null
            If enumerable Is Nothing Then
                Throw New ArgumentNullException("enumerable")
            End If

            m_referenceEnumerable = enumerable
        End Sub

        ' Produces a list of "numPartitions" IEnumerators that can each be
        ' used to traverse the underlying collection in a thread-safe manner.
        ' This will return a static number of enumerators, as opposed to
        ' GetDynamicPartitions(), the result of which can be used to produce
        ' any number of enumerators.
        Public Overloads Overrides Function GetPartitions(ByVal numPartitions As Integer) As IList(Of IEnumerator(Of T))
            If numPartitions < 1 Then
                Throw New ArgumentOutOfRangeException("NumPartitions")
            End If

            Dim list As New List(Of IEnumerator(Of T))(numPartitions)

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
        Public Overloads Overrides Function GetDynamicPartitions() As IEnumerable(Of T)
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
        ' Test our SingleElementPartitioner(T) class
        Shared Sub Main()
            ' Our sample collection
            Dim collection As String() = New String() {"red", "orange", "yellow", "green", "blue", "indigo", _
            "violet", "black", "white", "grey"}

            ' Instantiate a partitioner for our collection
            Dim myPart As New SingleElementPartitioner(Of String)(Collection)

            '
            ' Simple test with ForEach
            '
            Console.WriteLine("Testing with Parallel.ForEach")
            Parallel.ForEach(myPart,
                             Sub(item)
                                 Console.WriteLine(" item = {0}, thread id = {1}", item, Thread.CurrentThread.ManagedThreadId)
                             End Sub)

            '
            '
            ' Demonstrate the use of static partitioning, which really means
            ' "using a static number of partitioners". The partitioners themselves
            ' may still be "dynamic" in the sense that their outputs may not be
            ' deterministic.
            '
            '

            ' Perform static partitioning of collection
            Dim staticPartitions = myPart.GetPartitions(2)
            Dim index As Integer = 0

            Console.WriteLine("Static Partitioning, 2 partitions, 2 tasks:")

            ' Action will consume from static partitions
            Dim staticAction As Action =
                Sub()
                    Dim myIndex As Integer = Interlocked.Increment(index) - 1
                    ' compute your index
                    Dim myItems = staticPartitions(myIndex)
                    ' grab your static partition
                    Dim id As Integer = Thread.CurrentThread.ManagedThreadId
                    ' cache your thread id
                    ' Enumerate through your static partition
                    While myItems.MoveNext()
                        Thread.Sleep(50)
                        ' guarantees that multiple threads have a chance to run
                        Console.WriteLine(" item = {0}, thread id = {1}", myItems.Current, Thread.CurrentThread.ManagedThreadId)
                    End While

                    myItems.Dispose()
                End Sub

            ' Spawn off 2 actions to consume 2 static partitions
            Parallel.Invoke(staticAction, staticAction)

            '
            '
            ' Demonstrate the use of dynamic partitioning
            '
            '

            ' Grab an IEnumerable which can then be used to generate multiple
            ' shared IEnumerables.
            Dim dynamicPartitions = myPart.GetDynamicPartitions()

            Console.WriteLine("Dynamic Partitioning, 3 tasks:")

            ' Action will consume from dynamic partitions
            Dim dynamicAction As Action =
                Sub()
                    ' Grab an enumerator from the dynamic partitioner
                    Dim enumerator = dynamicPartitions.GetEnumerator()
                    Dim id As Integer = Thread.CurrentThread.ManagedThreadId
                    ' cache our thread id
                    ' Enumerate through your dynamic enumerator
                    While enumerator.MoveNext()
                        Thread.Sleep(50)
                        ' guarantees that multiple threads will have a chance to run
                        Console.WriteLine(" item = {0}, thread id = {1}", enumerator.Current, id)
                    End While

                    enumerator.Dispose()
                End Sub

            ' Spawn 3 concurrent actions to consume the dynamic partitions
            Parallel.Invoke(dynamicAction, dynamicAction, dynamicAction)

            ' Clean up
            If TypeOf dynamicPartitions Is IDisposable Then
                DirectCast(dynamicPartitions, IDisposable).Dispose()
            End If
        End Sub
    End Class

End Module
'</snippet1>