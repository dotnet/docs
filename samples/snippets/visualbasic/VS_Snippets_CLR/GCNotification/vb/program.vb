' <Snippet1>
' <Snippet2>
Imports System.Collections.Generic
Imports System.Threading

Class Program
    ' Variables for continual checking in the
    ' While loop in the WaitForFullGcProc method.
    Private Shared checkForNotify As Boolean = False

    ' Variable for suspending work
    ' (such as servicing allocated server requests)
    ' after a notification is received and then
    ' resuming allocation after inducing a garbage collection.
    Private Shared bAllocate As Boolean = False

    ' Variable for ending the example.
    Private Shared finalExit As Boolean = False

    ' Collection for objects that
    ' simulate the server request workload.
    Private Shared load As New List(Of Byte())


    Public Shared Sub Main(ByVal args() As String)
        Try
            ' Register for a notification.
            GC.RegisterForFullGCNotification(10, 10)
            Console.WriteLine("Registered for GC notification.")

            bAllocate = True
            checkForNotify = True

            ' Start a thread using WaitForFullGCProc.
            Dim thWaitForFullGC As Thread = _
                New Thread(New ThreadStart(AddressOf WaitForFullGCProc))
            thWaitForFullGC.Start()

            ' While the thread is checking for notifications in
            ' WaitForFullGCProc, create objects to simulate a server workload.
            Try
                Dim lastCollCount As Integer = 0
                Dim newCollCount As Integer = 0


                While (True)
                    If bAllocate = True Then

                        load.Add(New Byte(1000) {})
                        newCollCount = GC.CollectionCount(2)
                        If (newCollCount <> lastCollCount) Then
                            ' Show collection count when it increases:
                            Console.WriteLine("Gen 2 collection count: {0}", _
                                              GC.CollectionCount(2).ToString)
                            lastCollCount = newCollCount
                        End If

                        ' For ending the example (arbitrary).
                        If newCollCount = 500 Then
                            finalExit = True
                            checkForNotify = False
                            bAllocate = False
                            Exit While
                        End If

                    End If
                End While

            Catch outofMem As OutOfMemoryException
                Console.WriteLine("Out of memory.")
            End Try

            ' <Snippet7>
            finalExit = True
            checkForNotify = False
            GC.CancelFullGCNotification()
            ' </Snippet7>

        Catch invalidOp As InvalidOperationException
            Console.WriteLine("GC Notifications are not supported while concurrent GC is enabled." _
                              & vbLf & invalidOp.Message)
        End Try
    End Sub

    ' <Snippet5>
    Public Shared Sub OnFullGCApproachNotify()
        Console.WriteLine("Redirecting requests.")

        ' Method that tells the request queuing
        ' server to not direct requests to this server.
        RedirectRequests()

        ' Method that provides time to
        ' finish processing pending requests.
        FinishExistingRequests()

        ' This is a good time to induce a GC collection
        ' because the runtime will induce a ful GC soon.
        ' To be very careful, you can check precede with a
        ' check of the GC.GCCollectionCount to make sure
        ' a full GC did not already occur since last notified.
        GC.Collect()
        Console.WriteLine("Induced a collection.")
    End Sub

    ' </Snippet5>
    ' <Snippet6>
    Public Shared Sub OnFullGCCompleteEndNotify()
        ' Method that informs the request queuing server
        ' that this server is ready to accept requests again.
        AcceptRequests()
        Console.WriteLine("Accepting requests again.")
    End Sub

    ' </Snippet6>
    ' <Snippet8>
    Public Shared Sub WaitForFullGCProc()

        While True
            ' CheckForNotify is set to true and false in Main.

            While checkForNotify
                ' <Snippet3>
                ' Check for a notification of an approaching collection.
                Dim s As GCNotificationStatus = GC.WaitForFullGCApproach
                If (s = GCNotificationStatus.Succeeded) Then
                    Console.WriteLine("GC Notification raised.")
                    OnFullGCApproachNotify()
                ElseIf (s = GCNotificationStatus.Canceled) Then
                    Console.WriteLine("GC Notification cancelled.")
                    Exit While
                Else
                    ' This can occur if a timeout period
                    ' is specified for WaitForFullGCApproach(Timeout)
                    ' or WaitForFullGCComplete(Timeout)
                    ' and the time out period has elapsed.
                    Console.WriteLine("GC Notification not applicable.")
                    Exit While
                End If
                ' </Snippet3>

                ' <Snippet4>
                ' Check for a notification of a completed collection.
                s = GC.WaitForFullGCComplete
                If (s = GCNotificationStatus.Succeeded) Then
                    Console.WriteLine("GC Notification raised.")
                    OnFullGCCompleteEndNotify()
                ElseIf (s = GCNotificationStatus.Canceled) Then
                    Console.WriteLine("GC Notification cancelled.")
                    Exit While
                Else
                    ' Could be a time out.
                    Console.WriteLine("GC Notification not applicable.")
                    Exit While
                End If
                ' </Snippet4>

            End While
            Thread.Sleep(500)
            ' FinalExit is set to true right before
            ' the main thread cancelled notification.
            If finalExit Then
                Exit While
            End If

        End While
    End Sub
    ' </Snippet8>

    ' <Snippet9>
    Private Shared Sub RedirectRequests()
        ' Code that sends requests
        ' to other servers.

        ' Suspend work.
        bAllocate = False
    End Sub

    Private Shared Sub FinishExistingRequests()
        ' Code that waits a period of time
        ' for pending requests to finish.

        ' Clear the simulated workload.
        load.Clear()

    End Sub

    Private Shared Sub AcceptRequests()
        ' Code that resumes processing
        ' requests on this server.

        ' Resume work.
        bAllocate = True
    End Sub
    ' </Snippet9>
End Class
' </Snippet2>
' </Snippet1>
