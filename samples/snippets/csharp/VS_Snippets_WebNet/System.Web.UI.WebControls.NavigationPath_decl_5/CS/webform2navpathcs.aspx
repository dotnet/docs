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

            <!-- The following example demonstrates some of the orders
                 of precedence when applying styles and templates to
                 functional nodes of a SiteMapPath.

                 The NodeStyle and RootNodeStyle define the same attributes,
                 but are different and conflict with each other: the
                 RootNodeStyle supersedes NodeStyle, and is the style
                 rendered. Notice, however, that the underline style
                 defined by NodeStyle is still applied.

                 Both a CurrentNodeStyle and a CurrentNodeTemplate are
                 defined. A template supersedes a style for a node
                 type, so CurrentNodeTemplate is displayed and CurrentNodeStyle
                 is ignored. -->

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
                <CURRENTNODETEMPLATE>
                        <asp:Image id="Image1" runat="server" ImageUrl="WebForm2.jpg" AlternateText="WebForm2"/>
                </CURRENTNODETEMPLATE>
            </asp:SiteMapPath>


        </form>
    </body>
</html>
<!-- </Snippet1> -->