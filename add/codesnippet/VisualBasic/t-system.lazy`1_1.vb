        lazyLargeObject = New Lazy(Of LargeObject)(AddressOf InitLargeObject)

        ' The following lines show how to use other constructors to achieve exactly the
        ' same result as the previous line: 
        'lazyLargeObject = new Lazy<LargeObject>(InitLargeObject, true);
        'lazyLargeObject = new Lazy<LargeObject>(InitLargeObject, _
        '                               LazyThreadSafetyMode.ExecutionAndPublication);