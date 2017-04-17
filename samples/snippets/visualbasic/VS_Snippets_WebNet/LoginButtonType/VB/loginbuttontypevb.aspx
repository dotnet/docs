<!-- <Snippet1> -->
<%@ Page Language="VB" AutoEventWireup="false"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    
  Sub changeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    If (ChooseButtonType.SelectedValue = "Button") Then
      
      Login1.LoginButtonType = System.Web.UI.WebControls.ButtonType.Button
      
    End If
    
    If (ChooseButtonType.SelectedValue = "Image") Then
      
      Login1.LoginButtonType = System.Web.UI.WebControls.ButtonType.Image
      
    End If
    If (ChooseButtonType.SelectedValue = "Link") Then
      
      Login1.LoginButtonType = System.Web.UI.WebControls.ButtonType.Link
      
    End If
    
    Login1.LoginButtonText = Server.HtmlEncode(buttonText.Text)
    
  End Sub
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
     <form id="Form1" runat="server">
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
