<!-- <Snippet1> -->
<%@ page language="C#"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue == "TextOnLeft") 
        {
            PasswordRecovery1.TextLayout = LoginTextLayout.TextOnLeft;
        }
        if (DropDownList1.SelectedValue == "TextOnTop")
        {
            PasswordRecovery1.TextLayout = LoginTextLayout.TextOnTop;
        }
    }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">
            <table border="1">
                <tr>
                    <td> Choose text layout: 
                        <asp:dropdownlist id="DropDownList1" runat="server"
                            autopostback="true" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                            <asp:listitem value="TextOnLeft">Left</asp:listitem>
                            <asp:listitem value="TextOnTop">Top</asp:listitem>
                        </asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:passwordrecovery id="PasswordRecovery1" runat="server" 
                            textlayout="TextOnLeft">
                        </asp:passwordrecovery>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</html>
<!-- </Snippet1> -->
