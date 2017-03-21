    '
        ' Session.LCID exists only to support legacy ASP compatibility. ASP.NET developers should use
    ' Page.LCID instead.
    '
    Public Property LCID As Integer Implements IHttpSessionState.LCID
      Get
        Return Thread.CurrentThread.CurrentCulture.LCID
      End Get
      Set
        Thread.CurrentThread.CurrentCulture = CultureInfo.ReadOnly(new CultureInfo(value))
      End Set
    End Property