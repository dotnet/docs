   ' Get the request path.
   Public Function GetRequestPath() As String
      ' Get the request path.
        Return String.Format( _
        "Request path: {0}", RequestInformation.RequestPath)
   End Function 'GetRequestPath
   