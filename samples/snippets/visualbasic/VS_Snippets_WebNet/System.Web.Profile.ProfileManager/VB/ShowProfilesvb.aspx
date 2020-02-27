<!-- <Snippet3> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Profile" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Dim pageSize As Integer = 5
Dim totalProfiles As Integer 
Dim totalPages As Integer 
Dim currentPage As Integer = 1

Public Sub Page_Load()
  If Not IsPostBack Then  
    GetProfiles()
  End If
End Sub

Private Sub GetProfiles()

  ProfileGrid.DataSource = ProfileManager.GetAllProfiles( _
                               ProfileAuthenticationOption.All, _
                               currentPage - 1, pageSize, totalProfiles)
  totalPages = ((totalProfiles - 1) \ pageSize) + 1

  ' Ensure that we do not navigate past the last page of Profiles.

  If currentPage > totalPages Then
    currentPage = totalPages
    GetProfiles()
    Return
  End If

  ProfileGrid.DataBind()
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
  GetProfiles()
End SUb

Public Sub PreviousButton_OnClick(sender As Object, args As EventArgs)
  currentPage = Convert.ToInt32(CurrentPageLabel.Text)
  currentPage -= 1
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

  <asp:Panel id="NavigationPanel" Visible="False" runat="server">
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