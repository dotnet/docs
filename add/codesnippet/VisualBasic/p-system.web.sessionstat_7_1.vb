    Public ReadOnly Property IsCookieless As Boolean Implements IHttpSessionState.IsCookieLess    
      Get
        Return CookieMode = HttpCookieMode.UseUri
      End Get
    End Property