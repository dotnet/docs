<!-- <Snippet5> -->
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
SqlProfileProvider provider;

int inactiveDays = 90;

public void Page_Load()
{
  InactiveDaysLabel.Text = inactiveDays.ToString();
  authOption = GetAuthenticationOption();

  provider = (SqlProfileProvider)Profile.Providers["SqlProvider"];

  InactiveProfilesLabel.Text = provider.GetNumberOfInactiveProfiles(authOption,
               DateTime.Now.Subtract(new TimeSpan(inactiveDays, 0, 0, 0))).ToString();

  DeletedMessage.Text = "";
}


private ProfileInfoCollection GetProfiles()
{
  ProfileInfoCollection profiles;

  if (ShowInactiveCheckBox.Checked)
  {
    profiles = provider.FindInactiveProfilesByUserName(authOption, 
                 UserNameTextBox.Text, 
                 DateTime.Now.Subtract(new TimeSpan(inactiveDays, 0, 0, 0)),
                 currentPage - 1, pageSize, out totalProfiles);
  }
  else
  {
    profiles = provider.FindProfilesByUserName(authOption, 
                 UserNameTextBox.Text, 
                 currentPage - 1, pageSize, out totalProfiles);
  }

  return profiles;
}

private void ShowProfiles()
{
  if (UserNameTextBox.Text.Trim() == "")
  {
    Msg.Text = "Please specify a user name.";
    NavigationPanel.Visible = false;
    ProfileGrid.Visible = false;
    return;
  }
  
  Msg.Text = "";
  ProfileGrid.Visible = true;

  ProfileGrid.DataSource = GetProfiles();

  totalPages = ((totalProfiles - 1) / pageSize) + 1;

  // Ensure that we do not navigate past the last page of users.

  if (currentPage > totalPages)
  {
    currentPage = totalPages;
    ShowProfiles();
    return;
  }

  ProfileGrid.DataBind();

  TotalProfilesLabel.Text = totalProfiles.ToString();
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
  ShowProfiles();
}

public void PreviousButton_OnClick(object sender, EventArgs args)
{
  currentPage = Convert.ToInt32(CurrentPageLabel.Text);
  currentPage--;
  ShowProfiles();
}

public void GoButton_OnClick(object sender, EventArgs args)
{
  currentPage = 1;
  ShowProfiles();
}

public void ShowInactiveCheckBox_OnCheckedChanged(object sender, EventArgs args)
{
  ShowProfiles();
}

public void DeleteButton_OnClick(object sender, EventArgs args)
{
  provider.DeleteProfiles(GetProfiles());
  DeletedMessage.Text = totalProfiles.ToString() + " profiles deleted.";
  ShowProfiles();
}

public void AuthenticationOptionListBox_OnSelectedIndexChanged(object sender, EventArgs args)
{
  authOption = GetAuthenticationOption();
  ShowProfiles();
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

  <asp:Panel id="NavigationPanel" Visible="false" runat="server">
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