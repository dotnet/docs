            Uri baseAddress = new Uri("http://localhost:8000/servicemodelsamples/service");

            // Create a ServiceHost for the CalculatorService type and provide the base address.
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            // Create a custom binding that contains two binding elements.
            ReliableSessionBindingElement reliableSession = new ReliableSessionBindingElement();
            reliableSession.Ordered = true;

            HttpTransportBindingElement httpTransport = new HttpTransportBindingElement();
            httpTransport.AuthenticationScheme = System.Net.AuthenticationSchemes.Anonymous;
            httpTransport.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;

            BindingElement[] elements = new BindingElement[2];
            elements[0] = reliableSession;
            elements[1] = httpTransport;

            CustomBinding binding = new CustomBinding("MyCustomBinding", "http://localhost/service", elements);