            CustomBinding binding = new CustomBinding();
            BindingParameterCollection bpCol = new BindingParameterCollection();
            BindingContext context = new BindingContext(binding, bpCol);
            XmlDictionaryReaderQuotas quotas = context.GetInnerProperty<XmlDictionaryReaderQuotas>();