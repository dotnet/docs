<!-- <Snippet1> -->
<%@ page language="VB"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

        If Not Session("CreateUserReferrerUrl") Is Nothing Then
            Session("CreateUserReferrerUrl") = Request.UrlReferrer.ToString()
        End If
        CreateUserWizard1.ContinueDestinationPageUrl = _
            CStr(Session("CreateUserReferrerUrl"))
    End Sub
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
