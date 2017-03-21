            CustomBinding binding = new CustomBinding();
            HttpTransportBindingElement element = new HttpTransportBindingElement();
            BindingParameterCollection parameters = new BindingParameterCollection();
            Uri baseAddress = new Uri("http://localhost:8000/ChannelApp");
            String relAddress = "http://localhost:8000/ChannelApp/service";
            BindingContext context = new BindingContext(binding, parameters, baseAddress, relAddress, ListenUriMode.Explicit);

            bool bFlag = element.CanBuildChannelListener<IReplyChannel>(context);