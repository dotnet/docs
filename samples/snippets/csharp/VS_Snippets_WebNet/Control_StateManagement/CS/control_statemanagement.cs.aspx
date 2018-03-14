<%@ Page Language="C#"  %>
<%@ Register TagPrefix="LogOnControlSample" Namespace="LogOnControlSample" Assembly = "Control_State" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
      <script language="C#" runat="server">

// <Snippet7>
void Page_Load(object sender, System.EventArgs e)
{
      DataBind();
      // Set EnableViewState to false to disable saving of view state 
      // information.
      myControl.EnableViewState = false;
      if (!IsPostBack)
         display.Enabled = false;
      
}
// </Snippet7>
void SubmitBtn_Click(Object sender, EventArgs e) 
{
      myControl.UserText = user.Text;
      myControl.PasswordText = password.Text;
      display.Enabled = true;    
}

void Display_Click(Object sender, EventArgs e)
{
      txtSession.Text = "<br /><br />User:" + myControl.UserText + 
                      "<br />Password : " + myControl.PasswordText;
      display.Enabled = false;
}
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
