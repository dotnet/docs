
using System;
using System.Configuration;


// Define a custom section that contains a custom
// UrlsCollection collection of custom UrlConfigElement elements.
// This class shows how to use the ConfigurationCollectionAttribute.
public class UrlsSection : ConfigurationSection
{
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

}

// Define the custom UrlsCollection that contains the 
// custom UrlsConfigElement elements.
public class UrlsCollection : ConfigurationElementCollection
{
    public UrlsCollection()
    {
        UrlConfigElement url = (UrlConfigElement)CreateNewElement();
        Add(url);
    }

    public override ConfigurationElementCollectionType CollectionType
    {
        get
        {
            return ConfigurationElementCollectionType.AddRemoveClearMap;
        }
    }

    protected override ConfigurationElement CreateNewElement()
    {
        return new UrlConfigElement();
    }

    protected override Object GetElementKey(ConfigurationElement element)
    {
        return ((UrlConfigElement)element).Name;
    }

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

    new public UrlConfigElement this[string Name]
    {
        get
        {
            return (UrlConfigElement)BaseGet(Name);
        }
    }

    public int IndexOf(UrlConfigElement url)
    {
        return BaseIndexOf(url);
    }

    public void Add(UrlConfigElement url)
    {
        BaseAdd(url);
    }
    protected override void BaseAdd(ConfigurationElement element)
    {
        BaseAdd(element, false);
    }

    public void Remove(UrlConfigElement url)
    {
        if (BaseIndexOf(url) >= 0)
            BaseRemove(url.Name);
    }

    public void RemoveAt(int index)
    {
        BaseRemoveAt(index);
    }

    public void Remove(string name)
    {
        BaseRemove(name);
    }

    public void Clear()
    {
        BaseClear();
    }
}

// Define the custom UrlsConfigElement elements that are contained 
// by the custom UrlsCollection.
// Notice that you can change the default values to create new default elements.
public class UrlConfigElement : ConfigurationElement
{
    public UrlConfigElement(String name, String url)
    {
        this.Name = name;
        this.Url = url;
    }

    public UrlConfigElement()
    {

        this.Name = "Contoso";
        this.Url = "http://www.contoso.com";
        this.Port = 0;
    }

    [ConfigurationProperty("name", DefaultValue = "Contoso",
        IsRequired = true, IsKey = true)]
    public string Name
    {
        get
        {
            return (string)this["name"];
        }
        set
        {
            this["name"] = value;
        }
    }

    [ConfigurationProperty("url", DefaultValue = "http://www.contoso.com",
        IsRequired = true)]
    [RegexStringValidator(@"\w+:\/\/[\w.]+\S*")]
    public string Url
    {
        get
        {
            return (string)this["url"];
        }
        set
        {
            this["url"] = value;
        }
    }

    [ConfigurationProperty("port", DefaultValue = (int)0, IsRequired = false)]
    [IntegerValidator(MinValue = 0, MaxValue = 8080, ExcludeRange = false)]
    public int Port
    {
        get
        {
            return (int)this["port"];
        }
        set
        {
            this["port"] = value;
        }
    }
}
