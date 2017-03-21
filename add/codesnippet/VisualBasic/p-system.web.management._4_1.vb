   ' Get the request user host address.
   Public Function GetRequestUserHostAdddress() As String
      ' Get the request user host address.
        Return String.Format( _
        "Request user host address: {0}", _
        RequestInformation.UserHostAddress)
   End Function 'GetRequestUserHostAdddress
   