        lazyLargeObject = new Lazy<LargeObject>(InitLargeObject);

        // The following lines show how to use other constructors to achieve exactly the
        // same result as the previous line: 
        //lazyLargeObject = new Lazy<LargeObject>(InitLargeObject, true);
        //lazyLargeObject = new Lazy<LargeObject>(InitLargeObject, LazyThreadSafetyMode.ExecutionAndPublication);