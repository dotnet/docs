            CustomBinding binding2 = new CustomBinding();
            BindingParameterCollection bpCol2 = new BindingParameterCollection();
            BindingContext context2 = new BindingContext(binding2, bpCol2);
            be.BuildChannelListener<IDuplexChannel>(context2);