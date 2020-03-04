<!-- <Snippet1> -->
<%@ Page Language="C#"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    private class CustomTemplate : ITemplate
    {
        public void InstantiateIn(System.Web.UI.Control container)
        {
            LoginName ln = new LoginName();
            LoginStatus ls = new LoginStatus();
            Literal lc = new Literal();
        
            lc.Text = "<br />";
            ln.FormatString = "Welcome, {0}. This line is from the template.";
        
            container.Controls.Add(ln);
            container.Controls.Add(lc);
            container.Controls.Add(ls);
        }
    }
        
    void Page_Load(Object sender, EventArgs e)
    {
        // <Snippet2>
        RoleGroup rg = new RoleGroup();
        rg.ContentTemplate = new CustomTemplate();
        // <Snippet3>
        String[] RoleList = {"users"};
        rg.Roles = RoleList;
        // </Snippet3>
        RoleGroupCollection rgc = LoginView1.RoleGroups;
        rgc.Add(rg);
        // </Snippet2>
    }

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">
            <asp:LoginView id="LoginView1" runat="server">
                <AnonymousTemplate>
                    You are not logged in.<br />
                    <asp:LoginStatus id="LoginStatus1" runat="server"></asp:LoginStatus>
                </AnonymousTemplate>
                <LoggedInTemplate>
                    You are logged in as
                    <asp:LoginName id="LoginName1" runat="server" />. This message is not from the template.<br />
                    <asp:LoginStatus id="Loginstatus2" runat="server"></asp:LoginStatus>
                </LoggedInTemplate>
            </asp:LoginView>
        </form>
    </body>
</html>
<!-- </Snippet1> -->
