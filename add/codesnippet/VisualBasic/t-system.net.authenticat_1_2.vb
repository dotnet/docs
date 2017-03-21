    Private Shared Function AuthenticationSchemeForClient(ByVal request As HttpListenerRequest) As AuthenticationSchemes
        Console.WriteLine("Client authentication protocol selection in progress...")
        ' Do not authenticate local machine requests.
        If request.RemoteEndPoint.Address.Equals(IPAddress.Loopback) Then
            Return AuthenticationSchemes.None
        Else
            Return AuthenticationSchemes.IntegratedWindowsAuthentication
        End If
    End Function