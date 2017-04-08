<%@ Register TagPrefix="aspSample" 
  Namespace="Samples.AspNet.CS.Controls" 
  Assembly="Samples.AspNet.CS" %>
<!-- <Snippet2> -->
<%@ Page Language="C#"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  void Page_Load(object sender, EventArgs e)
  {
    Label1.Visible = false;
  }
  void StyledRegister_Submit(object sender, EventArgs e)
  {
    Label1.Text = String.Format("Thank you, {0}! You are registered.", 
      StyledRegister1.Name);
    Label1.Visible = true;
    StyledRegister1.Visible = false;
  }
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>
      StyledRegister Control Test Page
    </title>
  </head>
  <body>
    <form id="form1" runat="server">
      <aspSample:StyledRegister ButtonText="Register" 
        OnSubmit="StyledRegister_Submit" ID="StyledRegister1"
        Runat="server" NameLabelText="Name:" EmailLabelText="Email:" 
        EmailErrorMessage="You must enter your e-mail address."
        NameErrorMessage="You must enter your name." 
        BorderStyle="Solid" BorderWidth="1px" BackColor="#E0E0E0">
        <TextBoxStyle Font-Names="Arial" BorderStyle="Solid" 
          ForeColor="#804000"></TextBoxStyle>
        <ButtonStyle Font-Names="Arial" BorderStyle="Outset" 
          BackColor="Silver"></ButtonStyle>
      </aspSample:StyledRegister>
      <br />
      <asp:Label ID="Label1" Runat="server" Text="Label">
      </asp:Label>
      <asp:ValidationSummary ID="ValidationSummary1" 
        Runat="server" DisplayMode="List" />
    </form>
  </body>
</html>
<!-- </Snippet2> -->
