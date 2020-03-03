<!-- <Snippet1> -->
<%@ Page language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <title>Catalog</title>
    </head>
    <body>
        <form id="Form1" method="post" runat="server">
            <p><asp:SiteMapPath runat="server" ID="SiteMapPath1"
                    RootNodeStyle-Font-Bold="true"
                    RootNodeStyle-Font-Names="Arial Black"
                    RootNodeStyle-Font-Italic="True"
                    RootNodeStyle-ForeColor="Green"
                    CurrentNodeStyle-ForeColor="Orange"
                    PathSeparator="<::>"
                    PathDirection="CurrentToRoot"
                    RenderCurrentNodeAsLink="false"
                    ShowToolTips="false"/></p>
        </form>
    </body>
</html>
<!-- </Snippet1> -->