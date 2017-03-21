        lazyLargeObject = New Lazy(Of LargeObject)()

        ' The following lines show how to use other constructors to achieve exactly the
        ' same result as the previous line: 
        'lazyLargeObject = New Lazy(Of LargeObject)(True)
        'lazyLargeObject = New Lazy(Of LargeObject)(LazyThreadSafetyMode.ExecutionAndPublication)