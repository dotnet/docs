using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// <Snippet25>
using System.Configuration;
using System.Web.Configuration;
using System.Text;
// </Snippet25>

public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
 
        // <Snippet22>
        if (Session["Heading"] != null)
        {
            HeadingLabel.Text = HeadingLabel.Text.Replace(
                "Machine.config", Session["Heading"].ToString());
        }

        string virtualPath = "";
        string site = "";
        string locationSubPath = "";
        string server = "";

        if (Session["Path"] != null)
        {
            virtualPath = Session["Path"].ToString();
        }

        if (Session["Site"] != null)
        {
            site = Session["Site"].ToString();
        }

        if (Session["SubPath"] != null)
        {
            locationSubPath = Session["SubPath"].ToString();
        }

        if (Session["Server"] != null)
        {
            site = Session["Server"].ToString();
        }
        // </Snippet22>

        // <Snippet23>
        Configuration config =
            WebConfigurationManager.OpenWebConfiguration
            (virtualPath, site, locationSubPath, server);

        StringBuilder listString = new StringBuilder("<ul>");
        foreach (ConfigurationSectionGroup sectionGroup
            in config.SectionGroups)
        {
            AddSectionGroupInfo(sectionGroup, listString);
        }
        listString.Append("</ul>");

        SectionGroupsLiteral.Text = listString.ToString();

        // </Snippet23>
    }

    // <Snippet24>
    public void AddSectionGroupInfo(
        ConfigurationSectionGroup sectionGroup, StringBuilder listString)
    {
        listString.Append(
            "<li><a href='SectionGroup.aspx?SectionGroup=" +
            sectionGroup.SectionGroupName + "'>" +
            sectionGroup.Name + "</a></li>");

        listString.Append("<ul>");
        if (OptionsCheckBoxList.Items[0].Selected)
        {
            foreach (ConfigurationSection section
                in sectionGroup.Sections)
            {
                listString.Append(
                    "<li>" + section.SectionInformation.Name + "</li>");
            }
        }
        if (OptionsCheckBoxList.Items[1].Selected)
        {
            foreach (ConfigurationSectionGroup s
                in sectionGroup.SectionGroups)
            {
                AddSectionGroupInfo(s, listString);
            }
        }
        listString.Append("</ul>");
    }
    // </Snippet24>
}
