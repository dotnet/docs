    Public Sub RemoveSessionID(context As HttpContext) _
      Implements ISessionIDManager.RemoveSessionID

      context.Response.Cookies.Remove(pConfig.CookieName)

    End Sub