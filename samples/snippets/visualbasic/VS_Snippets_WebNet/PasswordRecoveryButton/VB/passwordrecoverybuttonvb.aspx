<!-- <Snippet1> -->
<%@ page language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
    If DropDownList1.SelectedValue = "Button" Then
      PasswordRecovery1.SubmitButtonType = ButtonType.Button
      ' <Snippet4>
      PasswordRecovery1.SubmitButtonText = "Enter User Name"
      ' </Snippet4>
    End If
    If DropDownList1.SelectedValue = "Image" Then
      PasswordRecovery1.SubmitButtonType = ButtonType.Image
      ' <Snippet3> -->
      PasswordRecovery1.SubmitButtonImageUrl = "userNameSubmit.png"
      ' </Snippet3> -->
      PasswordRecovery1.SubmitButtonText = "Enter User Name Image"
    End If
    If DropDownList1.SelectedValue = "Link" Then
      PasswordRecovery1.SubmitButtonType = ButtonType.Link
      PasswordRecovery1.SubmitButtonText = "Enter User Name"
    End If
  End Sub
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>ASP.NET Example</title>
</head>
  <body>
    <form id="Form1" runat="server">
      <table border="1">
        <tbody>
          <tr>
            <td>
<!-- <Snippet2> -->
              <asp:passwordrecovery id="PasswordRecovery1" runat="server"
                submitbuttonimageurl="userNameSubmit.png"
                submitbuttontext="Enter User Name">
                <submitbuttonstyle font-names="Comic Sans MS" 
                  forecolor="White" 
                  backcolor="#00C000">
                </submitbuttonstyle>
              </asp:passwordrecovery>
<!-- </Snippet2> -->              
            </td>
            <td align="center">
              Choose a button type:<br />
              <asp:dropdownlist id="DropDownList1" runat="server" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged"
                autopostback="true">
                <asp:listitem value="Button">Button</asp:listitem>
                <asp:listitem value="Image">Image</asp:listitem>
                <asp:listitem value="Link">Link</asp:listitem>
              </asp:dropdownlist>
            </td>
          </tr>
        </tbody>
      </table>
    </form>
  </body>
</html>
<!-- </Snippet1> -->

