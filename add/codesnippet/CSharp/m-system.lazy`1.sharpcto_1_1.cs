        lazyLargeObject = new Lazy<LargeObject>(InitLargeObject, 
                                     LazyThreadSafetyMode.PublicationOnly);