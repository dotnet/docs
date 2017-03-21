    protected override Object GetElementKey(ConfigurationElement element)
    {
        return ((UrlConfigElement)element).Name;
    }