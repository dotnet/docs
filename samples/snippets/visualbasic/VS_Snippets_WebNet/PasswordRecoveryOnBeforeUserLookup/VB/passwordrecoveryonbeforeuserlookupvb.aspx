<!-- <Snippet1> -->
<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    Class CustomPasswordRecovery
        Inherits PasswordRecovery
        
        Overloads Sub OnVerifyingUser(ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs)
            MyBase.OnVerifyingUser(e)
            
        End Sub
        
    End Class

    ' Add the custom password recovery control to the page.
    Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
    
        Dim passwordRecoveryControl As New CustomPasswordRecovery
        
        passwordRecoveryControl.ID = "passwordRecoveryControl"
        
        PlaceHolder1.Controls.Add(passwordRecoveryControl)
        
    End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <p>
        <asp:placeholder id="PlaceHolder1" 
          runat="server">
        </asp:placeholder>
        &nbsp;
      </p>
    </form>
  </body>
</html>
<!-- </Snippet1> -->
