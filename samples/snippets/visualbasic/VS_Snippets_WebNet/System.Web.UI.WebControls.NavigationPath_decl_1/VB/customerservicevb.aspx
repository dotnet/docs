<!-- <Snippet1> -->
<%@ Page language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="Form1" method="post" runat="server">

      <p><asp:SiteMapPath runat="server" ID="SiteMapPath1"
            RootNodeStyle-Font-Bold="true"
            RootNodeStyle-Font-Names="Arial Black"
            RootNodeStyle-Font-Italic="True"
            RootNodeStyle-ForeColor="Green"
            CurrentNodeStyle-ForeColor="Orange"/></p>

      <p><asp:Label
            id="Label1"
            runat="server"
            Width="441px"
            AssociatedControlID="TextBox1"
            Height="64px">Enter your customer service issue in the space
                          provided below, and we will get back to you as
                          soon as possible.</asp:Label></p>

      <p><asp:TextBox id="TextBox1" runat="server"
          Width="448px" Height="96px"></asp:TextBox></p>

      <p><asp:Button id="Button1" runat="server"
          Width="112px" Text="Submit"></asp:Button></p>
    </form>
  </body>
</html>
<!-- </Snippet1> -->