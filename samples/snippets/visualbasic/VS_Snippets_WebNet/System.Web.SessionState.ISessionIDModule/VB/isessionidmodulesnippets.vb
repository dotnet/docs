'<Snippet1>
Imports System
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Web
Imports System.Web.SessionState


Namespace Samples.AspNet.Session


  Public Class MySessionIDManager
    Implements IHttpModule, ISessionIDManager

    Private pConfig As SessionStateSection = Nothing

    '
    ' IHttpModule Members
    '

    '
    ' IHttpModule.Init
    '

    Public Sub Init(app As HttpApplication) Implements IHttpModule.Init
    
      ' Obtain session-state configuration settings.

      If pConfig Is Nothing Then      
        Dim cfg As System.Configuration.Configuration = _
          WebConfigurationManager.OpenWebConfiguration( _
            System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath)
        pConfig = CType(cfg.GetSection("system.web/sessionState"), SessionStateSection)
      End If

    End Sub


    '
    ' IHttpModule.Dispose
    '

    Public Sub Dispose() Implements IHttpModule.Dispose
    
    End Sub



    '
    ' ISessionIDManager.Initialize
    '

    Public Sub Initialize() Implements ISessionIDManager.Initialize

    End Sub


    '
    ' ISessionIDManager.InitializeRequest
    '

    Public Function InitializeRequest(context As HttpContext,  _
                                      suppressAutoDetectRedirect As Boolean,  _
                                      ByRef supportSessionIDReissue As Boolean) As Boolean _
                                      Implements ISessionIDManager.InitializeRequest

      If pConfig.Cookieless = HttpCookieMode.UseCookies Then
        supportSessionIDReissue = False
        Return False
      Else
        supportSessionIDReissue = True
        Return context.Response.IsRequestBeingRedirected
      End If
    End Function



    '
    ' ISessionIDManager Members
    '


    '
    ' ISessionIDManager.GetSessionID
    '
  '<Snippet2>
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
  '</Snippet2>

    '
    ' ISessionIDManager.CreateSessionID
    '

  '<Snippet3>
    Public Function CreateSessionID(context As HttpContext) As String _
      Implements ISessionIDManager.CreateSessionID
    
      Return Guid.NewGuid().ToString()
    End Function
  '</Snippet3>

    '
    ' ISessionIDManager.RemoveSessionID
    '

  '<Snippet4>
    Public Sub RemoveSessionID(context As HttpContext) _
      Implements ISessionIDManager.RemoveSessionID

      context.Response.Cookies.Remove(pConfig.CookieName)

    End Sub
  '</Snippet4>


    '
    ' ISessionIDManager.SaveSessionID
    '

  '<Snippet5>
    Public Sub SaveSessionID(context As HttpContext, _
                             id As String, _
                             ByRef redirected As Boolean, _
                             ByRef cookieAdded As Boolean) _
      Implements ISessionIDManager.SaveSessionID
    
      redirected = False
      cookieAdded = False

      If pConfig.Cookieless = HttpCookieMode.UseUri Then

        ' Add the SessionID to the URI. Set the redirected variable as appropriate.

        redirected = True
        Return
      Else
        context.Response.Cookies.Add(New HttpCookie(pConfig.CookieName, id))
        cookieAdded = True
      End If
    End Sub
  '</Snippet5>


    '
    ' ISessionIDManager.Validate
    '

  '<Snippet6>
    Public Function Validate(id As String) As Boolean _
      Implements ISessionIDManager.Validate
    
      Try
        Dim testGuid As Guid = New Guid(id)

        If id = testGuid.ToString() Then _
          Return True
      Catch
      
      End Try

      Return False
    End Function
  '</Snippet6>

  End Class
End Namespace
'</Snippet1>

