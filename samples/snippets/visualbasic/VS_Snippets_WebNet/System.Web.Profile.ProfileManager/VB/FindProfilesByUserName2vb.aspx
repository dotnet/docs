<!-- <Snippet8> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Profile" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Dim authOption As ProfileAuthenticationOption

Dim inactiveDays As Integer = 90

Public Sub Page_Load()
  InactiveDaysLabel.Text = inactiveDays.ToString()
  authOption = GetAuthenticationOption()

  InactiveProfilesLabel.Text = ProfileManager.GetNumberOfInactiveProfiles(authOption, _
                                 DateTime.Now.Subtract(new TimeSpan(inactiveDays, 0, 0, 0))).ToString()

  DeletedMessage.Text = ""
End Sub

Private Function GetProfiles() As ProfileInfoCollection 
  Dim profiles As ProfileInfoCollection

  If ShowInactiveCheckBox.Checked Then  
    profiles = ProfileManager.FindInactiveProfilesByUserName(authOption, _
                 UserNameTextBox.Text, _
                 DateTime.Now.Subtract(new TimeSpan(inactiveDays, 0, 0, 0)))
  Else
    profiles = ProfileManager.FindProfilesByUserName(authOption, _
                 UserNameTextBox.Text)
  End If

  Return profiles
End Function

Private Sub ShowProfiles()
  If UserNameTextBox.Text.Trim() = "" Then  
    Msg.Text = "Please specify a user name."
    ProfileGrid.Visible = False
    Return
  End If
  
  Msg.Text = ""
  ProfileGrid.Visible = True

  ProfileGrid.DataSource = GetProfiles()
  ProfileGrid.DataBind()
End Sub

Public Sub GoButton_OnClick(sender As Object, args As EventArgs)
  ShowProfiles()
End Sub

Public Sub ShowInactiveCheckBox_OnCheckedChanged(sender As Object, args As EventArgs)
  ShowProfiles()
End Sub

Public Sub DeleteButton_OnClick(sender As Object, args As EventArgs)
  DeletedMessage.Text = ProfileManager.DeleteProfiles(GetProfiles()).ToString() & _
                          " profiles deleted."
  ShowProfiles()
End Sub

Public Sub AuthenticationOptionListBox_OnSelectedIndexChanged(sender As Object, args As EventArgs)
  authOption = GetAuthenticationOption()
  ShowProfiles()
End Sub

Private Function GetAuthenticationOption() As ProfileAuthenticationOption 
  If Not AuthenticationOptionListBox.SelectedItem Is Nothing Then  
    Select Case AuthenticationOptionListBox.SelectedItem.Value    
      Case "Anonymous"
        Return ProfileAuthenticationOption.Anonymous
      Case "Authenticated"
        Return ProfileAuthenticationOption.Authenticated
      Case Else
        Return ProfileAuthenticationOption.All
    End Select
  End If

  Return ProfileAuthenticationOption.All
End Function

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: Find Profiles</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>Profile List</h3>

  <asp:Label id="Msg" runat="Server" ForeColor="red" /><br />

  <table border="0" cellpadding="3" cellspacing="3">
    <tr>
      <td valign="top">UserName to Search for:</td>
      <td valign="top" colspan="2">
        <asp:TextBox id="UserNameTextBox" runat="server" />
        <asp:Button id="GoButton" Text=" Go " OnClick="GoButton_OnClick" runat="server" /><br />
      </td>
    </tr>
    <tr>
      <td valign="top">Authentication Option</td>
      <td valign="top"><asp:ListBox id="AuthenticationOptionListBox" rows="3" runat="Server"
                                    AutoPostBack="true"
                                    OnSelectedIndexChanged="AuthenticationOptionListBox_OnSelectedIndexChanged">
                         <asp:ListItem value="All" selected="True">All</asp:ListItem>
                         <asp:ListItem value="Authenticated">Authenticated</asp:ListItem>
                         <asp:ListItem value="Anonymous">Anonymous</asp:ListItem>
                       </asp:ListBox>
      </td>
      <td valign="top"><asp:CheckBox id="ShowInactiveCheckBox" Checked="false" 
                                     AutoPostBack="true" runat="server"
                                     OnCheckedChanged="ShowInactiveCheckBox_OnCheckedChanged" />
                       Show profiles inactive for
                       <asp:Label id="InactiveDaysLabel" runat="server" />
                       days only.<br />
                       There are <asp:Label id="InactiveProfilesLabel" runat="server" />
                       inactive profiles.
      </td>
    </tr>
    <tr>
      <td><asp:Button id="DeleteButton" runat="server" 
                      Text="Delete Profiles" OnClick="DeleteButton_OnClick" />
          <br /><i>(based on search results)</i>
      </td>
      <td valign="top"><asp:Label id="DeletedMessage" runat="server" /></td>
    </tr>
  </table>

  <asp:DataGrid id="ProfileGrid" runat="server"
                CellPadding="2" CellSpacing="1"
                Gridlines="Both">
    <HeaderStyle BackColor="darkblue" ForeColor="white" />
  </asp:DataGrid>

</form>

</body>
</html>
<!-- </Snippet8> -->