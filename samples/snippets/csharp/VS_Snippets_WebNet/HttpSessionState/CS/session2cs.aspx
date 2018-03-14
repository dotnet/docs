<!-- <Snippet30> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Collections" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  public void Page_Load(object sender, EventArgs args)
  {
    if (!IsPostBack)
    {
      if (Session["address"] == null)
      {
        enterUserInfoPanel.Visible = true;
        userInfoPanel.Visible = false;
      }
      else
      {
        enterUserInfoPanel.Visible = false;
        userInfoPanel.Visible = true;

        SetLabels();
      }
    }
  }

  protected void SetLabels()
  {
    firstNameLabel.Text = Session["firstName"].ToString();
    lastNameLabel.Text = Session["lastName"].ToString();
    addressLabel.Text = Session["address"].ToString();
    cityLabel.Text = Session["city"].ToString();
    stateOrProvinceLabel.Text = Session["stateOrProvince"].ToString();
    zipCodeLabel.Text = Session["zipCode"].ToString();
    countryLabel.Text = Session["country"].ToString();
  }

  protected void EnterInfoButton_OnClick(object sender, EventArgs e)
  {
    Session["firstName"] = Server.HtmlEncode(firstNameTextBox.Text);
    Session["lastName"] = Server.HtmlEncode(lastNameTextBox.Text);
    Session["address"] = Server.HtmlEncode(addressTextBox.Text);
    Session["city"] = Server.HtmlEncode(cityTextBox.Text);
    Session["stateOrProvince"] = Server.HtmlEncode(stateOrProvinceTextBox.Text);
    Session["zipCode"] = Server.HtmlEncode(zipCodeTextBox.Text);
    Session["country"] = Server.HtmlEncode(countryTextBox.Text);

    enterUserInfoPanel.Visible = false;
    userInfoPanel.Visible = true;

    SetLabels();
  }

  protected void ChangeInfoButton_OnClick(object sender, EventArgs args)
  {
    enterUserInfoPanel.Visible = true;
    userInfoPanel.Visible = true;
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <meta http-equiv="Content-Type" content="text/html" />
  <title>User Information</title>
</head>
<body>
  <form id="form1" runat="server">
    <h3>
      User information</h3>
    <asp:Label ID="Msg" ForeColor="maroon" runat="server" /><br />
    <asp:Panel ID="enterUserInfoPanel" runat="server">
      <table cellpadding="3" border="0">
        <tr>
          <td>
            First name:</td>
          <td>
            <asp:TextBox ID="firstNameTextBox" runat="server" /></td>
        </tr>
        <tr>
          <td>
            Last name:</td>
          <td>
            <asp:TextBox ID="lastNameTextBox" runat="server" /></td>
        </tr>
        <tr>
          <td>
            Address:</td>
          <td>
            <asp:TextBox ID="addressTextBox" runat="server" /></td>
        </tr>
        <tr>
          <td>
            City:</td>
          <td>
            <asp:TextBox ID="cityTextBox" runat="server" /></td>
        </tr>
        <tr>
          <td>
            State or Province:</td>
          <td>
            <asp:TextBox ID="stateOrProvinceTextBox" runat="server" /></td>
        </tr>
        <tr>
          <td>
            Zip Code/Postal Code:</td>
          <td>
            <asp:TextBox ID="zipCodeTextBox" runat="server" /></td>
        </tr>
        <tr>
          <td>
            Country:</td>
          <td>
            <asp:TextBox ID="countryTextBox" runat="server" /></td>
        </tr>
        <tr>
          <td>
            &nbsp;</td>
          <td>
            <asp:Button ID="enterInfoButton" runat="server" Text="Enter user information" OnClick="EnterInfoButton_OnClick" /></td>
        </tr>
      </table>
    </asp:Panel>
    <asp:Panel ID="userInfoPanel" runat="server">
      <table cellpadding="3" border="0">
        <tr>
          <td>
            Name:</td>
          <td>
            <asp:Label ID="firstNameLabel" runat="server" />
            <asp:Label ID="lastNameLabel" runat="server" />
          </td>
        </tr>
        <tr>
          <td valign="top">
            address:</td>
          <td>
            <asp:Label ID="addressLabel" runat="server" /><br />
            <asp:Label ID="cityLabel" runat="server" />,
            <asp:Label ID="stateOrProvinceLabel" runat="server" />
            <asp:Label ID="zipCodeLabel" runat="server" /><br />
            <asp:Label ID="countryLabel" runat="server" />
          </td>
        </tr>
        <tr>
          <td>
            &nbsp;</td>
          <td>
            <asp:Button ID="changeInfoButton" runat="server" Text="Change user information" OnClick="ChangeInfoButton_OnClick" /></td>
        </tr>
      </table>
    </asp:Panel>
  </form>
</body>
</html>
<!-- </Snippet30> -->