        ' Create a resolver and specify the necessary credentials.
        Dim resolver As New XmlUrlResolver()
        Dim myCred As System.Net.NetworkCredential
        myCred = New System.Net.NetworkCredential(UserName, SecurelyStoredPassword, Domain)
        resolver.Credentials = myCred
    