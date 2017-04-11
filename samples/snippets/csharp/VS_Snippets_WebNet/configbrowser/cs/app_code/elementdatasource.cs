// <Snippet80>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Configuration;
using System.ComponentModel;
using System.Reflection;
using System.Collections;

/// <summary>
/// Retrieves a list of properties for an element or for each
/// item in an element collection. 
/// </summary>
public class ElementDataSource
{
    public ElementDataSource()
    {
    }

    public List<ElementItemHeaderInfo> GetElements(
        string sectionName, 
        string elementName,
        string virtualPath,
        string site,
        string locationSubPath,
        string server)
    {
        List<ElementItemHeaderInfo> elementList = 
            new List<ElementItemHeaderInfo>();

        Configuration config = 
            WebConfigurationManager.OpenWebConfiguration(
                virtualPath, site, locationSubPath, server);

        ConfigurationSection cs = config.GetSection(sectionName);

        Type sectionType = cs.GetType();
        System.Reflection.PropertyInfo reflectionElement = 
            sectionType.GetProperty(elementName);
        Object elementObject = reflectionElement.GetValue(cs, null);

        Type elementType = elementObject.GetType();
        System.Reflection.PropertyInfo reflectionProperty = 
            elementType.GetProperty("Count");

        if (reflectionProperty != null)
        {
            int elementCount = 
                Convert.ToInt32(reflectionProperty.GetValue(
                    elementObject, null));
            for (int i = 0; i < elementCount; i++)
            {
                ElementItemHeaderInfo ei = new ElementItemHeaderInfo();
                ei.ItemName = String.Format(
                    "Item {0} of {1}", i + 1, elementCount);
                ei.Index = i;
                ei.Name = elementName;
                ei.SectionName = sectionName;
                elementList.Add(ei);
            }
        }
        else
        {
            ElementItemHeaderInfo ei = new ElementItemHeaderInfo();
            ei.Name = elementName;
            ei.ItemName = "Item 1 of 1";
            ei.SectionName = sectionName;
            elementList.Add(ei);
        }
        return elementList;
    }

    public List<ElementItemInfo> GetProperties(
        string sectionName, 
        string elementName, 
        int index,
        string virtualPath,
        string site,
        string locationSubPath,
        string server)
    {
        List<ElementItemInfo> elementItemList = 
            new List<ElementItemInfo>();

        Configuration config =
            WebConfigurationManager.OpenWebConfiguration(
                virtualPath, site, locationSubPath, server);

        ConfigurationSection cs = config.GetSection(sectionName);

        Type sectionType = cs.GetType();
        System.Reflection.PropertyInfo reflectionElement = 
            sectionType.GetProperty(elementName);
        Object elementObject = reflectionElement.GetValue(cs, null);

        Type elementType = elementObject.GetType();
        System.Reflection.PropertyInfo reflectionProperty = 
            elementType.GetProperty("Count");

        int elementCount = reflectionProperty == null ? 0 : 
            Convert.ToInt32(
                reflectionProperty.GetValue(elementObject, null));

        if (elementCount > 0)
        {
            int i = 0;
            ConfigurationElementCollection elementItems = 
                elementObject as ConfigurationElementCollection;
            foreach (ConfigurationElement elementItem in elementItems)
            {
                if (i == index)
                {
                    elementObject = elementItem;
                }
                i++;
            }
        }

        Type reflectionItemType = elementObject.GetType();
        PropertyInfo[] elementProperties = 
            reflectionItemType.GetProperties();

        foreach (System.Reflection.PropertyInfo rpi in elementProperties)
        {
            if (rpi.Name != "SectionInformation" && 
                rpi.Name != "LockAttributes" && 
                rpi.Name != "LockAllAttributesExcept" && 
                rpi.Name != "LockElements" && 
                rpi.Name != "LockAllElementsExcept" && 
                rpi.Name != "LockItem" &&
                rpi.Name != "Item" &&
                rpi.Name != "ElementInformation" && 
                rpi.Name != "CurrentConfiguration")
            {
                ElementItemInfo eii = new ElementItemInfo();
                eii.Name = rpi.Name;
                eii.TypeName = rpi.PropertyType.ToString();
                string uniqueID = 
                    rpi.Name + index.ToString();
                eii.UniqueID = uniqueID.Replace("/","");
                ParameterInfo[] indexParms = rpi.GetIndexParameters();
                if (rpi.PropertyType == typeof(IList) || 
                    rpi.PropertyType == typeof(ICollection) || 
                    indexParms.Length > 0)
                {
                    eii.Value = "List";
                }
                else
                {
                    object propertyValue = 
                        rpi.GetValue(elementObject, null);
                    eii.Value = propertyValue == null ? "" : 
                        propertyValue.ToString();
                }
                elementItemList.Add(eii);
            }
        }
        return elementItemList;
    }
}

public class ElementItemHeaderInfo
{
    public string Name { get; set; }
    public string ItemName { get; set; }
    public string SectionName { get; set; }
    public string Value { get; set; }
    public int Index { get; set; }
}

public class ElementItemInfo
{
    public string Name { get; set; }
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
    public string UniqueID { get; set; }
}
// </Snippet80>
