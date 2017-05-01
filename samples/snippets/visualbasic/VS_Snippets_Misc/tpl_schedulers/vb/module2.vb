' <Snippet02>
Imports System.Collections.Generic
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Sub Main()
      ' Create a scheduler that uses two threads. 
      Dim lcts As New LimitedConcurrencyLevelTaskScheduler(2)
      Dim tasks As New List(Of Task)()
      
      ' Create a TaskFactory and pass it our custom scheduler. 
      Dim factory As New TaskFactory(lcts)
      Dim cts As New CancellationTokenSource()
      
      ' Use our factory to run a set of tasks. 
      Dim objLock As New Object()      
      Dim outputItem As Integer 
      For tCtr As Integer = 0 To 4
         Dim iteration As Integer = tCtr
         Dim t As Task = factory.StartNew(Sub()
                                             For i As Integer = 1 To 1000
                                                SyncLock objLock
                                                   Console.Write("{0} in task t-{1} on thread {2}   ", 
                                                   i, iteration, Thread.CurrentThread.ManagedThreadId)
                                                   outputItem += 1
                                                   If outputItem Mod 3 = 0 Then Console.WriteLine()
                                                End SyncLock
                                             Next 
                                          End Sub,
                                cts.Token)
         tasks.Add(t)
      Next 
      ' Use it to run a second set of tasks.                       
      For tCtr As Integer = 0 To 4
         Dim iteration As Integer = tCtr
         Dim t1 As Task = factory.StartNew(Sub()
                                              For outer As Integer = 0 To 10
                                                 For i As Integer = &h21 To &h7E
                                                    SyncLock objLock
                                                       Console.Write("'{0}' in task t1-{1} on thread {2}   ", 
                                                                     Convert.ToChar(i), iteration, Thread.CurrentThread.ManagedThreadId)
                                                       outputItem += 1
                                                       If outputItem Mod 3 = 0 Then Console.WriteLine()
                                                    End SyncLock 
                                                 Next     
                                              Next                                           
                                           End Sub,
                                cts.Token)           
         tasks.Add(t1)
      Next
      
      ' Wait for the tasks to complete before displaying a completion message.
      Task.WaitAll(tasks.ToArray())
      cts.Dispose()
      Console.WriteLine(vbCrLf + vbCrLf + "Successful completion.")
   End Sub 
End Module

' Provides a task scheduler that ensures a maximum concurrency level while 
' running on top of the thread pool.
Public Class LimitedConcurrencyLevelTaskScheduler : Inherits TaskScheduler
   ' Indicates whether the current thread is processing work items.
   <ThreadStatic()> Private Shared _currentThreadIsProcessingItems As Boolean 
   
   ' The list of tasks to be executed 
   Private ReadOnly _tasks As LinkedList(Of Task) = New LinkedList(Of Task)() 
   
   'The maximum concurrency level allowed by this scheduler. 
   Private ReadOnly _maxDegreeOfParallelism As Integer 
   
   ' Indicates whether the scheduler is currently processing work items. 
   Private _delegatesQueuedOrRunning As Integer = 0 ' protected by lock(_tasks)
   
   ' Creates a new instance with the specified degree of parallelism. 
   Public Sub New(ByVal maxDegreeOfParallelism As Integer)
      If (maxDegreeOfParallelism < 1) Then 
         Throw New ArgumentOutOfRangeException("maxDegreeOfParallelism")
      End If
         _maxDegreeOfParallelism = maxDegreeOfParallelism
   End Sub 

   ' Queues a task to the scheduler. 
   Protected Overrides Sub QueueTask(ByVal t As Task)
      ' Add the task to the list of tasks to be processed.  If there aren't enough 
      ' delegates currently queued or running to process tasks, schedule another. 
      SyncLock (_tasks)
         _tasks.AddLast(t)
         If (_delegatesQueuedOrRunning < _maxDegreeOfParallelism) Then
            _delegatesQueuedOrRunning = _delegatesQueuedOrRunning + 1
            NotifyThreadPoolOfPendingWork()
         End If 
      End SyncLock 
   End Sub 
   
   ' Inform the ThreadPool that there's work to be executed for this scheduler. 
   Private Sub NotifyThreadPoolOfPendingWork()
   
      ThreadPool.UnsafeQueueUserWorkItem(Sub()
                                            ' Note that the current thread is now processing work items. 
                                            ' This is necessary to enable inlining of tasks into this thread.
                                            _currentThreadIsProcessingItems = True 
                                            Try 
                                               ' Process all available items in the queue. 
                                               While (True)
                                                  Dim item As Task
                                                  SyncLock (_tasks)
                                                     ' When there are no more items to be processed, 
                                                     ' note that we're done processing, and get out. 
                                                     If (_tasks.Count = 0) Then
                                                        _delegatesQueuedOrRunning = _delegatesQueuedOrRunning - 1
                                                        Exit While 
                                                     End If 
   
                                                     ' Get the next item from the queue
                                                     item = _tasks.First.Value
                                                     _tasks.RemoveFirst()
                                                  End SyncLock 
   
                                                  ' Execute the task we pulled out of the queue 
                                                  MyBase.TryExecuteTask(item)
                                               End While 
                                               ' We're done processing items on the current thread 
                                            Finally
                                               _currentThreadIsProcessingItems = False 
                                            End Try 
                                         End Sub,
                                    Nothing)
   End Sub 
   
   ' Attempts to execute the specified task on the current thread. 
   Protected Overrides Function TryExecuteTaskInline(ByVal t As Task, 
                                                     ByVal taskWasPreviouslyQueued As Boolean) As Boolean 
      ' If this thread isn't already processing a task, we don't support inlining 
      If (Not _currentThreadIsProcessingItems) Then 
         Return False 
      End If 
   
      ' If the task was previously queued, remove it from the queue 
      If (taskWasPreviouslyQueued) Then
         ' Try to run the task. 
         If TryDequeue(t) Then 
            Return MyBase.TryExecuteTask(t)
         Else
            Return False 
         End If     
      Else 
         Return MyBase.TryExecuteTask(t)
      End If   
   End Function 
   
   ' Attempt to remove a previously scheduled task from the scheduler. 
   Protected Overrides Function TryDequeue(ByVal t As Task) As Boolean 
      SyncLock (_tasks)
         Return _tasks.Remove(t)
      End SyncLock 
   End Function 
   
   ' Gets the maximum concurrency level supported by this scheduler. 
   Public Overrides ReadOnly Property MaximumConcurrencyLevel As Integer 
      Get 
         Return _maxDegreeOfParallelism
      End Get 
   End Property 
   
   ' Gets an enumerable of the tasks currently scheduled on this scheduler. 
   Protected Overrides Function GetScheduledTasks() As IEnumerable(Of Task)
      Dim lockTaken As Boolean = False 
      Try
         Monitor.TryEnter(_tasks, lockTaken)
         If (lockTaken) Then 
            Return _tasks.ToArray()
         Else 
            Throw New NotSupportedException()
         End If 
      Finally 
         If (lockTaken) Then
            Monitor.Exit(_tasks)
         End If 
      End Try 
   End Function 
