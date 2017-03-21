        lazyLargeObject = new Lazy<LargeObject>(InitLargeObject, false);

        // The following lines show how to use other constructors to achieve exactly the
        // same result as the previous line: 
        //lazyLargeObject = new Lazy<LargeObject>(InitLargeObject, LazyThreadSafetyMode.None);