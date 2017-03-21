        lazyLargeObject = New Lazy(Of LargeObject)(AddressOf InitLargeObject)

        ' The following lines show how to use other constructors to achieve exactly the
        ' same result as the previous line: 
        'lazyLargeObject = New Lazy(Of LargeObject)(AddressOf InitLargeObject, True)
        'lazyLargeObject = New Lazy(Of LargeObject)(AddressOf InitLargeObject, LazyThreadSafetyMode.ExecutionAndPublication)