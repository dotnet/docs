            CustomBinding binding = new CustomBinding();
            HttpTransportBindingElement element = new HttpTransportBindingElement();
            BindingParameterCollection parameters = new BindingParameterCollection();
            parameters.Add(new ServiceCredentials());
            Uri baseAddress = new Uri("http://localhost:8000/ChannelApp");
            String relAddress = "http://localhost:8000/ChannelApp/service";
            BindingContext context = new BindingContext(binding, parameters, baseAddress, relAddress, ListenUriMode.Explicit);

            ServiceCredentials serviceCredentials = element.GetProperty<ServiceCredentials>(context);