            CustomBinding binding = new CustomBinding();
            BindingParameterCollection bpCol = new BindingParameterCollection();
            BindingContext context = new BindingContext(binding, bpCol);
            be.BuildChannelFactory<IDuplexChannel>(context);