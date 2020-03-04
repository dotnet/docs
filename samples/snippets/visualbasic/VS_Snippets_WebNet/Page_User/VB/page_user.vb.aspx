<%@ Page Language="VB" Debug="true" %>
<%@ Import Namespace="System.Security.Principal" %>
<%--
    'The following program demonstrates the 'User' property of 'Page' class.    
    'The program prints the user information  which is requesting the page using the 
    'User' property of 'Page' class when a click event of the button is raised.
    
    'Note:Before running this program please change the 'Authentication Method ' of 
    ' IIS to 'Integrated Windows Authentication'.
--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="VB" runat="server">
' <Snippet1>    
Sub UserInfo(sender As Object, e As EventArgs)         
   Dim myPrincipal As IPrincipal = Me.User
   Dim tableString As  String 
        tableString = "<table border=""1""><tr><td>Name</td><td>"
   tableString &= Server.HtmlEncode(myPrincipal.Identity.Name) + "</td></tr><tr><td>"
   tableString &= "AuthenticationType</td><td>" + myPrincipal.Identity.AuthenticationType
   tableString &= "</td></tr><tr><td>IsAuthenticated</td><td>"
   tableString &= myPrincipal.Identity.IsAuthenticated.ToString() + "</td></tr></table>"
   Response.Write(tableString)
End Sub
' </Snippet1>    
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
    <title>
                Page Example:
            </title>
</head>
    <body>
        <form method="post" runat="server" id="myForm">
            <h3>
                Page Example:
            </h3>
            Click the following button to see the information
            <br />
            of the user requesting the page:
            <br />
            <asp:Button OnClick="UserInfo" Text="User Info" Runat="server" ID="Button1" />
        </form>
    </body>
</html>
