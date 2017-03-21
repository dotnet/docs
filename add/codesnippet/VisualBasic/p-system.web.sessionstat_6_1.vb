    Public Property Timeout As Integer Implements IHttpSessionState.Timeout
      Get
        Return pTimeout
      End Get
      Set
        If value <= 0 Then _
          Throw New ArgumentException("Timeout value must be greater than zero.")

        If value > MAX_TIMEOUT Then _
          Throw New ArgumentException("Timout cannot be greater than " & MAX_TIMEOUT.ToString())

        pTimeout = value
      End Set
    End Property