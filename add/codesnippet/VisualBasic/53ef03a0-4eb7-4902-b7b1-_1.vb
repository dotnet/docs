            Dim binding As BasicHttpBinding = New BasicHttpBinding()
            Dim listenUri As Uri = New Uri("http://localhost:8000/MyListenUri")
            Dim address As String = "http://localhost:8000/servicemodelsamples/service/basic"
            serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, address, listenUri)