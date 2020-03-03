Imports System.Collections
Imports System.Collections.Generic

'<snippet1>
Imports System.Collections.Concurrent

Module IProdCon
    ' Sample implementation of IProducerConsumerCollection(T) -- in this case,
    ' a thread-safe stack.
    Public Class SafeStack(Of T)
        Implements IProducerConsumerCollection(Of T)

        ' Used for enforcing thread-safety
        Private m_lockObject As New Object()

        ' We'll use a regular old Stack for our core operations
        Private m_sequentialStack As Stack(Of T) = Nothing

        '
        ' Constructors
        '
        Public Sub New()
            m_sequentialStack = New Stack(Of T)()
        End Sub

        Public Sub New(ByVal collection As IEnumerable(Of T))
            m_sequentialStack = New Stack(Of T)(collection)
        End Sub

        '
        ' Safe Push/Pop support
        '
        Public Sub Push(ByVal item As T)
            SyncLock m_lockObject
                m_sequentialStack.Push(item)
            End SyncLock
        End Sub

        Public Function TryPop(ByRef item As T) As Boolean
            Dim rval As Boolean = True
            SyncLock m_lockObject
                If m_sequentialStack.Count = 0 Then
                    item = Nothing
                    rval = False
                Else
                    item = m_sequentialStack.Pop()
                End If
            End SyncLock
            Return rval
        End Function

        '
        ' IProducerConsumerCollection(T) support
        '
        Public Function TryTake(ByRef item As T) As Boolean Implements IProducerConsumerCollection(Of T).TryTake
            Return TryPop(item)
        End Function

        Public Function TryAdd(ByVal item As T) As Boolean Implements IProducerConsumerCollection(Of T).TryAdd
            Push(item)
            ' Push doesn't fail
            Return True
        End Function

        Public Function ToArray() As T() Implements IProducerConsumerCollection(Of T).ToArray
            Dim rval As T() = Nothing
            SyncLock m_lockObject
                rval = m_sequentialStack.ToArray()
            End SyncLock
            Return rval
        End Function

        Public Sub CopyTo(ByVal array As T(), ByVal index As Integer) Implements IProducerConsumerCollection(Of T).CopyTo
            SyncLock m_lockObject
                m_sequentialStack.CopyTo(array, index)
            End SyncLock
        End Sub



        '
        ' Support for IEnumerable(T)
        '
        Public Function GetEnumerator() As IEnumerator(Of T) Implements IEnumerable(Of T).GetEnumerator
            ' The performance here will be unfortunate for large stacks,
            ' but thread-safety is effectively implemented.
            Dim stackCopy As Stack(Of T) = Nothing
            SyncLock m_lockObject
                stackCopy = New Stack(Of T)(m_sequentialStack)
            End SyncLock
            Return stackCopy.GetEnumerator()
        End Function


        '
        ' Support for IEnumerable
        '
        Private Function GetEnumerator2() As IEnumerator Implements IEnumerable.GetEnumerator
            Return DirectCast(Me, IEnumerable(Of T)).GetEnumerator()
        End Function

        ' 
        ' Support for ICollection
        '
        Public ReadOnly Property IsSynchronized() As Boolean Implements ICollection.IsSynchronized
            Get
                Return True
            End Get
        End Property

        Public ReadOnly Property SyncRoot() As Object Implements ICollection.SyncRoot
            Get
                Return m_lockObject
            End Get
        End Property

        Public ReadOnly Property Count() As Integer Implements ICollection.Count
            Get
                Return m_sequentialStack.Count
            End Get
        End Property

        Public Sub CopyTo(ByVal array As Array, ByVal index As Integer) Implements ICollection.CopyTo
            SyncLock m_lockObject
                DirectCast(m_sequentialStack, ICollection).CopyTo(array, index)
            End SyncLock
        End Sub
    End Class

    ' Test our implementation of IProducerConsumerCollection(T)
    ' Demonstrates:
    ' IPCC(T).TryAdd()
    ' IPCC(T).TryTake()
    ' IPCC(T).CopyTo()
    Private Sub TestSafeStack()
        Dim stack As New SafeStack(Of Integer)()
        Dim ipcc As IProducerConsumerCollection(Of Integer) = DirectCast(stack, IProducerConsumerCollection(Of Integer))

        ' Test Push()/TryAdd()
        stack.Push(10)
        Console.WriteLine("Pushed 10")
        ipcc.TryAdd(20)
        Console.WriteLine("IPCC.TryAdded 20")
        stack.Push(15)
        Console.WriteLine("Pushed 15")

        Dim testArray As Integer() = New Integer(2) {}

        ' Try CopyTo() within boundaries
        Try
            ipcc.CopyTo(testArray, 0)
            Console.WriteLine("CopyTo() within boundaries worked, as expected")
        Catch e As Exception
            Console.WriteLine("CopyTo() within boundaries unexpectedly threw an exception: {0}", e.Message)
        End Try

        ' Try CopyTo() that overflows
        Try
            ipcc.CopyTo(testArray, 1)
            Console.WriteLine("CopyTo() with index overflow worked, and it SHOULD NOT HAVE")
        Catch e As Exception
            Console.WriteLine("CopyTo() with index overflow threw an exception, as expected: {0}", e.Message)
        End Try

        ' Test enumeration
        Console.Write("Enumeration (should be three items): ")
        For Each item As Integer In stack
            Console.Write("{0} ", item)
        Next
        Console.WriteLine("")

        ' Test TryPop()
        Dim popped As Integer = 0
        If stack.TryPop(popped) Then
            Console.WriteLine("Successfully popped {0}", popped)
        Else
            Console.WriteLine("FAILED to pop!!")
        End If

        ' Test Count
        Console.WriteLine("stack count is {0}, should be 2", stack.Count)

        ' Test TryTake()
        If ipcc.TryTake(popped) Then
            Console.WriteLine("Successfully IPCC-TryTaked {0}", popped)
        Else
            Console.WriteLine("FAILED to IPCC.TryTake!!")
        End If
    End Sub

    Sub Main()
        TestSafeStack()

        ' Keep the console window open in debug mode
        Console.WriteLine("Press any key to exit.")
        Console.ReadKey()

    End Sub

End Module
'</snippet1>
