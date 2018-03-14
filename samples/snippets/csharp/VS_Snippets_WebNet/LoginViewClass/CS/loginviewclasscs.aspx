<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">
            <p>
                <asp:LoginStatus id="LoginStatus1" runat="server"></asp:LoginStatus></p>
            <p>
                <asp:LoginView id="LoginView1" runat="server">
                    <AnonymousTemplate>
                        Please log in for personalized information.
                    </AnonymousTemplate>
                    <LoggedInTemplate>
                        Thanks for logging in 
                        <asp:LoginName id="LoginName1" runat="Server"></asp:LoginName>.
                    </LoggedInTemplate>
                    <RoleGroups>
                        <asp:RoleGroup Roles="Admin">
                            <ContentTemplate>
                                <asp:LoginName id="LoginName2" runat="Server"></asp:LoginName>, you
                                are logged in as an administrator.
                            </ContentTemplate>
                        </asp:RoleGroup>
                    </RoleGroups>
                </asp:LoginView></p>
        </form>
    </body>
</html>
<!-- </Snippet1> -->
