<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    
    // Set the field label background color if the user name is not found.
    void PasswordRecovery1_UserLookupError(object sender, System.EventArgs e)
    {
        PasswordRecovery1.LabelStyle.ForeColor = System.Drawing.Color.Red;
    }
    
    // Reset the field label background color.
    void PasswordRecovery1_Load(object sender, System.EventArgs e)
    {
        PasswordRecovery1.LabelStyle.ForeColor = System.Drawing.Color.Black;
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">
            <asp:PasswordRecovery id="PasswordRecovery1" runat="server" BorderStyle="Solid" BorderWidth="1px" BackColor="#F7F7DE"
                Font-Size="10pt" Font-Names="Verdana" BorderColor="#CCCC99" HelpPageText="Need help?" HelpPageUrl="recoveryHelp.aspx" onuserlookuperror="PasswordRecovery1_UserLookupError" onload="PasswordRecovery1_Load" >
                <successtemplate>
                    <table border="0" style="font-size:10pt;">
                        <tr>
                            <td>Your password has been sent to you.</td>
                        </tr>
                    </table>
                </successtemplate>
                <titletextstyle font-bold="True" forecolor="White" backcolor="#6B696B">
                </titletextstyle>
            </asp:PasswordRecovery>

        </form>
    </body>
</html>
<!-- </Snippet1> -->
