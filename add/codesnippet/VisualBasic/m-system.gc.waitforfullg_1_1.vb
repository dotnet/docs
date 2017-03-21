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