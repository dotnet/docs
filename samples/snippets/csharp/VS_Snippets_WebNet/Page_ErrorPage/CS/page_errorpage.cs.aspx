<%--
    The following program demonstrates the 'ErrorPage' property of 'Page' class.
    
    The program displays a button which will raise an error if the button gets clicked.
    When an unhandled error is raised the browser redirects to the specified URL in 
    the 'ErrorPage' property of 'Page' class.
--%>
<%@ Page ErrorPage="Error_Page.aspx" debug="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="C#" runat="server">
   void RaiseError(Object sender, EventArgs e) 
   {
      throw new Exception("Unhandled exception");
   }
// <Snippet1>
   void Page_Load(Object sender, EventArgs e)
   {
      // Note: This property can also be set in <%@ Page ...> tag.
      if(!IsPostBack)
         this.ErrorPage = "Error_Page.aspx";
   }
// </Snippet1>
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
