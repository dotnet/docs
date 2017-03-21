    // Declare the Urls collection property using the
    // ConfigurationCollectionAttribute.
    // This allows to build a nested section that contains
    // a collection of elements.
    [ConfigurationProperty("urls", IsDefaultCollection = false)]
    [ConfigurationCollection(typeof(UrlsCollection),
        AddItemName = "add",
        ClearItemsName = "clear",
        RemoveItemName = "remove")]
    public UrlsCollection Urls
    {
        get
        {
            UrlsCollection urlsCollection =
                (UrlsCollection)base["urls"];
            return urlsCollection;
        }
    }