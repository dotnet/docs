        Dim baseAddresses() As Uri = {New Uri("http://localhost/one"), New Uri("http://localhost/two")}
        Dim host As WebServiceHost = New WebServiceHost(GetType(CalcService), baseAddresses)