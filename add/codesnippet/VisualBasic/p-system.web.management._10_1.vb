   ' Get the request URL.
   Public Function GetRequestUrl() As String
      ' Get the request URL.
        Return String.Format("Request URL: {0}", _
        RequestInformation.RequestUrl)
   End Function 'GetRequestUrl
   