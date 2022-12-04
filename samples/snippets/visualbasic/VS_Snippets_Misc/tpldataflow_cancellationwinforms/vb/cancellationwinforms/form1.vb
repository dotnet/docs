' <snippet100>
' <snippet1>
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Threading.Tasks.Dataflow

' </snippet1>

Namespace CancellationWinForms
    Partial Public Class Form1
        Inherits Form
        ' <snippet2>
        ' A placeholder type that performs work.
        Private Class WorkItem
            ' Performs work for the provided number of milliseconds.
            Public Sub DoWork(ByVal milliseconds As Integer)
                ' For demonstration, suspend the current thread.
                Thread.Sleep(milliseconds)
            End Sub
        End Class
        ' </snippet2>

        ' <snippet3>
        ' Enables the user interface to signal cancellation.
        Private cancellationSource As CancellationTokenSource

        ' The first node in the dataflow pipeline.
        Private startWork As TransformBlock(Of WorkItem, WorkItem)

        ' The second, and final, node in the dataflow pipeline.
        Private completeWork As ActionBlock(Of WorkItem)

        ' Increments the value of the provided progress bar.
        Private incrementProgress As ActionBlock(Of ToolStripProgressBar)

        ' Decrements the value of the provided progress bar.
        Private decrementProgress As ActionBlock(Of ToolStripProgressBar)

        ' Enables progress bar actions to run on the UI thread.
        Private uiTaskScheduler As TaskScheduler
        ' </snippet3>

        Public Sub New()
            InitializeComponent()

            ' Create the UI task scheduler from the current synchronization
            ' context.
            uiTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext()
        End Sub

        ' <snippet4>
        ' Creates the blocks that participate in the dataflow pipeline.
        Private Sub CreatePipeline()
            ' Create the cancellation source.
            cancellationSource = New CancellationTokenSource()

            ' Create the first node in the pipeline.
            startWork = New TransformBlock(Of WorkItem, WorkItem)(Function(workItem)
                                                                      ' Perform some work.
                                                                      ' Decrement the progress bar that tracks the count of
                                                                      ' active work items in this stage of the pipeline.
                                                                      ' Increment the progress bar that tracks the count of
                                                                      ' active work items in the next stage of the pipeline.
                                                                      ' Send the work item to the next stage of the pipeline.
                                                                      workItem.DoWork(250)
                                                                      decrementProgress.Post(toolStripProgressBar1)
                                                                      incrementProgress.Post(toolStripProgressBar2)
                                                                      Return workItem
                                                                  End Function,
            New ExecutionDataflowBlockOptions With {.CancellationToken = cancellationSource.Token})

            ' Create the second, and final, node in the pipeline.
            completeWork = New ActionBlock(Of WorkItem)(Sub(workItem)
                                                            ' Perform some work.
                                                            ' Decrement the progress bar that tracks the count of
                                                            ' active work items in this stage of the pipeline.
                                                            ' Increment the progress bar that tracks the overall
                                                            ' count of completed work items.
                                                            workItem.DoWork(1000)
                                                            decrementProgress.Post(toolStripProgressBar2)
                                                            incrementProgress.Post(toolStripProgressBar3)
                                                        End Sub,
            New ExecutionDataflowBlockOptions With {.CancellationToken = cancellationSource.Token,
                                                    .MaxDegreeOfParallelism = 2})

            ' Connect the two nodes of the pipeline. When the first node completes,
            ' set the second node also to the completed state.
            startWork.LinkTo(
               completeWork, New DataflowLinkOptions With {.PropagateCompletion = true})

            ' Create the dataflow action blocks that increment and decrement
            ' progress bars.
            ' These blocks use the task scheduler that is associated with
            ' the UI thread.

            incrementProgress = New ActionBlock(Of ToolStripProgressBar)(
               Sub(progressBar) progressBar.Value += 1,
               New ExecutionDataflowBlockOptions With {.CancellationToken = cancellationSource.Token,
                                                       .TaskScheduler = uiTaskScheduler})

            decrementProgress = New ActionBlock(Of ToolStripProgressBar)(
               Sub(progressBar) progressBar.Value -= 1,
               New ExecutionDataflowBlockOptions With {.CancellationToken = cancellationSource.Token,
                                                       .TaskScheduler = uiTaskScheduler})

        End Sub
        ' </snippet4>

        ' <snippet5>
        ' Event handler for the Add Work Items button.
        Private Sub toolStripButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButton1.Click
            ' The Cancel button is disabled when the pipeline is not active.
            ' Therefore, create the pipeline and enable the Cancel button
            ' if the Cancel button is disabled.
            If Not toolStripButton2.Enabled Then
                CreatePipeline()

                ' Enable the Cancel button.
                toolStripButton2.Enabled = True
            End If

            ' Post several work items to the head of the pipeline.
            For i As Integer = 0 To 4
                toolStripProgressBar1.Value += 1
                startWork.Post(New WorkItem())
            Next i
        End Sub
        ' </snippet5>

        ' <snippet6>
        ' Event handler for the Cancel button.
        Private Async Sub toolStripButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButton2.Click
            ' Disable both buttons.
            toolStripButton1.Enabled = False
            toolStripButton2.Enabled = False

            ' Trigger cancellation.
            cancellationSource.Cancel()

            Try
                ' Asynchronously wait for the pipeline to complete processing and for
                ' the progress bars to update.
                Await Task.WhenAll(completeWork.Completion, incrementProgress.Completion, decrementProgress.Completion)
            Catch e1 As OperationCanceledException
            End Try

            ' Increment the progress bar that tracks the number of cancelled
            ' work items by the number of active work items.
            toolStripProgressBar4.Value += toolStripProgressBar1.Value
            toolStripProgressBar4.Value += toolStripProgressBar2.Value

            ' Reset the progress bars that track the number of active work items.
            toolStripProgressBar1.Value = 0
            toolStripProgressBar2.Value = 0

            ' Enable the Add Work Items button.
            toolStripButton1.Enabled = True
        End Sub
        ' </snippet6>

        Protected Overrides Sub Finalize()
            cancellationSource.Dispose()
            MyBase.Finalize()
        End Sub
    End Class
End Namespace
' </snippet100>
