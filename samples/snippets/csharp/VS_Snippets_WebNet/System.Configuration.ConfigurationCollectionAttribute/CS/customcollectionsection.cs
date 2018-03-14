//<Snippet1>

using System;
using System.Configuration;


//<Snippet2>
// Define a custom section that contains a custom
// UrlsCollection collection of custom UrlConfigElement elements.
// This class shows how to use the ConfigurationCollectionAttribute.
public class UrlsSection : ConfigurationSection
{
    // <Snippet20>
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
    // </Snippet20>

}
//</Snippet2>

//<Snippet3>
// Define the custom UrlsCollection that contains the 
// custom UrlsConfigElement elements.
public class UrlsCollection : ConfigurationElementCollection
{
    public UrlsCollection()
    {
        UrlConfigElement url = (UrlConfigElement)CreateNewElement();
        Add(url);
    }

    //<Snippet5>
    public override ConfigurationElementCollectionType CollectionType
    {
        get
        {
            return ConfigurationElementCollectionType.AddRemoveClearMap;
        }
    }
    //</Snippet5>

    //<Snippet6>
    protected override ConfigurationElement CreateNewElement()
    {
        return new UrlConfigElement();
    }
    //</Snippet6>

    //<Snippet7>
    protected override Object GetElementKey(ConfigurationElement element)
    {
        return ((UrlConfigElement)element).Name;
    }
    //</Snippet7>

    //<Snippet8>
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
    //</Snippet8>

    //<Snippet9>
    new public UrlConfigElement this[string Name]
    {
        get
        {
            return (UrlConfigElement)BaseGet(Name);
        }
    }
    //</Snippet9>

    //<Snippet10>
    public int IndexOf(UrlConfigElement url)
    {
        return BaseIndexOf(url);
    }
    //</Snippet10>

    //<Snippet11>
    public void Add(UrlConfigElement url)
    {
        BaseAdd(url);
    }
    protected override void BaseAdd(ConfigurationElement element)
    {
        BaseAdd(element, false);
    }
    //</Snippet11>        

    //<Snippet12>
    public void Remove(UrlConfigElement url)
    {
        if (BaseIndexOf(url) >= 0)
            BaseRemove(url.Name);
    }
    //</Snippet12>

    //<Snippet13>
    public void RemoveAt(int index)
    {
        BaseRemoveAt(index);
    }
    //</Snippet13>

    //<Snippet14>
    public void Remove(string name)
    {
        BaseRemove(name);
    }
    //</Snippet14>

    //<Snippet15>
    public void Clear()
    {
        BaseClear();
    }
    //</Snippet15>
}
//</Snippet3>

//<Snippet4>
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

    //<Snippet16>
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
    //</Snippet16>

    //<Snippet17>
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
    //</Snippet17>

    //<Snippet18> 
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
    //</Snippet18>
}
//</Snippet4>

//</Snippet1>
