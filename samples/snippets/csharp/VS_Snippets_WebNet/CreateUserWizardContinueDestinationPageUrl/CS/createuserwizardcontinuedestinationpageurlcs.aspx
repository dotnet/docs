<!-- <Snippet1> -->
<%@ page language="C#"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    void Page_Load(object sender, EventArgs e)
    {
        if (!(Session["CreateUserReferrerUrl"] is String))
        {
            Session["CreateUserReferrerUrl"] = Request.UrlReferrer.ToString ();
        }

        CreateUserWizard1.ContinueDestinationPageUrl =
            (string)Session["CreateUserReferrerUrl"];
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:createuserwizard id="CreateUserWizard1" runat="server">
        </asp:createuserwizard>
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
