<!-- <Snippet1> -->
<%@ Page Language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Sub ChangeClick(ByVal sender As Object, ByVal e As EventArgs)
    
    If Login1.LoginButtonType = ButtonType.Image Then
      Login1.LoginButtonImageUrl = String.Empty
      Login1.LoginButtonType = ButtonType.Button
    Else
      Login1.LoginButtonImageUrl = "images/login.png"
      Login1.LoginButtonType = ButtonType.Image
    End If
    
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
          <td>
            <asp:Login id="Login1" 
                       runat="server" 
                       LoginButtonImageUrl="images/login.png" 
                       LoginButtonText="Submit the login form."
                       LoginButtonType="Image">
            </asp:Login>
          </td>
          <td>
            <asp:Button id="change" 
                        runat="server" 
                        Text="Change Login button." 
                        onClick="ChangeClick">
            </asp:Button>
          </td>
        </tr>
      </table>
    </form>
  </body>
</html>
<!-- </Snippet1> -->
