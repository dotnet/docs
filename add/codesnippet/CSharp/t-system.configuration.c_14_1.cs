using System;
using System.Configuration;

// Define a UrlsSection custom section that contains a 
// UrlsCollection collection of UrlConfigElement elements.
public class UrlsSection : ConfigurationSection
{

    // Declare the UrlsCollection collection property.
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

        set
        {
            UrlsCollection urlsCollection = value;
        }
    
    }

    // Create a new instance of the UrlsSection.
    // This constructor creates a configuration element 
    // using the UrlConfigElement default values.
    // It assigns this element to the collection.
    public UrlsSection()
    {
        UrlConfigElement url = new UrlConfigElement();
        Urls.Add(url);

    }

}

// Define the UrlsCollection that contains the 
// UrlsConfigElement elements.
// This class shows how to use the ConfigurationElementCollection.
public class UrlsCollection : ConfigurationElementCollection
{
    
    
    public UrlsCollection()
    {
       
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

        // Your custom code goes here.
       
    }

    protected override void BaseAdd(ConfigurationElement element)
    {
        BaseAdd(element, false);

        // Your custom code goes here.
      
    }
    
    public void Remove(UrlConfigElement url)
    {
        if (BaseIndexOf(url) >= 0)
        {
            BaseRemove(url.Name);
            // Your custom code goes here.
            Console.WriteLine("UrlsCollection: {0}", "Removed collection element!");
        }
    }
    
    public void RemoveAt(int index)
    {
        BaseRemoveAt(index);

        // Your custom code goes here.
      
    }
    
    public void Remove(string name)
    {
        BaseRemove(name);

        // Your custom code goes here.
      
    }
    
    public void Clear()
    {
        BaseClear();

        // Your custom code goes here.
        Console.WriteLine("UrlsCollection: {0}", "Removed entire collection!");
    }

}

// Define the UrlsConfigElement elements that are contained 
// by the UrlsCollection.
public class UrlConfigElement : ConfigurationElement
{
    public UrlConfigElement(String name, String url, int port)
    {
        this.Name = name;
        this.Url = url;
        this.Port = port;
    }

    public UrlConfigElement()
    {

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
    
    [ConfigurationProperty("port", DefaultValue = (int)4040, IsRequired = false)]
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