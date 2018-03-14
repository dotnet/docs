<!-- <Snippet4> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Profile" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

int pageSize = 5;
int totalProfiles;
int totalPages;
int currentPage = 1;

ProfileAuthenticationOption authOption;
int inactiveDays = 120;
int deletedProfiles = 0;

public void Page_Load()
{
  DeletedMessage.Text = "";

  authOption = GetAuthenticationOption();

  if (!IsPostBack)
  {
    InactiveDaysTextBox.Text = inactiveDays.ToString();

    GetProfiles();
  }
  else
  {
    inactiveDays = Convert.ToInt32(InactiveDaysTextBox.Text);
  }
}

public void ProfileGrid_Delete(object sender, GridViewCommandEventArgs args)
{
  // Retrieve user name selected.

  int index = Convert.ToInt32(args.CommandArgument);

  string username = ProfileGrid.Rows[index].Cells[0].Text;

  ProfileManager.DeleteProfiles(new string[] {username});

  DeletedMessage.Text = "1 profile deleted.";

  // Refresh profile list.

  currentPage = Convert.ToInt32(CurrentPageLabel.Text);
  GetProfiles();
}


private void GetProfiles()
{
  ProfileGrid.DataSource = ProfileManager.GetAllInactiveProfiles(authOption,
                               DateTime.Now.Subtract(new TimeSpan(inactiveDays, 0, 0, 0)),
                               currentPage - 1, pageSize, out totalProfiles);

  TotalProfilesLabel.Text = totalProfiles.ToString();

  totalPages = ((totalProfiles - 1) / pageSize) + 1;

  // Ensure that we do not navigate past the last page of Profiles.

  if (currentPage > totalPages)
  {
    currentPage = totalPages;
    GetProfiles();
    return;
  }

  ProfileGrid.DataBind();
  CurrentPageLabel.Text = currentPage.ToString();
  TotalPagesLabel.Text = totalPages.ToString();

  if (currentPage == totalPages)
    NextButton.Visible = false;
  else
    NextButton.Visible = true;

  if (currentPage == 1)
    PreviousButton.Visible = false;
  else
    PreviousButton.Visible = true;

  if (totalProfiles <= 0)
    NavigationPanel.Visible = false;
  else
    NavigationPanel.Visible = true;
}

public void NextButton_OnClick(object sender, EventArgs args)
{
  currentPage = Convert.ToInt32(CurrentPageLabel.Text);
  currentPage++;
  GetProfiles();
}

public void PreviousButton_OnClick(object sender, EventArgs args)
{
  currentPage = Convert.ToInt32(CurrentPageLabel.Text);
  currentPage--;
  GetProfiles();
}

public void ModifyInactiveDaysButton_OnClick(object sender, EventArgs args)
{
  GetProfiles();
}

public void AuthenticationOptionListBox_OnSelectedIndexChanged(object sender, EventArgs args)
{
  authOption = GetAuthenticationOption();
  GetProfiles();
}

private ProfileAuthenticationOption GetAuthenticationOption()
{
  if (AuthenticationOptionListBox.SelectedItem != null)
  {
    switch (AuthenticationOptionListBox.SelectedItem.Value)
    {
      case "Anonymous":
        return ProfileAuthenticationOption.Anonymous;
        break;
      case "Authenticated":
        return ProfileAuthenticationOption.Authenticated;
        break;
      default:
        return ProfileAuthenticationOption.All;
        break;
    }
  }

  return ProfileAuthenticationOption.All;
}

public void DeleteAllInactiveButton_OnClick(object sender, EventArgs args)
{
  deletedProfiles = ProfileManager.DeleteInactiveProfiles(authOption, 
                        DateTime.Now.Subtract(new TimeSpan(inactiveDays, 0, 0 ,0)));
  DeletedMessage.Text = deletedProfiles.ToString() + " profiles deleted.";
  GetProfiles();
}

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
           Display="Static" ValidationExpression="[0-9]*" 
           ErrorMessage="Inactive Days must be a whole number less than 1000 (e.g. 30, 120)" />
     </td>
    </tr>
    <tr>
      <td><asp:Label id="DeletedMessage" runat="server" /></td>
      <td><asp:Label id="TotalProfilesLabel" runat="server" /> inactive profiles found.</td>
    </tr>
  </table>

    <asp:Panel id="NavigationPanel" Visible="false" runat="server">
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
<!-- </Snippet4> -->