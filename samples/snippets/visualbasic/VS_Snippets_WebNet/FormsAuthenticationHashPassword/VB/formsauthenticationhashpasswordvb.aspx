<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head>
    <title>ASP.NET Example</title>
<script runat="server">
         Sub Cancel_Click(sender As Object, e As EventArgs)
            userName.Text = ""
            password.Text = ""
            repeatPassword.Text = ""
            result.Text = ""
         End Sub
    
         Sub HashPassword_Click(sender As Object, e As EventArgs)
            If Page.IsValid Then
               Dim hashMethod As String = ""

               If md5.Checked Then
                  hashMethod = "MD5"
               Else
                  hashMethod = "SHA1"
               End If
    
               Dim hashedPassword As String = _
                  FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, hashMethod)
    
               result.Text = "&lt;credentials passwordFormat=""" & hashMethod & _
                 """&gt;<br />" & "  &lt;user name=""" & Server.HtmlEncode(userName.Text) & """ password=""" & _
                 hashedPassword & """ /&gt;<br />" & "&lt;/credentials&gt;"
            Else
               result.Text = "There was an error on the page."
            End If
         End Sub
      </script>
   </head>

   <body>
      <form id="form1" runat="server">
         <p>This form displays the results of the FormsAuthentication.HashPasswordForStoringInConfigFile
         method.<br />The user name and hashed password can be stored in a &lt;credentials&gt; node
         in the Web.config file.</p>
         <table cellpadding="2">
            <tbody>
               <tr>
                  <td>New User Name:</td>
                  <td><asp:TextBox id="userName" runat="server" /></td>
                  <td><asp:RequiredFieldValidator id="userNameRequiredValidator" 
                        runat="server" ErrorMessage="User name required" 
                        ControlToValidate="userName" /></td>
               </tr>
               <tr>
                  <td>Password: </td>
                  <td><asp:TextBox id="password" runat="server" TextMode="Password" /></td>
                  <td><asp:RequiredFieldValidator id="passwordRequiredValidator" 
                        runat="server" ErrorMessage="Password required" 
                        ControlToValidate="password" /></td>
               </tr>
               <tr>
                  <td>Repeat Password: </td>
                  <td><asp:TextBox id="repeatPassword" runat="server" TextMode="Password" /></td>
                  <td><asp:RequiredFieldValidator id="repeatPasswordRequiredValidator" 
                        runat="server" ErrorMessage="Password confirmation required" 
                        ControlToValidate="repeatPassword" />
                      <asp:CompareValidator id="passwordCompareValidator" runat="server" 
                        ErrorMessage="Password does not match" 
                        ControlToValidate="repeatPassword" 
                        ControlToCompare="password" /></td>
               </tr>
               <tr>
                  <td>Hash function:</td>
                  <td align="center">
                     <asp:RadioButton id="sha1" runat="server" GroupName="HashType" 
                                      Text="SHA1" />
                     <asp:RadioButton id="md5" runat="server" GroupName="HashType" 
                                      Text="MD5" />
                  </td>
               </tr>
               <tr>
                  <td align="center" colspan="2">
                    <asp:Button id="hashPassword" onclick="HashPassword_Click" 
                                runat="server" Text="Hash Password" />&nbsp;&nbsp; 
                    <asp:Button id="cancel" onclick="Cancel_Click" runat="server" 
                                Text="Cancel" CausesValidation="false" />
                  </td>
               </tr>
            </tbody>
         </table>

         <pre><asp:Label id="result" runat="server"></asp:Label></pre>
      </form>
   </body>
</html>
<!-- </Snippet1> -->