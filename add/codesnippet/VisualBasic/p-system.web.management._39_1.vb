   ' Get the request principal.
   Public Function GetRequestPrincipal() As String
      ' Get the request principal.
        Return String.Format( _
        "Request principal name: {0}", _
        RequestInformation.Principal.Identity.Name)
   End Function 'GetRequestPrincipal
   