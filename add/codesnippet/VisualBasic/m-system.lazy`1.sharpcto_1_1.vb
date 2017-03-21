        lazyLargeObject = New Lazy(Of LargeObject)(AddressOf InitLargeObject, _
             LazyThreadSafetyMode.PublicationOnly)