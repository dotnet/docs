            EndpointAddressBuilder eab = new EndpointAddressBuilder();
            eab.Uri = new Uri("http://localhost/Uri");
            eab.Headers.Add(AddressHeader.CreateAddressHeader("n", "ns", "val"));