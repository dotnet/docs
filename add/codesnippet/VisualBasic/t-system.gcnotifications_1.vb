    Public Shared Sub WaitForFullGCProc()

        While True
            ' CheckForNotify is set to true and false in Main.

            While checkForNotify
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

                ' Check for a notification of a completed collection.
                s = GC.WaitForFullGCComplete
                If (s = GCNotificationStatus.Succeeded) Then
                    Console.WriteLine("GC Notifiction raised.")
                    OnFullGCCompleteEndNotify()
                ElseIf (s = GCNotificationStatus.Canceled) Then
                    Console.WriteLine("GC Notification cancelled.")
                    Exit While
                Else
                    ' Could be a time out.
                    Console.WriteLine("GC Notification not applicable.")
                    Exit While
                End If

            End While
            Thread.Sleep(500)
            ' FinalExit is set to true right before  
            ' the main thread cancelled notification.
            If finalExit Then
                Exit While
            End If

        End While
    End Sub