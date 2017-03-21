    '
        ' Session.CodePage exists only to support legacy ASP compatibility. ASP.NET developers should use
    ' Response.ContentEncoding instead.
    '
    Public Property CodePage As Integer Implements IHttpSessionState.CodePage    
      Get
        If Not HttpContext.Current Is Nothing Then
          Return HttpContext.Current.Response.ContentEncoding.CodePage
        Else
          Return Encoding.Default.CodePage
        End If
      End Get
      Set       
        If Not HttpContext.Current Is Nothing Then _
          HttpContext.Current.Response.ContentEncoding = Encoding.GetEncoding(value)
      End Set
    End Property