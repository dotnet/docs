using System;
using System.Xml;

public partial class WebForm1 : System.Web.UI.Page
{
    // <violation>
    protected void Page_Load(object sender, EventArgs e)
    {
        XmlDocument d = new XmlDocument();
        XmlElement root = d.CreateElement("root");
        d.AppendChild(root);

        XmlElement allowedUser = d.CreateElement("allowedUser");
        root.AppendChild(allowedUser);
        allowedUser.InnerXml = "alice";

        string input = Request.Form["in"];
        root.InnerXml = input;

        // If an attacker uses this for input:
        //     some text<allowedUser>oscar</allowedUser>
        // Then the XML document will be:
        //     <root>some text<allowedUser>oscar</allowedUser></root>
    }
    // </violation>
}

public partial class WebForm2 : System.Web.UI.Page
{
    // <fix>
    protected void Page_Load(object sender, EventArgs e)
    {
        XmlDocument d = new XmlDocument();
        XmlElement root = d.CreateElement("root");
        d.AppendChild(root);

        XmlElement allowedUser = d.CreateElement("allowedUser");
        root.AppendChild(allowedUser);
        allowedUser.InnerText = "alice";

        string input = Request.Form["in"];
        root.InnerText = input;

        // If an attacker uses this for input:
        //     some text<allowedUser>oscar</allowedUser>
        // Then the XML document will be:
        //     <root>&lt;allowedUser&gt;oscar&lt;/allowedUser&gt;some text<allowedUser>alice</allowedUser></root>
    }
    // </fix>
}
