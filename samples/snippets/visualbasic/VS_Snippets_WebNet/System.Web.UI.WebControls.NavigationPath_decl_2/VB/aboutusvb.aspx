<!-- <Snippet1> -->
<%@ Page language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>About Us</title>
</head>
<body>
    <form id="Form1" method="post" runat="server">
      <asp:SiteMapPath
          runat="server"
          ID="SiteMapPath1"
          RootNodeStyle-Font-Names="Verdana"
          RootNodeStyle-Font-Italic="True"
          RootNodeStyle-ForeColor="Blue"
          CurrentNodeStyle-ForeColor="Red">
          <PATHSEPARATORTEMPLATE>
              <asp:Image id="Image1" runat="server" 
                GenerateEmptyAlternateText="true" 
                ImageUrl="6.jpg"></asp:Image>
          </PATHSEPARATORTEMPLATE>
        </asp:SiteMapPath>
        <h1>About Us</h1>
      <p>This company was founded in 1899, as the demand for widgets grew.</p>
    </form>
  </body>
</html>
<!-- </Snippet1> -->