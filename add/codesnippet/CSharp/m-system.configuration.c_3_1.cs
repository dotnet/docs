    public void Remove(UrlConfigElement url)
    {
        if (BaseIndexOf(url) >= 0)
        {
            BaseRemove(url.Name);
            // Your custom code goes here.
            Console.WriteLine("UrlsCollection: {0}", "Removed collection element!");
        }
    }