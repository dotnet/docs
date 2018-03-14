<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    // <Snippet1>
    protected void Page_Load(object sender, EventArgs e)
    {
        String adName = Request.QueryString["ad"];
        String redirect = Request.QueryString["target"];
        if (adName == null | redirect == null)
            redirect = "TestAds.aspx";
        
        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        String docPath = @"~/App_Data/AdResponses.xml";
        doc.Load(Server.MapPath(docPath));
        System.Xml.XmlNode root = doc.DocumentElement;
        System.Xml.XmlNode adNode =
            root.SelectSingleNode(
            @"descendant::ad[@adname='" + adName + "']");
        if (adNode != null)
        {
            int ctr =
                int.Parse(adNode.Attributes["hitCount"].Value);
            ctr += 1;
            System.Xml.XmlNode newAdNode = adNode.CloneNode(false);
            newAdNode.Attributes["hitCount"].Value = ctr.ToString();
            root.ReplaceChild(newAdNode, adNode);
            doc.Save(Server.MapPath(docPath));
        }
        Response.Redirect(redirect);
    }
    // </Snippet1>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