End Class 
' The following is a portion of the output from a single run of the example:
'    'T' in task t1-4 on thread 3   'U' in task t1-4 on thread 3   'V' in task t1-4 on thread 3   
'    'W' in task t1-4 on thread 3   'X' in task t1-4 on thread 3   'Y' in task t1-4 on thread 3   
'    'Z' in task t1-4 on thread 3   '[' in task t1-4 on thread 3   '\' in task t1-4 on thread 3   
'    ']' in task t1-4 on thread 3   '^' in task t1-4 on thread 3   '_' in task t1-4 on thread 3   
'    '`' in task t1-4 on thread 3   'a' in task t1-4 on thread 3   'b' in task t1-4 on thread 3   
'    'c' in task t1-4 on thread 3   'd' in task t1-4 on thread 3   'e' in task t1-4 on thread 3   
'    'f' in task t1-4 on thread 3   'g' in task t1-4 on thread 3   'h' in task t1-4 on thread 3   
'    'i' in task t1-4 on thread 3   'j' in task t1-4 on thread 3   'k' in task t1-4 on thread 3   
'    'l' in task t1-4 on thread 3   'm' in task t1-4 on thread 3   'n' in task t1-4 on thread 3   
'    'o' in task t1-4 on thread 3   'p' in task t1-4 on thread 3   ']' in task t1-2 on thread 4   
'    '^' in task t1-2 on thread 4   '_' in task t1-2 on thread 4   '`' in task t1-2 on thread 4   
'    'a' in task t1-2 on thread 4   'b' in task t1-2 on thread 4   'c' in task t1-2 on thread 4   
'    'd' in task t1-2 on thread 4   'e' in task t1-2 on thread 4   'f' in task t1-2 on thread 4   
'    'g' in task t1-2 on thread 4   'h' in task t1-2 on thread 4   'i' in task t1-2 on thread 4   
'    'j' in task t1-2 on thread 4   'k' in task t1-2 on thread 4   'l' in task t1-2 on thread 4   
'    'm' in task t1-2 on thread 4   'n' in task t1-2 on thread 4   'o' in task t1-2 on thread 4   
'    'p' in task t1-2 on thread 4   'q' in task t1-2 on thread 4   'r' in task t1-2 on thread 4   
'    's' in task t1-2 on thread 4   't' in task t1-2 on thread 4   'u' in task t1-2 on thread 4   
'    'v' in task t1-2 on thread 4   'w' in task t1-2 on thread 4   'x' in task t1-2 on thread 4   
'    'y' in task t1-2 on thread 4   'z' in task t1-2 on thread 4   '{' in task t1-2 on thread 4   
'    '|' in task t1-2 on thread 4   '}' in task t1-2 on thread 4   '~' in task t1-2 on thread 4   
'    'q' in task t1-4 on thread 3   'r' in task t1-4 on thread 3   's' in task t1-4 on thread 3   
'    't' in task t1-4 on thread 3   'u' in task t1-4 on thread 3   'v' in task t1-4 on thread 3   
'    'w' in task t1-4 on thread 3   'x' in task t1-4 on thread 3   'y' in task t1-4 on thread 3   
'    'z' in task t1-4 on thread 3   '{' in task t1-4 on thread 3   '|' in task t1-4 on thread 3  
' </Snippet02>

