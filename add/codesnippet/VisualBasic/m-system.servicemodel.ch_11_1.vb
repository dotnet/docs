			Dim binding As New CustomBinding()
			Dim bpCol As New BindingParameterCollection()
			Dim context As New BindingContext(binding, bpCol)
			Dim quotas As XmlDictionaryReaderQuotas = context.GetInnerProperty(Of XmlDictionaryReaderQuotas)()