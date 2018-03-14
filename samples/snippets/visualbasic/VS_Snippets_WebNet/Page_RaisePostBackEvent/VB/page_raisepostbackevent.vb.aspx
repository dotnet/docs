<%--
    The following program demonstrates the 'RegisterRequiresRaiseEvent' and 
    'RaisePostBackEvent' methods of 'Page' class.
    
    This program displays a textbox and two buttons and registers first button control 
    as one that requires postback handling when    page load event occurs. When a post back
    event of second button is raised, it will raise a post back event of first button which
    display a message and content of textbox.
--%>
<%@ Page language="VB" %>
<%@ import namespace="System.IO" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <script language="VB" runat="server">
' <Snippet1>    
' <Snippet2>    
        Sub DisplayUserName(Sender As Object, e As EventArgs) 
           Response.Write("Welcome to " + Server.HtmlEncode(userName.Text))
        End Sub

       Sub MyRaiseEvent(Sender As Object, e As EventArgs)
           'Raises a post back event for a control.
            Me.RaisePostBackEvent(userButton, "")
       End Sub 
        
        Sub Page_Load(Sender As Object, e As EventArgs)
    
          'Registers a control as one that requires postback handling
          Me.RegisterRequiresRaiseEvent(userButton)
      End Sub
' </Snippet2>    
' </Snippet1>    
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
          <asp:TextBox ID="userName" Runat="server" /><br />
          <asp:Button ID="userButton" Text="Display" OnClick="DisplayUserName" Runat="server" />
              <br /><asp:Button Text="RaisePostBackEvent" OnClick="MyRaiseEvent" Runat="server" />
        <br />
        <asp:Label ID="titleLabel" Runat="server" />
        <br />
        <br />
        <asp:Label ID="fileContentLabel" Runat="server" />
     </form>
  </body>
</html>
