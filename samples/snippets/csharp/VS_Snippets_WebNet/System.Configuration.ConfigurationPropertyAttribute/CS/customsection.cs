//<Snippet1>
using System;
using System.Configuration;


// Define a custom section.
// This class shows how to use the ConfigurationPropertyAttribute.
public class UrlsSection : ConfigurationSection
{
    //<Snippet2>
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
    //</Snippet2>

    //<Snippet3>
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
    //</Snippet3>

    //<Snippet4> 
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
    //</Snippet4>
}
//</Snippet1>
