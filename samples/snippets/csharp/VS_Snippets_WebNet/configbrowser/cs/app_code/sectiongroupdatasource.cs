// <Snippet30>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Configuration;

/// <summary>
/// Retrieves a list of sections in a section group. 
/// </summary>
public class SectionGroupDataSource
{
    public SectionGroupDataSource()
    {
    }

    public List<SectionInfo> GetSections(
        string sectionGroupName, 
        string virtualPath, 
        string site, 
        string locationSubPath, 
        string server)
    {
        List<SectionInfo> sectionList = new List<SectionInfo>();

        Configuration config = WebConfigurationManager.OpenWebConfiguration(
            virtualPath, site, locationSubPath, server);

        ConfigurationSectionGroup csg = 
            config.GetSectionGroup(sectionGroupName);

        foreach (ConfigurationSection section in csg.Sections)
        {
            SectionInfo si = new SectionInfo();
            si.Name = section.SectionInformation.Name;
            si.NameUrl = "Section.aspx?Section=" + 
                section.SectionInformation.SectionName;

            int i = section.SectionInformation.Type.IndexOf(",");
            si.TypeName = section.SectionInformation.Type.Substring(0, i);
            sectionList.Add(si);
        }

        foreach (ConfigurationSectionGroup group in csg.SectionGroups)
        {
            SectionInfo si = new SectionInfo();
            si.Name = group.Name;
            si.NameUrl = 
                "SectionGroup.aspx?SectionGroup=" + group.SectionGroupName;
            si.TypeName = 
                "System.Configuration.ConfigurationSectionGroup";
            sectionList.Add(si);
        }
        return sectionList;
    }
}

public class SectionInfo
{
    public string Name { get; set; }
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
}
// </Snippet30>
