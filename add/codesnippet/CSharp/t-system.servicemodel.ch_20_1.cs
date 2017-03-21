            BinaryMessageEncodingBindingElement be = new BinaryMessageEncodingBindingElement();
            be.MaxReadPoolSize = 16;
            be.MaxSessionSize = 2048;
            be.MaxWritePoolSize = 16;
            be.MessageVersion = MessageVersion.Default;
            XmlDictionaryReaderQuotas quotas = be.ReaderQuotas;

            CustomBinding binding = new CustomBinding();
            BindingParameterCollection bpCol = new BindingParameterCollection();
            BindingContext context = new BindingContext(binding, bpCol);
            be.BuildChannelFactory<IDuplexChannel>(context);

            CustomBinding binding2 = new CustomBinding();
            BindingParameterCollection bpCol2 = new BindingParameterCollection();
            BindingContext context2 = new BindingContext(binding2, bpCol2);
            be.BuildChannelListener<IDuplexChannel>(context2);

            be.CanBuildChannelListener<IDuplexChannel>(context2);
            BindingElement bindingElement = be.Clone();
            MessageEncoderFactory mef = be.CreateMessageEncoderFactory();
            MessageVersion mv = be.GetProperty<MessageVersion>(context);