           CustomBinding binding = new CustomBinding();
           HttpTransportBindingElement element = new HttpTransportBindingElement();
           BindingParameterCollection parameters = new BindingParameterCollection();
           BindingContext context = new BindingContext(binding, parameters);

           bool bFlag = element.CanBuildChannelFactory<IRequestChannel>(context);