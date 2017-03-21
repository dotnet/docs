            Dim eab As New EndpointAddressBuilder()
            eab.Uri = New Uri("http://localhost/Uri")
            eab.Headers.Add(AddressHeader.CreateAddressHeader("n", "ns", "val"))