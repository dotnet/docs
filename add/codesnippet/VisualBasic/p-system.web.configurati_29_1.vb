      ' Get the current Forms property.
        Dim currentForms _
        As FormsAuthenticationConfiguration = _
        authenticationSection.Forms
      
      ' Get the Forms attributes.
        Dim name As String = _
        currentForms.Name
        Dim login As String = _
        currentForms.LoginUrl
        Dim path As String = _
        currentForms.Path
        Dim cookieLess As HttpCookieMode = _
        currentForms.Cookieless
        Dim requireSSL As Boolean = _
        currentForms.RequireSSL
        Dim slidingExpiration As Boolean = _
        currentForms.SlidingExpiration
        Dim enableXappRedirect As Boolean = _
        currentForms.EnableCrossAppRedirects
      
        Dim timeout As TimeSpan = _
        currentForms.Timeout
        Dim protection As FormsProtectionEnum = _
        currentForms.Protection
        Dim defaultUrl As String = _
        currentForms.DefaultUrl
        Dim domain As String = _
        currentForms.Domain