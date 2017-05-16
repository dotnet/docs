<%@ Page Language="C#" Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>

<script runat="server">
    //<Snippet1>
    public void Page_Load(Object source, EventArgs e)
    {
        if (Panel1.IsTemplated)
        {
            string txt = "Loaded panel has {0} Templates for a Filter named {1}.";
            Label1.Text = 
                String.Format(txt, 
                    Panel1.DeviceSpecific.Choices[0].Templates.Count, 
                    Panel1.DeviceSpecific.Choices[0].Filter.ToString());
        }
        else
        {
            Label1.Text = "Loaded panel does not have Templates";
        }
    }
    //</Snippet1>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server">
        <mobile:Label ID="Label1" Runat="server" />
        <mobile:Panel ID="Panel1" Runat="server"></mobile:Panel>
    </mobile:form>
</body>
</html>
