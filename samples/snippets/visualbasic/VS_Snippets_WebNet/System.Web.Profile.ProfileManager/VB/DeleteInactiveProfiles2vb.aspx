<!-- <Snippet7> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Profile" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Dim authOption As ProfileAuthenticationOption 
Dim inactiveDays As Integer = 120
Dim deletedProfiles As Integer = 0

Public Sub Page_Load()
  DeletedMessage.Text = ""

  authOption = GetAuthenticationOption()

  If Not IsPostBack Then  
    InactiveDaysTextBox.Text = inactiveDays.ToString()
    GetProfiles()
  Else
    inactiveDays = Convert.ToInt32(InactiveDaysTextBox.Text)
  End If
End Sub

Public Sub ProfileGrid_Delete(sender As Object, args As GridViewCommandEventArgs)
  ' Retrieve user name selected.

  Dim index As Integer = Convert.ToInt32(args.CommandArgument)

  Dim username As String = ProfileGrid.Rows(index).Cells(0).Text

  ProfileManager.DeleteProfiles(New String() {username})

  DeletedMessage.Text = "1 profile deleted."

  ' Refresh profile list.

  GetProfiles()
End Sub


Private Sub GetProfiles()
  ProfileGrid.DataSource = ProfileManager.GetAllInactiveProfiles(authOption, _
                               DateTime.Now.Subtract(new TimeSpan(inactiveDays, 0, 0, 0)))
  ProfileGrid.DataBind()
End Sub

Public Sub NextButton_OnClick(sender As Object, args As EventArgs)
  GetProfiles()
End Sub

Public Sub PreviousButton_OnClick(sender As Object, args As EventArgs)
  GetProfiles()
End Sub

Public Sub ModifyInactiveDaysButton_OnClick(sender As Object, args As EventArgs)
  GetProfiles()
End Sub

Public Sub AuthenticationOptionListBox_OnSelectedIndexChanged(sender As Object, args As EventArgs)
  authOption = GetAuthenticationOption()
  GetProfiles()
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

Public Sub DeleteAllInactiveButton_OnClick(sender As Object, args As EventArgs)
  deletedProfiles = ProfileManager.DeleteInactiveProfiles(authOption, _
                        DateTime.Now.Subtract(new TimeSpan(inactiveDays, 0, 0 ,0)))
  DeletedMessage.Text = deletedProfiles.ToString() & " profiles deleted."
  GetProfiles()
End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: Find Profiles</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>Profile List</h3>

  <table border="0" cellpadding="3" cellspacing="3">
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
    </tr>
    <tr>
      <td valign="top" style="width:160">
        Number of Days for Profile to be considered "inactive"</td>
      <td valign="top" style="width:200">
        <asp:TextBox id="InactiveDaysTextBox" runat="Server" MaxLength="3" Columns="3" />
        <asp:Button id="ModifyInactiveDaysButton" runat="server" Text="Refresh Results" 
           OnClick="ModifyInactiveDaysButton_OnClick" /><br />
        <asp:Button id="DeleteAllInactiveButton" runat="Server"
           Text="Delete All Inactive Profiles" OnClick="DeleteAllInactiveButton_OnClick" />
      </td>
      <td valign="top">
        <asp:RequiredFieldValidator id="InactiveDaysRequiredValidator" runat="server"
           ControlToValidate="InactiveDaysTextBox" ForeColor="red"
           Display="Static" ErrorMessage="Required" />
        <asp:RegularExpressionValidator id="InactiveDaysValidator" runat="server"
           ControlToValidate="InactiveDaysTextBox" ForeColor="red"
           Display="Static" ValidationExpression="(0-9)*" 
           ErrorMessage="Inactive Days must be a whole number less than 1000 (e.g. 30, 120)" />
     </td>
    </tr>
    <tr>
      <td><asp:Label id="DeletedMessage" runat="server" /></td>
    </tr>
  </table>

  <asp:GridView id="ProfileGrid" runat="server" AutoGenerateColumns="false"
                OnRowCommand="ProfileGrid_Delete"
                CellPadding="2" CellSpacing="1" Gridlines="None">
    <HeaderStyle BackColor="darkblue" ForeColor="white" />
    <Columns>
      <asp:BoundField HeaderText="User Name" DataField="Username" />
      <asp:BoundField HeaderText="Is Anonymous" DataField="IsAnonymous" />
      <asp:BoundField HeaderText="Last Updated" DataField="LastUpdatedDate" />
      <asp:BoundField HeaderText="Last Activity" DataField="LastActivityDate" />
      <asp:ButtonField HeaderText="Action" Text="Delete" ButtonType="Link" />
    </Columns>
  </asp:GridView>

</form>

</body>
</html>
<!-- </Snippet7> -->