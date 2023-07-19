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
    }
    // </fix>
}
