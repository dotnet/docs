        Dim ListenerCollection As TraceListenerCollection
        ListenerCollection = My.Application.Log.TraceSource.Listeners
        Dim ListenersText As String = GetListeners(ListenerCollection)
        MsgBox(ListenersText)