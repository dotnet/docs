<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB" %>
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom CustomValidator - AddAttributesToRender - VB.NET Example</title>
    <script runat="server">
      Sub CustomValidator1_ServerValidate(source As Object, args As ServerValidateEventArgs)
        args.IsValid = False
        Try
          ' Test whether the value entered into the text box is even or not.
          Dim i As Integer = Integer.Parse(args.Value)
          If (i Mod 2) = 0 Then
            args.IsValid = True
          End If
        Catch
        End Try
      End Sub
    </script>
  </head>
<body>
  <form id="Form1" method="post" runat="server">
    <h3>Custom CustomValidator - AddAttributesToRender - VB.NET Example</h3>
    <asp:Label id="Label1" runat="server" Text="Enter an even number:" AssociatedControlID="TextBox1" /><br />
    <asp:TextBox id="TextBox1" runat="server" />&nbsp;
    <aspSample:CustomCustomValidatorAddAttributesToRender id="Customvalidator1" runat="server" ControlToValidate="TextBox1" Display="Static" ErrorMessage="Not an even number!" OnServerValidate="CustomValidator1_ServerValidate" /><br /><br />
    <asp:Button id="Button1" runat="server" Text="Validate" />
  </form>
</body>
</html>
<!-- </Snippet1> -->