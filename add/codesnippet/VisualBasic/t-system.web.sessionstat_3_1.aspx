    Dim readOnlySession As Boolean = False
    
    If TypeOf (Context.Handler) Is IReadOnlySessionState Then
      readOnlySession = True
    End If