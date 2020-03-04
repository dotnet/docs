<!-- <Snippet1> -->
<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server"> 
  Sub PasswordRecovery1_VerifyingUser(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs)
  
      Dim provider as DropDownList
      provider = CType(PasswordRecovery1.FindControl("LoginProvider"),DropDownList)
    PasswordRecovery1.MembershipProvider = provider.SelectedValue
    
        If PasswordRecovery1.MembershipProvider <> "Default" Then
          PasswordRecovery1.UserName = String.Format("{1}\\{0}", _
            PasswordRecovery1.MembershipProvider, PasswordRecovery1.UserName)
        End If
        
    End Sub
    
    Sub PasswordRecovery1_VerifyingAnswer(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs)
    
      PasswordRecovery1.UserName = String.Format("{1}\\{0}", _
        PasswordRecovery1.MembershipProvider, PasswordRecovery1.UserName)
            
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:passwordrecovery id="PasswordRecovery1" 
        runat="server" 
        onverifyinguser="PasswordRecovery1_VerifyingUser" 
        onverifyinganswer="PasswordRecovery1_VerifyingAnswer">
          <usernametemplate>
            <table border="0">
              <tr>
                  <td align="Center" colspan="2">Forgot Your Password?</td>
              </tr>
              <tr>
                  <td align="Center" colspan="2">Enter your User Name to receive your password.</td>
              </tr>
              <tr>
                <td>Log in domain:</td>
                <td>
                  <asp:dropdownlist id="LoginProvider" runat="server">
                    <asp:listitem value="Default">Default</asp:listitem>
                    <asp:listitem value="Administration">Administration</asp:listitem>
                    <asp:listitem value="Editorial">Editorial</asp:listitem>
                    <asp:listitem value="Finance">Finance</asp:listitem>
                    <asp:listitem value="Marketing">Marketing</asp:listitem>
                  </asp:dropdownlist>
                </td>
              </tr>
              <tr>
                <td align="Right">User Name:</td>
                <td>
                  <asp:textbox runat="server" 
                    id="UserName">
                  </asp:textbox>
                  <asp:requiredfieldvalidator runat="server" 
                    controltovalidate="UserName" 
                    errormessage="User Name." 
                    id="UserNameRequired">
                    *
                  </asp:requiredfieldvalidator>
                </td>
              </tr>
              <tr>
                <td align="Right" colspan="2">
                  <asp:button runat="server" 
                    commandname="Submit" 
                    text="Submit" 
                    id="Button">
                  </asp:button>
                </td>
              </tr>
              <tr>
                <td colspan="2" style="color:Red;">
                  <asp:literal runat="server" id="FailureText"></asp:literal>
                </td>
              </tr>
            </table>
          </usernametemplate>
      </asp:passwordrecovery>
    </form>
  </body>
</html>
<!-- </Snippet1> -->
