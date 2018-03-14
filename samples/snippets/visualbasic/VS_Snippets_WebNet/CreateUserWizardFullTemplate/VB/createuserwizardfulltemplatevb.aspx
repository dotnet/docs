<!-- <Snippet1> -->
<%@ page language="VB"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CreateUserWizard sample</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:createuserwizard id="Createuserwizard1" runat="server">
        <wizardsteps>
          <asp:createuserwizardstep runat="server" title="Sign Up for Your New Account">
            <contenttemplate>
              <table border="0">
                <tr>
                  <td>
                    <table border="0" style="height: 100%; width: 100%;">
                      <tr>
                        <td align="center" colspan="2">
                          Sign Up for Your New Account</td>
                      </tr>
                      <tr>
                        <td align="right">
                          <asp:label runat="server" associatedcontrolid="UserName" id="UserNameLabel">
                            User Name:</asp:label></td>
                        <td>
                          <asp:textbox runat="server" id="UserName"></asp:textbox>
                          <asp:requiredfieldvalidator runat="server" controltovalidate="UserName" tooltip="User Name is required."
                            id="UserNameRequired" validationgroup="Createuserwizard1" errormessage="User Name is required.">
                            *</asp:requiredfieldvalidator>
                        </td>
                      </tr>
                      <tr>
                        <td align="right">
                          <asp:label runat="server" associatedcontrolid="Password" id="PasswordLabel">
                            Password:</asp:label></td>
                        <td>
                          <asp:textbox runat="server" textmode="Password" id="Password"></asp:textbox>
                          <asp:requiredfieldvalidator runat="server" controltovalidate="Password" tooltip="Password is required."
                            id="PasswordRequired" validationgroup="Createuserwizard1" errormessage="Password is required.">
                            *</asp:requiredfieldvalidator>
                        </td>
                      </tr>
                      <tr>
                        <td align="right">
                          <asp:label runat="server" associatedcontrolid="ConfirmPassword" id="ConfirmPasswordLabel">
                            Confirm Password:</asp:label></td>
                        <td>
                          <asp:textbox runat="server" textmode="Password" id="ConfirmPassword"></asp:textbox>
                          <asp:requiredfieldvalidator runat="server" controltovalidate="ConfirmPassword" tooltip="Confirm Password is required."
                            id="ConfirmPasswordRequired" validationgroup="Createuserwizard1" errormessage="Confirm Password is required.">
                            *</asp:requiredfieldvalidator>
                        </td>
                      </tr>
                      <tr>
                        <td align="right">
                          <asp:label runat="server" associatedcontrolid="Email" id="EmailLabel">
                            Email:</asp:label></td>
                        <td>
                          <asp:textbox runat="server" id="Email"></asp:textbox>
                          <asp:requiredfieldvalidator runat="server" controltovalidate="Email" tooltip="Email is required."
                            id="EmailRequired" validationgroup="Createuserwizard1" errormessage="Email is required.">
                            *</asp:requiredfieldvalidator>
                        </td>
                      </tr>
                      <tr>
                        <td align="right">
                          <asp:label runat="server" associatedcontrolid="Question" id="QuestionLabel">
                            Security Question:</asp:label></td>
                        <td>
                          <asp:textbox runat="server" id="Question"></asp:textbox>
                          <asp:requiredfieldvalidator runat="server" controltovalidate="Question" tooltip="Security question is required."
                            id="QuestionRequired" validationgroup="Createuserwizard1" errormessage="Security question is required.">
                            *</asp:requiredfieldvalidator>
                        </td>
                      </tr>
                      <tr>
                        <td align="right">
                          <asp:label runat="server" associatedcontrolid="Answer" id="AnswerLabel">
                            Security Answer:</asp:label></td>
                        <td>
                          <asp:textbox runat="server" id="Answer"></asp:textbox>
                          <asp:requiredfieldvalidator runat="server" controltovalidate="Answer" tooltip="Security answer is required."
                            id="AnswerRequired" validationgroup="Createuserwizard1" errormessage="Security answer is required.">
                            *</asp:requiredfieldvalidator>
                        </td>
                      </tr>
                      <tr>
                        <td align="center" colspan="2">
                          <asp:comparevalidator runat="server" display="Dynamic" errormessage="The Password and Confirmation Password must match."
                            controltocompare="ConfirmPassword" controltovalidate="Password" id="PasswordCompare"
                            validationgroup="Createuserwizard1">
                          </asp:comparevalidator>
                        </td>
                      </tr>
                      <tr>
                        <td align="center" colspan="2" style="color: Red;">
                          <asp:literal runat="server" enableviewstate="False" id="FailureText">
                          </asp:literal>
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </table>
            </contenttemplate>
          </asp:createuserwizardstep>
          <asp:completewizardstep runat="server" title="Complete">
            <contenttemplate>
              <table border="0">
                <tr>
                  <td>
                    <table border="0" style="height: 100%; width: 100%;">
                      <tr>
                        <td align="center" colspan="2">
                          Complete</td>
                      </tr>
                      <tr>
                        <td>
                          Your account has been successfully created.</td>
                      </tr>
                      <tr>
                        <td align="right" colspan="2">
                          <asp:button runat="server" validationgroup="Createuserwizard1" commandname="Continue"
                            id="ContinueButton" causesvalidation="False" text="Continue" />
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </table>
            </contenttemplate>
          </asp:completewizardstep>
        </wizardsteps>
      </asp:createuserwizard>
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
