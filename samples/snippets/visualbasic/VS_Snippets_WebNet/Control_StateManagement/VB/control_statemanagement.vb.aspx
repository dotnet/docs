<%@ Page Language="VB"  %>
<%@ Register TagPrefix="LogOnControlSample" Namespace="LogOnControlSample" Assembly = "Control_State" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
      <script language="VB" runat="server">

' <Snippet7>
      Sub Page_Load(sender As Object, e As System.EventArgs)
         DataBind()
         ' Set EnableViewState to false to disable saving of view state 
         ' information.
         myControl.EnableViewState = False
         If Not IsPostBack Then
            display.Enabled = False
         End If 
      End Sub
' </Snippet7>

      Sub SubmitBtn_Click(sender As Object, e As EventArgs)
         myControl.UserText = user.Text
         myControl.PasswordText = password.Text
         display.Enabled = True
      End Sub

      Sub Display_Click(sender As Object, e As EventArgs)
         txtSession.Text = "<br /><br />User:" + myControl.UserText + "<br />Password : " + myControl.PasswordText
         display.Enabled = False
      End Sub

   </script>
      <form method="POST" action="testUserControl.aspx" runat="server" id="Form1">
         <table>
            <tr>
               <LogOnControlSample:LogOnControl id="myControl" runat="server" />
            </tr>
            <tr>
               <td>
                  <b>Login: </b>
               </td>
               <td>
                  <asp:TextBox id="user" runat="server" />
               </td>
            </tr>
            <tr>
               <td>
                  <b>Password: </b>
               </td>
               <td>
                  <asp:TextBox id="password" TextMode="Password" runat="server" />
               </td>
            </tr>
            <tr>
               <td>
                  <ASP:Button Text="Submit" id="submit" OnClick="SubmitBtn_Click" runat="server" />
               </td>
               <td>
                  <asp:button Text="Display Saved ViewState" id="display" OnClick="Display_Click" runat="server" />
               </td>
            </tr>
            <tr>
               <td>
                  <b>ViewState Contents</b>
               </td>
               <td>
                  <asp:Label id="txtSession" Text="" Font-Bold="true" runat="server" />
               </td>
            </tr>
         </table>
      </form>
   </body>
</html>
 