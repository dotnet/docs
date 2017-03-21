            Dim be As New BinaryMessageEncodingBindingElement()
            be.MaxReadPoolSize = 16
            be.MaxSessionSize = 2048
            be.MaxWritePoolSize = 16
            be.MessageVersion = MessageVersion.Default
            Dim quotas As XmlDictionaryReaderQuotas = be.ReaderQuotas

            Dim binding As New CustomBinding()
            Dim bpCol As New BindingParameterCollection()
            Dim context As New BindingContext(binding, bpCol)
            be.BuildChannelFactory(Of IDuplexChannel)(context)

            Dim binding2 As New CustomBinding()
            Dim bpCol2 As New BindingParameterCollection()
            Dim context2 As New BindingContext(binding2, bpCol2)
            be.BuildChannelListener(Of IDuplexChannel)(context2)

            be.CanBuildChannelListener(Of IDuplexChannel)(context2)
            Dim bindingElement As BindingElement = be.Clone()
            Dim mef As MessageEncoderFactory = be.CreateMessageEncoderFactory()
            Dim mv As MessageVersion = be.GetProperty(Of MessageVersion)(context)