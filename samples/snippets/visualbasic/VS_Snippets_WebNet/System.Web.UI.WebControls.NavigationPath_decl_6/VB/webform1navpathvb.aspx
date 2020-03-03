<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="Form1" runat="server">

            <!-- The following example demonstrates some of the orders
                 of precedence when applying styles and templates to
                 functional nodes of a SiteMapPath.

                 A NodeStyle, RootNodeStyle, and CurrentNodeStyle are
                 all defined. However, so is a NodeTemplate. The template
                 is applied to all nodes, and the styles ignored. -->

            <asp:SiteMapPath ID="SiteMapPath1" runat="server"
                RenderCurrentNodeAsLink="true"
                NodeStyle-Font-Names="Franklin Gothic Medium"
                NodeStyle-Font-Underline="true"
                NodeStyle-Font-Bold="true"
                RootNodeStyle-Font-Names="Symbol"
                RootNodeStyle-Font-Bold="false"
                CurrentNodeStyle-Font-Names="Verdana"
                CurrentNodeStyle-Font-Size="10pt"
                CurrentNodeStyle-Font-Bold="true"
                CurrentNodeStyle-ForeColor="red"
                CurrentNodeStyle-Font-Underline="false">
                <NODETEMPLATE>
                        <asp:CheckBox id="CheckBox1" runat="server" Checked="true" />
                        <asp:TextBox id="TextBox1" runat="server" Text="Declarative template" />
                </NODETEMPLATE>
            </asp:SiteMapPath>


        </form>
    </body>
</html>
<!-- </Snippet1> -->