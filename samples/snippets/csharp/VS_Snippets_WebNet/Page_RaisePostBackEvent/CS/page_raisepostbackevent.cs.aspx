<%--
    The following program demonstrates the 'RegisterRequiresRaiseEvent' and 
    'RaisePostBackEvent' methods of 'Page' class.
    
    This program displays a textbox and two buttons and register first button control 
    as one that requires postback handling when    page load event occurs. When a post back
    event of second button is raised, it will raise a post back event of first button which
    display a message and content of textbox.
--%>
<%@ Page language="C#" %>
<%@ import namespace="System.IO" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <script language="C#" runat="server">
// <Snippet1>
// <Snippet2>
void DisplayUserName(Object sender, EventArgs ea) 
{
   Response.Write("Welcome to " + Server.HtmlEncode(userName.Text));
}
void RaiseEvent(Object sender, EventArgs ea)
{
   // Raise a post back event for a control.
   this.RaisePostBackEvent(userButton, "");
}
void Page_Load(Object sender, EventArgs ea)
{
   // Register a control as one that requires postback handling.
   this.RegisterRequiresRaiseEvent(userButton);
}
// </Snippet2>
// </Snippet1>
    </script>
  <head runat="server">
    <title>
          Click on 'RaisePostBackEvent' button to raise the post back event of 'Display' 
          button
        </title>
</head>
<body>
     <form id="form1" method="get" runat="server">
        <h4 style="color:Red">
          Click on 'RaisePostBackEvent' button to raise the post back event of 'Display' 
          button
        </h4>
        User name
        <asp:TextBox ID="userName" Runat="server" />
        <br />
        <asp:Button ID="userButton" Text="Display" OnClick="DisplayUserName" Runat="server" />
        <br />
        <asp:Button Text="RaisePostBackEvent" OnClick="RaiseEvent" Runat="server" />
        <br />
        <asp:Label ID="titleLabel" Runat="server" />
        <br />
        <br />
        <asp:Label ID="fileContentLabel" Runat="server" />
     </form>
  </body>
</html>
