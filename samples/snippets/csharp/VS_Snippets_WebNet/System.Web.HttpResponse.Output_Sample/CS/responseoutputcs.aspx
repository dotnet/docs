<%--<snippet1>--%>
<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    // When the page is posted back, the text box's 
    // Text property value is HTML encoded and sent
    // sent to the current Response.
    void btnSubmit_Click(object sender, EventArgs e) {

        if (IsPostBack)
        {
            Server.HtmlEncode(txtSubmitString.Text, Response.Output);
        }
    }

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <p style="font-family:Tahoma; font-size:12">
            Enter your comments here:
        </p>
        <p>
            <asp:TextBox id="txtSubmitString" runat="server" Width="181px" TextMode="MultiLine"></asp:TextBox>
        </p>
        <p>
            <asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit"></asp:Button>
        </p>
        <p>
            <asp:Label id="lblEncodedString" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>

<%--</snippet1>--%>

