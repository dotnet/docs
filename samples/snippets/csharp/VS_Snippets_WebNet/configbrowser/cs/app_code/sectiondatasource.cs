// <Snippet50>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Configuration;
using System.ComponentModel;
using System.Collections;
using System.Reflection;

/// <summary>
/// Retrieves a list of elements in a section. 
/// </summary>
public class SectionDataSource
{
    public SectionDataSource()
    {
    }
    public List<ElementInfo> GetProperties(
        string sectionName,
        string virtualPath,
        string site,
        string locationSubPath,
        string server)
    {
        List<ElementInfo> sectionList = new List<ElementInfo>();

        Configuration config =
            WebConfigurationManager.OpenWebConfiguration(
                virtualPath, site, locationSubPath, server);

        ConfigurationSection cs = config.GetSection(sectionName);
        Type sectionType = cs.GetType();
        PropertyInfo[] sectionProperties = sectionType.GetProperties();

        foreach (PropertyInfo rpi in sectionProperties)
        {
            if (rpi.Name != "SectionInformation" &&
                rpi.Name != "LockAttributes" &&
                rpi.Name != "LockAllAttributesExcept" &&
                rpi.Name != "LockElements" &&
                rpi.Name != "LockAllElementsExcept" &&
                rpi.Name != "LockItem" &&
                rpi.Name != "ElementInformation" &&
                rpi.Name != "CurrentConfiguration")
            {
                ElementInfo ei = new ElementInfo();
                ei.Name = rpi.Name;
                ei.TypeName = rpi.PropertyType.ToString();

                if (rpi.PropertyType.BaseType == 
                    typeof(ConfigurationElement))
                {
                    ei.NameUrl = "Element.aspx?Section=" + 
                        sectionName + "&Element=" + rpi.Name;
                    ei.Value = "Element";
                }
                else if (rpi.PropertyType.BaseType == 
                    typeof(ConfigurationElementCollection))
                {
                    ei.NameUrl = "Element.aspx?Section=" + 
                        sectionName + "&Element=" + rpi.Name;
                    ei.Value = "Element Collection";
                }
                else
                {
                    ParameterInfo[] indexParms = rpi.GetIndexParameters();
                    if (rpi.PropertyType == typeof(IList) || 
                        rpi.PropertyType == typeof(ICollection) || 
                        indexParms.Length > 0)
                    {
                        ei.Value = "Collection";
                    }
                    else
                    {
                        object propertyValue = rpi.GetValue(cs, null);
                        ei.Value = propertyValue == null ? "" : 
                            propertyValue.ToString();
                    }
                }
                sectionList.Add(ei);
            }
        }
        return sectionList;
    }
}

public class ElementInfo
{
    public string Name { get; set; }
    public string ItemName { get; set; }
    public string SectionName { get; set; }
    public string NameUrl { get; set; }
    public string TypeName { get; set; }
    public string TypeNameUrl
    {
        get
        {
            return "http://msdn.microsoft.com/en-us/library/" + 
                TypeName + ".aspx";
        }
    }
    public string Value { get; set; }
    public int Index { get; set; }
}
// </Snippet50>