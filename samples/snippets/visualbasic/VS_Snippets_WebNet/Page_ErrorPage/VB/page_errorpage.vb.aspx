<%--
    The following program demonstrates the 'ErrorPage' property of 'Page' class.
    
    The program displays a button which will raise an error if the button gets clicked.
    When an unhandled error is raised the browser redirects to the specified URL in 
    the 'ErrorPage' property of 'Page' class.
--%>
<%@ Page ErrorPage="Error_Page.aspx" debug="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="VB" runat="server">
   Sub RaiseError(Sender As Object, e As EventArgs) 
   
      throw new Exception("Unhandled exception")
 End Sub
   
' <Snippet1>    
   Sub Page_Load(Sender As Object, e As EventArgs)
   
      ' Note: This property can also be set in <%@ Page ...> tag.
      If (Not IsPostBack) Then
         Me.ErrorPage = "Error_Page.aspx"
    End If
   End Sub
' </Snippet1>    
   </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>
          Page Example
        </title>
</head>
  <body>
     <form method="post" runat="server" id="myForm">
        <h4>
          Page Example
        </h4>
        Click following button to raise an error.
        <br />
        <asp:Button OnClick="RaiseError" Text="Raise Error" Runat="server" />
     </form>
  </body>
</html>
