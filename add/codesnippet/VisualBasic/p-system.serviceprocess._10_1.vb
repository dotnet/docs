    ' Handle a session change notice
    Protected Overrides Sub OnSessionChange(ByVal changeDescription As SessionChangeDescription)
#If LOGEVENTS Then
        System.Diagnostics.EventLog.WriteEntry("SimpleService.OnSessionChange", DateTime.Now.ToLongTimeString() + " - Session change notice received: " + changeDescription.Reason.ToString() + "  Session ID: " + changeDescription.SessionId.ToString())
#End If
