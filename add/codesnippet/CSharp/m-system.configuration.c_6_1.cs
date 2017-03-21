    public UrlConfigElement this[int index]
    {
        get
        {
            return (UrlConfigElement)BaseGet(index);
        }
        set
        {
            if (BaseGet(index) != null)
            {
                BaseRemoveAt(index);
            }
            BaseAdd(index, value);
        }
    }