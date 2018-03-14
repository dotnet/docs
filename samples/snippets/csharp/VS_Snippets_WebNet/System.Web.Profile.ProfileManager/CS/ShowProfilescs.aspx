<!-- <Snippet3> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Profile" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

int pageSize = 5;
int totalProfiles;
int totalPages;
int currentPage = 1;

public void Page_Load()
{
  if (!IsPostBack)
  {
    GetProfiles();
  }
}

private void GetProfiles()
{
  ProfileGrid.DataSource = ProfileManager.GetAllProfiles(
                               ProfileAuthenticationOption.All,
                               currentPage - 1, pageSize, out totalProfiles);
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

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: Find Profiles</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>Profile List</h3>

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

  <asp:GridView id="ProfileGrid" runat="server"
                CellPadding="2" CellSpacing="1" Gridlines="Both">
    <HeaderStyle BackColor="darkblue" ForeColor="white" />
  </asp:GridView>

</form>

</body>
</html>
<!-- </Snippet3> -->