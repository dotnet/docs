' Alternative to using SignalTime to ensure that Elapsed 
' events are not processed if they occur after the timer 
' has been stopped. The object is to avoid race conditions.
'
'<Snippet1>
Imports System
Imports System.Timers
Imports System.Threading

Public Module Test
    
    ' Change these values to control the behavior of the program.
    Private testRuns As Integer = 100 
    ' Times are given in milliseconds:
    Private testRunsFor As Integer = 500
    Private timerIntervalBase As Integer = 100
    Private timerIntervalDelta As Integer = 20

    ' Timers.
    Private WithEvents Timer1 As New System.Timers.Timer
    Private WithEvents Timer2 As New System.Timers.Timer
    Private currentTimer As System.Timers.timer

    Private rand As New Random()

    ' This is the synchronization point that prevents events
    ' from running concurrently, and prevents the main thread 
    ' from executing code after the Stop method until any 
    ' event handlers are done executing.
    Private syncPoint As Integer = 0

    ' Count the number of times the event handler is called,
    ' is executed, is skipped, or is called after Stop.
    Private numEvents As Integer = 0
    Private numExecuted As Integer = 0
    Private numSkipped As Integer = 0
    Private numLate As Integer = 0

    ' Count the number of times the thread that calls Stop
    ' has to wait for an Elapsed event to finish.
    Private numWaits As Integer = 0

    <MTAThread> _
    Sub Main()
        Console.WriteLine()
        For i As Integer = 1 To testRuns
            TestRun
            Console.Write(vbCr & "Test {0}/{1}    ", i, testRuns)
        Next

        Console.WriteLine("{0} test runs completed.", testRuns)
        Console.WriteLine("{0} events were raised.", numEvents)
        Console.WriteLine("{0} events executed.", numExecuted)
        Console.WriteLine("{0} events were skipped for concurrency.", numSkipped)
        Console.WriteLine("{0} events were skipped because they were late.", numLate)
        Console.WriteLine("Control thread waited {0} times for an event to complete.", numWaits)
    End Sub

    Sub TestRun()
        ' Set syncPoint to zero before starting the test 
        ' run. 
        syncPoint = 0

        ' Test runs alternate between Timer1 and Timer2, to avoid
        ' race conditions between tests, or with very late events.
        If currentTimer Is Timer1 Then
            currentTimer = Timer2
        Else
            currentTimer = Timer1
        End If

        currentTimer.Interval = timerIntervalBase _
            - timerIntervalDelta + rand.Next(timerIntervalDelta * 2)
        currentTimer.Enabled = True

        ' Start the control thread that shuts off the timer.
        Dim t As New Thread(AddressOf ControlThreadProc)
        t.Start()

        ' Wait until the control thread is done before proceeding.
        ' This keeps the test runs from overlapping.
        t.Join()

    End Sub


    Private Sub ControlThreadProc()
        ' Allow the timer to run for a period of time, and then 
        ' stop it.
        Thread.Sleep(testRunsFor) 
        currentTimer.Stop

        ' The 'counted' flag ensures that if this thread has
        ' to wait for an event to finish, the wait only gets 
        ' counted once.
        Dim counted As Boolean = False

        ' Ensure that if an event is currently executing,
        ' no further processing is done on this thread until
        ' the event handler is finished. This is accomplished
        ' by using CompareExchange to place -1 in syncPoint,
        ' but only if syncPoint is currently zero (specified
        ' by the third parameter of CompareExchange). 
        ' CompareExchange returns the original value that was
        ' in syncPoint. If it was not zero, then there's an
        ' event handler running, and it is necessary to try
        ' again.
        While Interlocked.CompareExchange(syncPoint, -1, 0) <> 0 
            ' Give up the rest of this thread's current time
            ' slice. This is a naive algorithm for yielding.
            Thread.Sleep(1)

            ' Tally a wait, but don't count multiple calls to
            ' Thread.Sleep.
            If Not counted Then
                numWaits += 1
                counted = True
            End If
        End While

        ' Any processing done after this point does not conflict
        ' with timer events. This is the purpose of the call to
        ' CompareExchange. If the processing done here would not
        ' cause a problem when run concurrently with timer events,
        ' then there is no need for the extra synchronization.
    End Sub


    ' Event-handling methods for the Elapsed events of the two
    ' timers.
    '
    Private Sub Timer1_ElapsedEventHandler(ByVal sender As Object, _
        ByVal e As ElapsedEventArgs) Handles Timer1.Elapsed

        HandleElapsed(sender, e)
    End Sub

    Private Sub Timer2_ElapsedEventHandler(ByVal sender As Object, _
        ByVal e As ElapsedEventArgs) Handles Timer2.Elapsed

        HandleElapsed(sender, e)
    End Sub

    Private Sub HandleElapsed(ByVal sender As Object, ByVal e As ElapsedEventArgs)

        numEvents += 1

        ' This example assumes that overlapping events can be
        ' discarded. That is, if an Elapsed event is raised before 
        ' the previous event is finished processing, the second
        ' event is ignored. 
        '
        ' CompareExchange is used to take control of syncPoint, 
        ' and to determine whether the attempt was successful. 
        ' CompareExchange attempts to put 1 into syncPoint, but
        ' only if the current value of syncPoint is zero 
        ' (specified by the third parameter). If another thread
        ' has set syncPoint to 1, or if the control thread has
        ' set syncPoint to -1, the current event is skipped. 
        ' (Normally it would not be necessary to use a local 
        ' variable for the return value. A local variable is 
        ' used here to determine the reason the event was 
        ' skipped.)
        '
        Dim sync As Integer = Interlocked.CompareExchange(syncPoint, 1, 0)
        If sync = 0 Then
            ' No other event was executing.
            ' The event handler simulates an amount of work
            ' similar to the time between events, so that
            ' some events will overlap.
            Dim delay As Integer = timerIntervalBase _
                - timerIntervalDelta / 2 + rand.Next(timerIntervalDelta)
            Thread.Sleep(delay)
            numExecuted += 1

            ' Release control of syncPoint.
            syncPoint = 0
        Else
            If sync = 1 Then numSkipped += 1 Else numLate += 1
        End If
    End Sub 

End Module

' On a dual-processor computer, this code example produces
' results similar to the following:
'
'Test 100/100    100 test runs completed.
'436 events were raised.
'352 events executed.
'84 events were skipped for concurrency.
'0 events were skipped because they were late.
'Control thread waited 77 times for an event to complete.
'</Snippet1>
