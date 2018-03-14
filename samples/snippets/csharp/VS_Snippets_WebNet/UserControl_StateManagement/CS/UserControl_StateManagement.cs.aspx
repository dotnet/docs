<%@ Page Language="C#" Trace="true" %>
<%@ Register TagPrefix="MyUserControl" TagName="Logon" Src="Logonform.cs.ascx" %>
<%@ Reference Control="Logonform.cs.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void SubmitBtn_Click(Object sender, EventArgs e)
  {
    display.Enabled = true;
  }

  void Display_Click(Object sender, EventArgs e)
  {
    txtSession.Text = "<br /><br />User:" + myControl.UserText + "<br />Password : " + myControl.PasswordText;

    display.Enabled = false;
    
  }

  protected void Page_Load(object sender, EventArgs e)
  {
    if (!myControl.IsPostBack)
      display.Enabled = false;

  }
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
      <form id="form1" method="POST" action="testUserControl.aspx" runat="server">
         <table>
            <tr>
               <MyUserControl:Logon id="myControl" runat="server" />
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
                    <br />
                    <br />
                    <br />
                    <b>ViewState Contents</b>
                </td>
            </tr>
            <tr>
               <asp:Label id="txtSession" Text="" Font-Bold="true" runat="server" />
            </tr>
         </table>
      </form>
   </body>
</html>
