<!-- <Snippet5> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Profile" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Dim pageSize As Integer = 5
Dim totalProfiles As Integer
Dim totalPages As Integer
Dim currentPage As Integer = 1

Dim authOption As ProfileAuthenticationOption 
Dim provider As SqlProfileProvider 

Dim inactiveDays As Integer = 90

Public Sub Page_Load()
  InactiveDaysLabel.Text = inactiveDays.ToString()
  authOption = GetAuthenticationOption()

  provider = CType(Profile.Providers("SqlProvider"), SqlProfileProvider)

  InactiveProfilesLabel.Text = provider.GetNumberOfInactiveProfiles(authOption, _
               DateTime.Now.Subtract(New TimeSpan(inactiveDays, 0, 0, 0))).ToString()

  DeletedMessage.Text = ""
End Sub


Private Function GetProfiles() As ProfileInfoCollection 
  Dim profiles As ProfileInfoCollection 

  If ShowInactiveCheckBox.Checked Then  
    profiles = provider.FindInactiveProfilesByUserName(authOption, _
                 UserNameTextBox.Text, _
                 DateTime.Now.Subtract(New TimeSpan(inactiveDays, 0, 0, 0)), _
                 currentPage - 1, pageSize, totalProfiles)
  Else
    profiles = provider.FindProfilesByUserName(authOption, _
                 UserNameTextBox.Text, _
                 currentPage - 1, pageSize, totalProfiles)
  End If

  Return profiles
End Function

Private Sub ShowProfiles()
  If UserNameTextBox.Text.Trim() = "" Then  
    Msg.Text = "Please specify a user name."
    NavigationPanel.Visible = False
    ProfileGrid.Visible = False
    Return
  End If
  
  Msg.Text = ""
  ProfileGrid.Visible = True

  ProfileGrid.DataSource = GetProfiles()

  totalPages = ((totalProfiles - 1) \ pageSize) + 1

  ' Ensure that we do not navigate past the last page of users.

  If currentPage > totalPages Then  
    currentPage = totalPages
    ShowProfiles()
    Return
  End If

  ProfileGrid.DataBind()

  TotalProfilesLabel.Text = totalProfiles.ToString()
  CurrentPageLabel.Text = currentPage.ToString()
  TotalPagesLabel.Text = totalPages.ToString()

  If currentPage = totalPages Then
    NextButton.Visible = False
  Else
    NextButton.Visible = True
  End If

  If currentPage = 1 Then
    PreviousButton.Visible = False
  Else
    PreviousButton.Visible = True
  End If

  If totalProfiles <= 0 Then
    NavigationPanel.Visible = False
  Else
    NavigationPanel.Visible = True
  End If
End Sub

Public Sub NextButton_OnClick(sender As Object, args As EventArgs)
  currentPage = Convert.ToInt32(CurrentPageLabel.Text)
  currentPage += 1
  ShowProfiles()
End Sub

Public Sub PreviousButton_OnClick(sender As Object, args As EventArgs)
  currentPage = Convert.ToInt32(CurrentPageLabel.Text)
  currentPage -= 1
  ShowProfiles()
End Sub

Public Sub GoButton_OnClick(sender As Object, args As EventArgs)
  currentPage = 1
  ShowProfiles()
End Sub

Public Sub ShowInactiveCheckBox_OnCheckedChanged(sender As Object, args As EventArgs)
  ShowProfiles()
End Sub

Public Sub DeleteButton_OnClick(sender As Object, args As EventArgs)
  provider.DeleteProfiles(GetProfiles())
  DeletedMessage.Text = totalProfiles.ToString() & " profiles deleted."
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
<title>Sample Find Profiles</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>Profile List</h3>

  <asp:Label id="Msg" runat="Server" ForeColor="red" /><br />

  <table border="0" cellpadding="3" cellspacing="3">
    <tr>
      <td valign="top">UserName to Search for</td>
      <td valign="top" colspan="2">
        <asp:TextBox id="UserNameTextBox" runat="server" />
        <asp:Button id="GoButton" Text=" Go " OnClick="GoButton_OnClick" runat="server" /><br />
      </td>
    </tr>
    <tr>
      <td valign="top">Authentication Option</td>
      <td valign="top"><asp:ListBox id="AuthenticationOptionListBox" rows="3" runat="Server"
                                    AutoPostBack="True"
                                    OnSelectedIndexChanged="AuthenticationOptionListBox_OnSelectedIndexChanged">
                         <asp:ListItem value="All" selected="True">All</asp:ListItem>
                         <asp:ListItem value="Authenticated">Authenticated</asp:ListItem>
                         <asp:ListItem value="Anonymous">Anonymous</asp:ListItem>
                       </asp:ListBox>
      </td>
      <td valign="top"><asp:CheckBox id="ShowInactiveCheckBox" Checked="False" 
                                     AutoPostBack="True" runat="server"
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

  <asp:Panel id="NavigationPanel" Visible="False" runat="server">
    <asp:Label id="TotalProfilesLabel" runat="server" /> profile(s) found.
    <table border="0" cellpadding="3" cellspacing="3">
      <tr>
        <td style="width:100">Page <asp:Label id="CurrentPageLabel" runat="server" />
            of <asp:Label id="TotalPagesLabel" runat="server" /></td>
        <td style="width:60"><asp:LinkButton id="PreviousButton" Text="< Prev"
                            OnClick="PreviousButton_OnClick" runat="server" /></td>
        <td style="width:60"><asp:LinkButton id="NextButton" Text="Next >"
                            OnClick="NextButton_OnClick" runat="server" /></td>
      </tr>
    </table>
  </asp:Panel>

  <asp:DataGrid id="ProfileGrid" runat="server"
                CellPadding="2" CellSpacing="1"
                Gridlines="Both">
    <HeaderStyle BackColor="darkblue" ForeColor="white" />
  </asp:DataGrid>

</form>

</body>
</html>
<!-- </Snippet5> -->