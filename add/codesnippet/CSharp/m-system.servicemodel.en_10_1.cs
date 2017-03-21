        public static void CreateRSAIdentity()
        {
            // Create a ServiceHost for the CalculatorService type. Base Address is supplied in app.config.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService)))
            {
                // The base address is read from the app.config.
                Uri dnsrelativeAddress = new Uri(serviceHost.BaseAddresses[0], "dnsidentity");
                Uri certificaterelativeAddress = new Uri(serviceHost.BaseAddresses[0], "certificateidentity");
                Uri rsarelativeAddress = new Uri(serviceHost.BaseAddresses[0], "rsaidentity");

                // Set the service's X509Certificate to protect the messages.
                serviceHost.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine,
                                                                          StoreName.My,
                                                                          X509FindType.FindBySubjectDistinguishedName,
                                                                          "CN=identity.com, O=Contoso");
                //Cache a reference to the server's certificate.
                X509Certificate2 servercert = serviceHost.Credentials.ServiceCertificate.Certificate;

                //Create endpoints for the service using a WSHttpBinding set for anonymous clients.
                WSHttpBinding wsAnonbinding = new WSHttpBinding(SecurityMode.Message);
                //Clients are anonymous to the service.
                wsAnonbinding.Security.Message.ClientCredentialType = MessageCredentialType.None;
                //Secure conversation (session) is turned off.
                wsAnonbinding.Security.Message.EstablishSecurityContext = false;

                //Create a service endpoint and change its identity to the DNS for an X509 Certificate.
                ServiceEndpoint ep = serviceHost.AddServiceEndpoint(typeof(ICalculator),
                                                                    wsAnonbinding,
                                                                    String.Empty);
                EndpointAddress epa = new EndpointAddress(dnsrelativeAddress, EndpointIdentity.CreateDnsIdentity("identity.com"));
                ep.Address = epa;

                //Create a service endpoint and change its identity to the X509 certificate's RSA key value.
                ServiceEndpoint ep3 = serviceHost.AddServiceEndpoint(typeof(ICalculator), wsAnonbinding, String.Empty);
                EndpointAddress epa3 = new EndpointAddress(rsarelativeAddress, EndpointIdentity.CreateRsaIdentity(servercert));
                ep3.Address = epa3;