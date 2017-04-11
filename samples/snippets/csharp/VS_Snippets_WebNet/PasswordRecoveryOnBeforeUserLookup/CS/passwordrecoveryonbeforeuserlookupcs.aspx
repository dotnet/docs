<!-- <Snippet1> -->
<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    class CustomPasswordRecovery : PasswordRecovery
    {
        override protected void OnVerifyingUser(System.Web.UI.WebControls.LoginCancelEventArgs e)
        {
            base.OnVerifyingUser(e);
        }
    }
    
    // Add the custom password recovery control to the page.
    void Page_Init(object sender, EventArgs e)
    {
        CustomPasswordRecovery passwordRecoveryControl = new CustomPasswordRecovery();
    
        passwordRecoveryControl.ID = "passwordRecoveryControl";
    
        PlaceHolder1.Controls.Add(passwordRecoveryControl);
    
    }
        
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
