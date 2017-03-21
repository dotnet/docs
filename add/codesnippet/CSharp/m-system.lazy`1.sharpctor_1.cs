        lazyLargeObject = new Lazy<LargeObject>();

        // The following lines show how to use other constructors to achieve exactly the
        // same result as the previous line: 
        //lazyLargeObject = new Lazy<LargeObject>(true);
        //lazyLargeObject = new Lazy<LargeObject>(LazyThreadSafetyMode.ExecutionAndPublication);