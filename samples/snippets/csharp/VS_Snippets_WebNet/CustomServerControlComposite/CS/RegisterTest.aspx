<%@ Register TagPrefix="aspSample" 
    Namespace="Samples.AspNet.CS.Controls" 
    Assembly="Samples.AspNet.CS" %>
<!-- <Snippet3> -->
<%@ Page Language="C#"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  void Page_Load(object sender, EventArgs e)
  {
    Label1.Visible = false;
  }
  void Register_Submit(object sender, EventArgs e)
  {
    // The application developer can implement
    // logic here to enter registration data into
    // a database or write a cookie
    // on the user's computer.
    // This example merely writes a message
    // using the Label control on the page.
    Label1.Text = String.Format(
        "Thank you, {0}! You are registered.",Register1.Name);
    Label1.Visible = true;
    Register1.Visible = false;
  }
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>
      Register Control Test Page
    </title>
  </head>
  <body>
    <form id="form1" runat="server">
      <aspSample:Register ButtonText="Register" 
        OnSubmit="Register_Submit" ID="Register1"
        Runat="server" NameLabelText="Name:" 
        EmailLabelText="Email:" 
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
