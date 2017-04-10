<!-- <Snippet1> -->
<%@ page language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub CreateUserWizard1_CreatedUser(ByVal sender As Object, ByVal e As System.EventArgs)
    Profile.SetPropertyValue("userName", firstName.Text & " " & lastName.Text)
  End Sub
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>
      CreateUserWizard.CreatedUser sample</title>
  </head>
  <body>
    <form id="form1" runat="server">
      <div>
        <asp:createuserwizard id="CreateUserWizard1"
                              oncreateduser="CreateUserWizard1_CreatedUser"
                              runat="server">
          <wizardsteps>
            <asp:wizardstep runat="server" steptype="Start" title="Identification">
              Tell us your name:<br />
              <table width="100%">
                <tr>
                  <td>
                    First name:</td>
                  <td>
                    <asp:textbox id="firstName" runat="server" /></td>
                </tr>
                <tr>
                  <td>
                    Last name:</td>
                  <td>
                    <asp:textbox id="lastName" runat="server" /></td>
                </tr>
              </table>
            </asp:wizardstep>
            <asp:createuserwizardstep runat="server" title="Sign Up for Your New Account">
            </asp:createuserwizardstep>
          </wizardsteps>
        </asp:createuserwizard>
      </div>
    </form>
  </body>
</html>
<!-- </Snippet1> -->
