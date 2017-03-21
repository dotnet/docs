        lazyLargeObject = New Lazy(Of LargeObject)(AddressOf InitLargeObject, False)

        ' The following lines show how to use other constructors to achieve exactly the
        ' same result as the previous line: 
        'lazyLargeObject = New Lazy(Of LargeObject)(AddressOf InitLargeObject, LazyThreadSafetyMode.None)