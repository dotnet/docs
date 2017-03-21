            CustomBinding binding = new CustomBinding();
            BindingParameterCollection bpCol = new BindingParameterCollection();
            Uri baseAddress = new Uri("http://MyServer/Base");
            string relAddress = "MyService";
            BindingContext context = new BindingContext(binding, bpCol, baseAddress, relAddress, ListenUriMode.Explicit);