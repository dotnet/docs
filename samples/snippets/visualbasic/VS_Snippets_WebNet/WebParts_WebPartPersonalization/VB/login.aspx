<!-- <snippet5> -->
<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Login ID="Login1" runat="server" BorderWidth="1px" BorderColor="#E6E2D8" BorderPadding="4"
            BorderStyle="Solid" BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Verdana"
            Font-Size="0.8em" DestinationPageUrl="~/Defaultvb.aspx">
            <InstructionTextStyle ForeColor="Black" Font-Italic="True" Font-Size="0.8em" />
            <LoginButtonStyle Font-Names="Verdana" Font-Size="0.8em" BorderStyle="Solid" BorderWidth="1px"
                BorderColor="#CCCCCC" BackColor="#FFFBFF" ForeColor="#284775" />
            <TextBoxStyle Font-Size="0.8em" />
            <LabelStyle Font-Size="0.8em" />
            <TitleTextStyle ForeColor="White" Font-Size="0.9em" Font-Bold="True" BackColor="#5D7B9D" />
            <HyperLinkStyle Font-Size="0.8em" />
            <CheckBoxStyle Font-Size="0.8em" />
            <FailureTextStyle ForeColor="#FF0000" Font-Size="0.8em" />
        </asp:Login>   
You can create new users with the ASP.NET Web Site Administration Tool in Microsoft Visual Studio 2005. 
See also the web.config file for user authorization examples.
    </div>
    </form>
</body>
</html>
<!-- </snippet5> -->
