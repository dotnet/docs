    Public Function GetEnumerator() As IEnumerator Implements IHttpSessionState.GetEnumerator
        Return pSessionItems.GetEnumerator()
    End Function