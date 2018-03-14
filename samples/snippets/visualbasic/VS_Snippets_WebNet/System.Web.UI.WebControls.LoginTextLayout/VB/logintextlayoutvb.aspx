<!-- <snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  
  Sub ChangeTextLayout_Click(sender as Object, e as EventArgs)
    
    If Login1.TextLayout = LoginTextLayout.TextOnLeft Then
      
      Login1.TextLayout = LoginTextLayout.TextOnTop
      
    Else
      
      Login1.TextLayout = LoginTextLayout.TextOnLeft
      
    End If
    
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TextLayout Example</title>
</head>
<body>
    <form id="Form1" runat="server">
    <h3>TextLayout Example</h3>
    <table style="text-align:center"
        border="1">
        <tr>
          <td align="center">
            <asp:Login id="Login1" 
              runat="server"
              orientation="Vertical" 
              textlayout="TextOnLeft">
            </asp:Login>
          </td>
        </tr>
        <tr>
          <td align="center">
            <asp:Button id="changeTextLayout" 
              runat="Server" 
              text="Change Text Layout" 
              onclick="ChangeTextLayout_Click" >
            </asp:Button>&nbsp;
          </td>
        </tr>
      </table>
    </form>
  </body>
</html>
<!-- </snippet1> -->
