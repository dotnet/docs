    Public Function GetSessionID(context As HttpContext) As String _
      Implements ISessionIDManager.GetSessionID
    
      Dim id As String = Nothing

      If pConfig.Cookieless = HttpCookieMode.UseUri Then
        ' Retrieve the SessionID from the URI.
      Else
        id = context.Request.Cookies(pConfig.CookieName).Value
      End If    

      ' Verify that the retrieved SessionID is valid. If not, return Nothing.

      If Not Validate(id) Then _
        id = Nothing

      Return id
    End Function