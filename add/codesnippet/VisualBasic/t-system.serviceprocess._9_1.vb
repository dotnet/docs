    ' Handle a session change notice
    Protected Overrides Sub OnSessionChange(ByVal changeDescription As SessionChangeDescription)
#If LOGEVENTS Then
        System.Diagnostics.EventLog.WriteEntry("SimpleService.OnSessionChange", DateTime.Now.ToLongTimeString() + " - Session change notice received: " + changeDescription.Reason.ToString() + "  Session ID: " + changeDescription.SessionId.ToString())
#End If

        Select Case changeDescription.Reason
            Case SessionChangeReason.SessionLogon
                userCount += 1
#If LOGEVENTS Then
                System.Diagnostics.EventLog.WriteEntry("SimpleService.OnSessionChange", DateTime.Now.ToLongTimeString() + " SessionLogon, total users: " + userCount.ToString())
#End If
            Case SessionChangeReason.SessionLogoff

                userCount -= 1
#If LOGEVENTS Then
                System.Diagnostics.EventLog.WriteEntry("SimpleService.OnSessionChange", DateTime.Now.ToLongTimeString() + " SessionLogoff, total users: " + userCount.ToString())
#End If
            Case SessionChangeReason.RemoteConnect
                userCount += 1
#If LOGEVENTS Then
                System.Diagnostics.EventLog.WriteEntry("SimpleService.OnSessionChange", DateTime.Now.ToLongTimeString() + " RemoteConnect, total users: " + userCount.ToString())
#End If
            Case SessionChangeReason.RemoteDisconnect
                userCount -= 1
#If LOGEVENTS Then
                System.Diagnostics.EventLog.WriteEntry("SimpleService.OnSessionChange", DateTime.Now.ToLongTimeString() + " RemoteDisconnect, total users: " + userCount.ToString())
#End If
            Case SessionChangeReason.SessionLock
#If LOGEVENTS Then
                System.Diagnostics.EventLog.WriteEntry("SimpleService.OnSessionChange", DateTime.Now.ToLongTimeString() + " SessionLock")
#End If
            Case SessionChangeReason.SessionUnlock
#If LOGEVENTS Then
                System.Diagnostics.EventLog.WriteEntry("SimpleService.OnSessionChange", DateTime.Now.ToLongTimeString() + " SessionUnlock")
#End If
            Case Else
        End Select

    End Sub 'OnSessionChange
