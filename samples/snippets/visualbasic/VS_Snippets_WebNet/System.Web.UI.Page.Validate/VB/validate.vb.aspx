<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
' <snippet1>
    Sub Page_Load
        If Not IsPostBack
            ' Validate initially to force the asterisks
            ' to appear before the first roundtrip.
            Validate()
        End If
    End Sub
' </snippet1>
' <snippet2>
    Sub ValidateBtn_Click(sender As Object, e As EventArgs)
        Page.Validate()
        If (Page.IsValid) Then
            lblOutput.Text = "Page is Valid!"
        Else
            lblOutput.Text = "Some required fields are empty."
        End If
    End Sub
' </snippet2>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

  <h3>Client-Side RequiredFieldValidator Sample</h3>

  <table style="background-color: #eeeeee; padding: 10; 
    font-family:Verdana">
    <tr valign="top">
      <td colspan="3">
        <asp:Label ID="lblOutput" ForeColor="red" 
            Text="Fill in the required fields below" 
            Font-Names="Verdana" Font-Size="10" 
            Runat="server" /><br />
      </td>
    </tr>
    <tr>
      <td colspan="3" style="font-size:large; font-weight:bold">
         Credit Card Information
      </td>
    </tr>
    <tr>
      <td align="right" style="font-size:large">
        Card Type:
      </td>
      <td>
        <asp:RadioButtonList id="RadioButtonList1" 
            RepeatLayout="Flow" runat="server">
            <asp:ListItem>MasterCard</asp:ListItem>
            <asp:ListItem>Visa</asp:ListItem>
        </asp:RadioButtonList>
      </td>
      <td align="center" rowspan="1">
        <asp:RequiredFieldValidator 
            id="RequiredFieldValidator1" runat="server"
            ControlToValidate="RadioButtonList1"
            ErrorMessage="*"
            Display="Static"
            InitialValue=""
            Width="100%" />
      </td>
    </tr>
    <tr>
      <td align="right" style="font-size:large">
        Card Number:
      </td>
      <td>
        <asp:TextBox id="TextBox1" runat="server" />
      </td>
      <td>
        <asp:RequiredFieldValidator id="RequiredFieldValidator2" 
          runat="server"
          ControlToValidate="TextBox1"
          ErrorMessage="*"
          Display="Static"
          Width="100%" />

      </td>
    </tr>
    <tr>
      <td align="right" style="font-size:large">
        Expiration Date:
      </td>
      <td>
        <asp:DropDownList id="DropDownList1" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem >06/00</asp:ListItem>
            <asp:ListItem >07/00</asp:ListItem>
            <asp:ListItem >08/00</asp:ListItem>
            <asp:ListItem >09/00</asp:ListItem>
            <asp:ListItem >10/00</asp:ListItem>
            <asp:ListItem >11/00</asp:ListItem>
            <asp:ListItem >01/01</asp:ListItem>
            <asp:ListItem >02/01</asp:ListItem>
            <asp:ListItem >03/01</asp:ListItem>
            <asp:ListItem >04/01</asp:ListItem>
            <asp:ListItem >05/01</asp:ListItem>
            <asp:ListItem >06/01</asp:ListItem>
            <asp:ListItem >07/01</asp:ListItem>
            <asp:ListItem >08/01</asp:ListItem>
            <asp:ListItem >09/01</asp:ListItem>
            <asp:ListItem >10/01</asp:ListItem>
            <asp:ListItem >11/01</asp:ListItem>
            <asp:ListItem >12/01</asp:ListItem>
        </asp:DropDownList>
      </td>
      <td>
        <asp:RequiredFieldValidator 
          id="RequiredFieldValidator3" runat="server"
          ControlToValidate="DropDownList1"
          ErrorMessage="*"
          Display="Static"
          InitialValue=""
          Width="100%" />
      </td>
      <td />
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td>
        <asp:Button id="Button1" text="Validate" 
          OnClick="ValidateBtn_Click" runat="server" />
      </td>
      <td></td>
    </tr>
    </table>

    </div>
    </form>

</body>
</html>
