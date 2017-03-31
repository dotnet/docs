<!-- <Snippet1> -->
<%@ Page Language="C#" AutoEventWireup="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    void changeButton_Click(Object sender, EventArgs e) 
    {
      if (ChooseButtonType.SelectedValue == "Button")
      {
        Login1.LoginButtonType = ButtonType.Button;
      }
      if (ChooseButtonType.SelectedValue == "Image")
      {
        Login1.LoginButtonType = ButtonType.Image;
      }
      if (ChooseButtonType.SelectedValue == "Link")
      {
        Login1.LoginButtonType = ButtonType.Link;
      }
      
      Login1.LoginButtonText = Server.HtmlEncode(buttonText.Text);
    }

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
     <form id="form1" runat="server">
       <table>
           <tr>
             <td>Login Button Text:
             </td>
             <td>
               <asp:TextBox id="buttonText" 
                            runat="server"
                            Text="Login"></asp:TextBox>
             </td>
             <td>Button Type:
             </td>
             <td>
               <asp:DropDownList id="ChooseButtonType" 
                                 runat="server">
                 <asp:ListItem value="Button"
                               selected="true"></asp:ListItem>
                 <asp:ListItem value="Image"></asp:ListItem>
                 <asp:ListItem value="Link"></asp:ListItem>
               </asp:DropDownList>
             </td>
             <td>
                        <asp:Button id="changeButton" runat="server" Text="Change" OnClick="changeButton_Click"></asp:Button>
             </td>
           </tr>
           <tr>
             <td colspan="4" 
                 align="center">
             <asp:Login id="Login1" 
                        runat="server" 
                        LoginButtonType="Image" 
                        LoginButtonText="Log in to Web Site."
                        LoginButtonImageUrl="images\login.png">
             </asp:Login>
             </td>
           </tr>
        </table>
     </form>
  </body>
</html>
<!-- </Snippet1> -->
