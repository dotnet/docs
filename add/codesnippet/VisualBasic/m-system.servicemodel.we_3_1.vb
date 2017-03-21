        Dim baseAddresses() As Uri = {New Uri("http://localhost/one"), New Uri("http://localhost/two")}
        Dim mySingleton As Object = GetObject()
        Dim host As WebServiceHost = New WebServiceHost(mySingleton, baseAddresses)