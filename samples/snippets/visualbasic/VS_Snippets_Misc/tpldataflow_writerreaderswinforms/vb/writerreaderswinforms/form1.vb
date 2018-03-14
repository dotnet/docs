' <snippet100>
' <snippet1>
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Threading.Tasks.Dataflow
' </snippet1>

Namespace WriterReadersWinForms
    Partial Public Class Form1
        Inherits Form
        ' <snippet2>
        ' Broadcasts values to an ActionBlock<int> object that is associated
        ' with each check box.
        Private broadcaster As New BroadcastBlock(Of Integer)(Nothing)
        ' </snippet2>

        Public Sub New()
            InitializeComponent()

            ' <snippet3>
            ' Create an ActionBlock<CheckBox> object that toggles the state
            ' of CheckBox objects.
            ' Specifying the current synchronization context enables the 
            ' action to run on the user-interface thread.
         Dim toggleCheckBox = New ActionBlock(Of CheckBox)(Sub(checkBox) checkBox.Checked = Not checkBox.Checked, New ExecutionDataflowBlockOptions With {.TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext()})
            ' </snippet3>

            ' <snippet4>
            ' Create a ConcurrentExclusiveSchedulerPair object.
            ' Readers will run on the concurrent part of the scheduler pair.
            ' The writer will run on the exclusive part of the scheduler pair.
            Dim taskSchedulerPair = New ConcurrentExclusiveSchedulerPair()

            ' Create an ActionBlock<int> object for each reader CheckBox object.
            ' Each ActionBlock<int> object represents an action that can read 
            ' from a resource in parallel to other readers.
            ' Specifying the concurrent part of the scheduler pair enables the 
            ' reader to run in parallel to other actions that are managed by 
            ' that scheduler.
            Dim readerActions = From checkBox In New CheckBox() {checkBox1, checkBox2, checkBox3} _
                Select New ActionBlock(Of Integer)(Sub(milliseconds)
                    ' Toggle the check box to the checked state.
                    ' Perform the read action. For demonstration, suspend the current
                    ' thread to simulate a lengthy read operation.
                    ' Toggle the check box to the unchecked state.
                    toggleCheckBox.Post(checkBox)
                    Thread.Sleep(milliseconds)
                    toggleCheckBox.Post(checkBox)
                End Sub, New ExecutionDataflowBlockOptions With {.TaskScheduler = taskSchedulerPair.ConcurrentScheduler})

            ' Create an ActionBlock<int> object for the writer CheckBox object.
            ' This ActionBlock<int> object represents an action that writes to 
            ' a resource, but cannot run in parallel to readers.
            ' Specifying the exclusive part of the scheduler pair enables the 
            ' writer to run in exclusively with respect to other actions that are 
            ' managed by the scheduler pair.
            Dim writerAction = New ActionBlock(Of Integer)(Sub(milliseconds)
                ' Toggle the check box to the checked state.
                ' Perform the write action. For demonstration, suspend the current
                ' thread to simulate a lengthy write operation.
                ' Toggle the check box to the unchecked state.
                toggleCheckBox.Post(checkBox4)
                Thread.Sleep(milliseconds)
                toggleCheckBox.Post(checkBox4)
            End Sub, New ExecutionDataflowBlockOptions With {.TaskScheduler = taskSchedulerPair.ExclusiveScheduler})

            ' Link the broadcaster to each reader and writer block.
            ' The BroadcastBlock<T> class propagates values that it 
            ' receives to all connected targets.
            For Each readerAction In readerActions
                broadcaster.LinkTo(readerAction)
            Next readerAction
            broadcaster.LinkTo(writerAction)
            ' </snippet4>

            ' <snippet5>
            ' Start the timer.
            timer1.Start()
            ' </snippet5>
        End Sub

        ' <snippet6>
        ' Event handler for the timer.
        Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
            ' Post a value to the broadcaster. The broadcaster
            ' sends this message to each target. 
            broadcaster.Post(1000)
        End Sub
        ' </snippet6>
    End Class
End Namespace
' </snippet100>
