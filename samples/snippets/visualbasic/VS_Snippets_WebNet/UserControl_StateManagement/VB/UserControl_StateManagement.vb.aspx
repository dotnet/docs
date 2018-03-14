<%@ Page Language="VB"%>
<%@ Register TagPrefix="MyUserControl" TagName="Logon" Src=".\Logonform.vb.ascx" %>
<%@ Reference Control="Logonform.vb.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub SubmitBtn_Click(ByVal Sender As Object, ByVal e As EventArgs)

    display.Enabled = True
  End Sub

  Sub Display_Click(ByVal Sender As Object, ByVal e As EventArgs)

    txtSession.Text = "<br /><br />User:" + myControl.UserText + "<br />Password : " + myControl.PasswordText
    display.Enabled = False
  End Sub

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
    
    If (Not myControl.IsPostBack) Then
      display.Enabled = False
    End If
    
  End Sub
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
