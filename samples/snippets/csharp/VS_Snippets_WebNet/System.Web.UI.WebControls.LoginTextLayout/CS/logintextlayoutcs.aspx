<!-- <snippet1> -->
<%@ Page Language="C#" AutoEventWireup="False" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  void ChangeTextLayout_Click(object sender, EventArgs e)
  {
      if (Login1.TextLayout == LoginTextLayout.TextOnLeft)
      {
          Login1.TextLayout = LoginTextLayout.TextOnTop;
      }
      else
      {
          Login1.TextLayout = LoginTextLayout.TextOnLeft;
      }
  }

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