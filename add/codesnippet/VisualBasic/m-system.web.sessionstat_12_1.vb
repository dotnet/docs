    '
    ' Abandon marks the session as abandoned. The IsAbandoned property is used by the
    ' session state module to perform the abandon work during the ReleaseRequestState event.
    '
    Public Sub Abandon() Implements IHttpSessionState.Abandon
      pAbandon = True
    End Sub

    Public ReadOnly Property IsAbandoned As Boolean  
      Get
        Return pAbandon
      End Get
    End Property