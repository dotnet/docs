<%@ Register TagPrefix="aspSample" 
  Namespace="Samples.AspNet.vB.Controls" Assembly="Samples.AspNet.VB" %>
<!-- <Snippet2> -->
<%@ Page Language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Label1.Visible = False
    End Sub
    
    Sub StyledRegister_Submit(ByVal sender As Object, _
        ByVal e As EventArgs)
        Label1.Text = String.Format( _
            "Thank you, {0}! You are registered.", _
            StyledRegister1.Name)
        Label1.Visible = True
        StyledRegister1.Visible = False
    End Sub
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
