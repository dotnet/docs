            Dim binding As BasicHttpBinding = New BasicHttpBinding()
            Dim address As Uri = New Uri("http://localhost:8000/servicemodelsamples/service/basic")
            serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, address)