' <snippet100>
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Threading.Tasks.Dataflow

' Demonstrates how to create a custom dataflow block type.
Friend Class Program
    ' <snippet1>
    ' Creates a IPropagatorBlock<T, T[]> object propagates data in a 
    ' sliding window fashion.
    Public Shared Function CreateSlidingWindow(Of T)(ByVal windowSize As Integer) As IPropagatorBlock(Of T, T())
        ' Create a queue to hold messages.
        Dim queue = New Queue(Of T)()

        ' The source part of the propagator holds arrays of size windowSize
        ' and propagates data out to any connected targets.
        Dim source = New BufferBlock(Of T())()

        ' The target part receives data and adds them to the queue.
        Dim target = New ActionBlock(Of T)(Sub(item)
            ' Add the item to the queue.
            ' Remove the oldest item when the queue size exceeds the window size.
            ' Post the data in the queue to the source block when the queue size
            ' equals the window size.
            queue.Enqueue(item)
            If queue.Count > windowSize Then
                queue.Dequeue()
            End If
            If queue.Count = windowSize Then
                source.Post(queue.ToArray())
            End If
        End Sub)

        ' When the target is set to the completed state, propagate out any
        ' remaining data and set the source to the completed state.
        target.Completion.ContinueWith(Sub()
            If queue.Count > 0 AndAlso queue.Count < windowSize Then
                source.Post(queue.ToArray())
            End If
            source.Complete()
        End Sub)

        ' Return a IPropagatorBlock<T, T[]> object that encapsulates the 
        ' target and source blocks.
        Return DataflowBlock.Encapsulate(target, source)
    End Function
    ' </snippet1>

    ' <snippet2>
    ' Propagates data in a sliding window fashion.
    Public Class SlidingWindowBlock(Of T)
        Implements IPropagatorBlock(Of T, T()), IReceivableSourceBlock(Of T())
        ' The size of the window.
        Private ReadOnly m_windowSize As Integer
        ' The target part of the block.
        Private ReadOnly m_target As ITargetBlock(Of T)
        ' The source part of the block.
        Private ReadOnly m_source As IReceivableSourceBlock(Of T())

        ' Constructs a SlidingWindowBlock object.
        Public Sub New(ByVal windowSize As Integer)
            ' Create a queue to hold messages.
            Dim queue = New Queue(Of T)()

            ' The source part of the propagator holds arrays of size windowSize
            ' and propagates data out to any connected targets.
            Dim source = New BufferBlock(Of T())()

            ' The target part receives data and adds them to the queue.
            Dim target = New ActionBlock(Of T)(Sub(item)
                ' Add the item to the queue.
                ' Remove the oldest item when the queue size exceeds the window size.
                ' Post the data in the queue to the source block when the queue size
                ' equals the window size.
                queue.Enqueue(item)
                If queue.Count > windowSize Then
                    queue.Dequeue()
                End If
                If queue.Count = windowSize Then
                    source.Post(queue.ToArray())
                End If
            End Sub)

            ' When the target is set to the completed state, propagate out any
            ' remaining data and set the source to the completed state.
            target.Completion.ContinueWith(Sub()
                If queue.Count > 0 AndAlso queue.Count < windowSize Then
                    source.Post(queue.ToArray())
                End If
                source.Complete()
            End Sub)

            m_windowSize = windowSize
            m_target = target
            m_source = source
        End Sub

        ' Retrieves the size of the window.
        Public ReadOnly Property WindowSize() As Integer
            Get
                Return m_windowSize
            End Get
        End Property

        '#Region "IReceivableSourceBlock<TOutput> members"

        ' Attempts to synchronously receive an item from the source.
        Public Function TryReceive(ByVal filter As Predicate(Of T()), <System.Runtime.InteropServices.Out()> ByRef item() As T) As Boolean Implements IReceivableSourceBlock(Of T()).TryReceive
            Return m_source.TryReceive(filter, item)
        End Function

        ' Attempts to remove all available elements from the source into a new 
        ' array that is returned.
        Public Function TryReceiveAll(<System.Runtime.InteropServices.Out()> ByRef items As IList(Of T())) As Boolean Implements IReceivableSourceBlock(Of T()).TryReceiveAll
            Return m_source.TryReceiveAll(items)
        End Function

        '#End Region

