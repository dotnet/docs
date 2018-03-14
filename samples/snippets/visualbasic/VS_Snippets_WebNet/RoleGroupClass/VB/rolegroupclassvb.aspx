<!-- <Snippet1> -->
<%@ Page Language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    Private Class CustomTemplate
        Implements ITemplate

        Public Sub InstantiateIn(ByVal container As System.Web.UI.Control) _
            Implements System.Web.UI.ITemplate.InstantiateIn
            Dim ln As New LoginName
            Dim ls As New LoginStatus
            Dim lc As New Literal

            lc.Text = "<br />"
            ln.FormatString = "Welcome, {0}. This line is from the template."

            container.Controls.Add(ln)
            container.Controls.Add(lc)
            container.Controls.Add(ls)

        End Sub
    End Class

    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

        ' <Snippet2>
        Dim rg As New RoleGroup
        rg.ContentTemplate = New CustomTemplate
        ' <Snippet3>        
        Dim RoleList(1) As String
        RoleList(0) = "users"
        ' </Snippet3>

        rg.Roles = RoleList

        Dim rgc As RoleGroupCollection = LoginView1.RoleGroups
        rgc.Add(rg)
        ' </Snippet2>
    End Sub
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
