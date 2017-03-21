    Dim requiresSession As Boolean = False
    
    If TypeOf (Context.Handler) Is IRequiresSessionState Then
      requiresSession = True
    End If