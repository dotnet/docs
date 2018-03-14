<!-- <Snippet30> -->

<%@ Page Language="VB" %>

<%@ Import Namespace="System.Collections" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  Public Sub Page_Load(ByVal sender As Object, ByVal args As EventArgs)
    If Not IsPostBack Then
      If Session("Address") Is Nothing Then
        EnterUserInfoPanel.Visible = True
        UserInfoPanel.Visible = False
      Else
        EnterUserInfoPanel.Visible = False
        UserInfoPanel.Visible = True
        
        SetLabels()
      End If
    End If
  End Sub
  
  Protected Sub SetLabels()
    FirstNameLabel.Text = Session("FirstName").ToString()
    LastNameLabel.Text = Session("LastName").ToString()
    AddressLabel.Text = Session("Address").ToString()
    CityLabel.Text = Session("City").ToString()
    StateOrProvinceLabel.Text = Session("StateOrProvince").ToString()
    ZipCodeLabel.Text = Session("ZipCode").ToString()
    CountryLabel.Text = Session("Country").ToString()
  End Sub
  
  Protected Sub EnterInfoButton_OnClick(ByVal sender As Object, ByVal args As EventArgs)
    Session("FirstName") = Server.HtmlEncode(FirstNameTextBox.Text)
    Session("LastName") = Server.HtmlEncode(LastNameTextBox.Text)
    Session("Address") = Server.HtmlEncode(AddressTextBox.Text)
    Session("City") = Server.HtmlEncode(CityTextBox.Text)
    Session("StateOrProvince") = Server.HtmlEncode(StateOrProvinceTextBox.Text)
    Session("ZipCode") = Server.HtmlEncode(ZipCodeTextBox.Text)
    Session("Country") = Server.HtmlEncode(CountryTextBox.Text)
    
    EnterUserInfoPanel.Visible = False
    UserInfoPanel.Visible = True
    
    SetLabels()
  End Sub
  
  Protected Sub ChangeInfoButton_OnClick(ByVal sender As Object, ByVal args As EventArgs)
    EnterUserInfoPanel.Visible = True
    UserInfoPanel.Visible = False
  End Sub
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
    <asp:Panel ID="EnterUserInfoPanel" runat="server">
      <table cellpadding="3" border="0">
        <tr>
          <td>
            First name:</td>
          <td>
            <asp:TextBox ID="FirstNameTextBox" runat="server" /></td>
        </tr>
        <tr>
          <td>
            Last name:</td>
          <td>
            <asp:TextBox ID="LastNameTextBox" runat="server" /></td>
        </tr>
        <tr>
          <td>
            Address:</td>
          <td>
            <asp:TextBox ID="AddressTextBox" runat="server" /></td>
        </tr>
        <tr>
          <td>
            City:</td>
          <td>
            <asp:TextBox ID="CityTextBox" runat="server" /></td>
        </tr>
        <tr>
          <td>
            State or Province:</td>
          <td>
            <asp:TextBox ID="StateOrProvinceTextBox" runat="server" /></td>
        </tr>
        <tr>
          <td>
            Zip Code/Postal Code:</td>
          <td>
            <asp:TextBox ID="ZipCodeTextBox" runat="server" /></td>
        </tr>
        <tr>
          <td>
            Country:</td>
          <td>
            <asp:TextBox ID="CountryTextBox" runat="server" /></td>
        </tr>
        <tr>
          <td>
            &nbsp;</td>
          <td>
            <asp:Button ID="EnterInfoButton" runat="server" Text="Enter user information" OnClick="EnterInfoButton_OnClick" /></td>
        </tr>
      </table>
    </asp:Panel>
    <asp:Panel ID="UserInfoPanel" runat="server">
      <table cellpadding="3" border="0">
        <tr>
          <td>
            Name:</td>
          <td>
            <asp:Label ID="FirstNameLabel" runat="server" />
            <asp:Label ID="LastNameLabel" runat="server" />
          </td>
        </tr>
        <tr>
          <td valign="top">
            Address:</td>
          <td>
            <asp:Label ID="AddressLabel" runat="server" /><br />
            <asp:Label ID="CityLabel" runat="server" />,
            <asp:Label ID="StateOrProvinceLabel" runat="server" />
            <asp:Label ID="ZipCodeLabel" runat="server" /><br />
            <asp:Label ID="CountryLabel" runat="server" />
          </td>
        </tr>
        <tr>
          <td>
            &nbsp;</td>
          <td>
            <asp:Button ID="ChangeInfoButton" runat="server" Text="Change user information" OnClick="ChangeInfoButton_OnClick" /></td>
        </tr>
      </table>
    </asp:Panel>
  </form>
</body>
</html>
<!-- </Snippet30> -->
