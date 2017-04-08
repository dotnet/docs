<%@ Register TagPrefix="aspSample" 
    Namespace="Samples.AspNet.vB.Controls" 
    Assembly="Samples.AspNet.VB" %>
<!-- <Snippet3> -->
<%@ Page Language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Label1.Visible = False
    End Sub
    
    Sub Register_Submit(ByVal sender As Object, ByVal e As EventArgs)
        ' The application developer can implement
        ' logic here to enter registration data into
        ' a database or write a cookie
        ' on the user's computer.
        ' This example merely writes a message
        ' using the Label control on the page.
        Label1.Text = String.Format( _
            "Thank you, {0}! You are registered.", Register1.Name)
        Label1.Visible = True
        Register1.Visible = False
    End Sub
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>
      Register Control Test Page
    </title>
  </head>
  <body>
    <form id="form1" runat="server">
      <aspSample:Register ButtonText="Submit" 
        OnSubmit="Register_Submit" ID="Register1"
        Runat="server" NameLabelText="Name:" EmailLabelText="Email:" 
        EmailErrorMessage="You must enter your e-mail address." 
        NameErrorMessage="You must enter your name." />
       <br />
      <asp:Label ID="Label1" Runat="server" Text="Label">
      </asp:Label>
      <asp:ValidationSummary ID="ValidationSummary1" 
        Runat="server" DisplayMode="List" />
    </form>
  </body>
</html>
<!-- </Snippet3> -->