#Region "ISourceBlock<TOutput> members"

        ' Links this dataflow block to the provided target.
        Public Function LinkTo(ByVal target As ITargetBlock(Of T()), ByVal linkOptions As DataflowLinkOptions) As IDisposable Implements ISourceBlock(Of T()).LinkTo
            Return m_source.LinkTo(target, linkOptions)
        End Function

        ' Called by a target to reserve a message previously offered by a source 
        ' but not yet consumed by this target.
        Private Function ReserveMessage(ByVal messageHeader As DataflowMessageHeader, ByVal target As ITargetBlock(Of T())) As Boolean Implements ISourceBlock(Of T()).ReserveMessage
            Return m_source.ReserveMessage(messageHeader, target)
        End Function

        ' Called by a target to consume a previously offered message from a source.
        Private Function ConsumeMessage(ByVal messageHeader As DataflowMessageHeader, ByVal target As ITargetBlock(Of T()), ByRef messageConsumed As Boolean) As T() Implements ISourceBlock(Of T()).ConsumeMessage
            Return m_source.ConsumeMessage(messageHeader, target, messageConsumed)
        End Function

        ' Called by a target to release a previously reserved message from a source.
        Private Sub ReleaseReservation(ByVal messageHeader As DataflowMessageHeader, ByVal target As ITargetBlock(Of T())) Implements ISourceBlock(Of T()).ReleaseReservation
            m_source.ReleaseReservation(messageHeader, target)
        End Sub

#End Region

#Region "ITargetBlock<TInput> members"

        ' Asynchronously passes a message to the target block, giving the target the 
        ' opportunity to consume the message.
        Private Function OfferMessage(ByVal messageHeader As DataflowMessageHeader, ByVal messageValue As T, ByVal source As ISourceBlock(Of T), ByVal consumeToAccept As Boolean) As DataflowMessageStatus Implements ITargetBlock(Of T).OfferMessage
            Return m_target.OfferMessage(messageHeader, messageValue, source, consumeToAccept)
        End Function

#End Region

#Region "IDataflowBlock members"

        ' Gets a Task that represents the completion of this dataflow block.
        Public ReadOnly Property Completion() As Task Implements IDataflowBlock.Completion
            Get
                Return m_source.Completion
            End Get
        End Property

        ' Signals to this target block that it should not accept any more messages, 
        ' nor consume postponed messages. 
        Public Sub Complete() Implements IDataflowBlock.Complete
            m_target.Complete()
        End Sub

        Public Sub Fault(ByVal [error] As Exception) Implements IDataflowBlock.Fault
            m_target.Fault([error])
        End Sub

#End Region
    End Class
    ' </snippet2>

    ' Demonstrates usage of the sliding window block by sending the provided
    ' values to the provided propagator block and printing the output of 
    ' that block to the console.
    Private Shared Sub DemonstrateSlidingWindow(Of T)(ByVal slidingWindow As IPropagatorBlock(Of T, T()), ByVal values As IEnumerable(Of T))
        ' Create an action block that prints arrays of data to the console.
        Dim windowComma As String = String.Empty
        Dim printWindow = New ActionBlock(Of T())(Sub(window)
            Console.Write(windowComma)
            Console.Write("{")
            Dim comma As String = String.Empty
            For Each item As T In window
                Console.Write(comma)
                Console.Write(item)
                comma = ","
            Next item
            Console.Write("}")
            windowComma = ", "
        End Sub)

        ' Link the printer block to the sliding window block.
        slidingWindow.LinkTo(printWindow)

        ' Set the printer block to the completed state when the sliding window
        ' block completes.
        slidingWindow.Completion.ContinueWith(Sub() printWindow.Complete())

        ' Print an additional newline to the console when the printer block completes.
        Dim completion = printWindow.Completion.ContinueWith(Sub() Console.WriteLine())

        ' Post the provided values to the sliding window block and then wait
        ' for the sliding window block to complete.
        For Each value As T In values
            slidingWindow.Post(value)
        Next value
        slidingWindow.Complete()

        ' Wait for the printer to complete and perform its final action.
        completion.Wait()
    End Sub

    Shared Sub Main(ByVal args() As String)

        Console.Write("Using the DataflowBlockExtensions.Encapsulate method ")
        Console.WriteLine("(T=int, windowSize=3):")
        DemonstrateSlidingWindow(CreateSlidingWindow(Of Integer)(3), Enumerable.Range(0, 10))

        Console.WriteLine()

        Dim slidingWindow = New SlidingWindowBlock(Of Char)(4)

        Console.Write("Using SlidingWindowBlock<T> ")
        Console.WriteLine("(T=char, windowSize={0}):", slidingWindow.WindowSize)
        DemonstrateSlidingWindow(slidingWindow, _
            From n In Enumerable.Range(65, 10) _
            Select ChrW(n))
    End Sub
End Class

' Output:
'Using the DataflowBlockExtensions.Encapsulate method (T=int, windowSize=3):
'{0,1,2}, {1,2,3}, {2,3,4}, {3,4,5}, {4,5,6}, {5,6,7}, {6,7,8}, {7,8,9}
'
'Using SlidingWindowBlock<T> (T=char, windowSize=4):
'{A,B,C,D}, {B,C,D,E}, {C,D,E,F}, {D,E,F,G}, {E,F,G,H}, {F,G,H,I}, {G,H,I,J}
' 
' </snippet100>