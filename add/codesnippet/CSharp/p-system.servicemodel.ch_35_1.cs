            CustomBinding binding = new CustomBinding();
            BindingParameterCollection bpCol = new BindingParameterCollection();
            BindingContext context = new BindingContext(binding, bpCol);
            Uri baseAddress = context.ListenUriBaseAddress;