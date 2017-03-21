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