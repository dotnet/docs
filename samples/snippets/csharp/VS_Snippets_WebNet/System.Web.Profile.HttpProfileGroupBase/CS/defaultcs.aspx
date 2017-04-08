<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

public void Page_Load()
{
  if (!IsPostBack)
  {
    StreetTextBox.Text          = Profile.Address.Street;
    CityTextBox.Text            = Profile.Address.City;
    StateTextBox.Text           = Profile.Address.State;
    CountryOrRegionTextBox.Text = Profile.Address.CountryOrRegion;
    ZipCodeTextBox.Text         = Profile.ZipCode;
  }
}

public void UpdateButton_OnClick(object sender, EventArgs args)
{
  Profile.Address.Street          = StreetTextBox.Text;
  Profile.Address.City            = CityTextBox.Text;
  Profile.Address.State           = StateTextBox.Text;
  Profile.Address.CountryOrRegion = CountryOrRegionTextBox.Text;
  Profile.ZipCode                 = ZipCodeTextBox.Text;
}

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Home Page</title>
</head>
<body>
<h3>Address Information for <%=User.Identity.Name%></h3>
<form id="form1" runat="server">
  <table border="1" cellpadding="2" cellspacing="2">
    <tr>
      <td>Street Address</td>
      <td><asp:Textbox id="StreetTextBox" runat="server" columns="30" /></td>
    </tr>
    <tr>
      <td>City</td>
      <td><asp:Textbox id="CityTextBox" runat="server" columns="20" /></td>
    </tr>
    <tr>
      <td>State</td>
      <td><asp:Textbox id="StateTextBox" runat="server" columns="20" /></td>
    </tr>
    <tr>
      <td>Zip Code</td>
      <td><asp:Textbox id="ZipCodeTextBox" runat="server" columns="10" /></td>
    </tr>
    <tr>
      <td>Country</td>
      <td><asp:Textbox id="CountryOrRegionTextBox" runat="server" columns="20" /></td>
    </tr>
  </table>
  <asp:Button id="UpdateButton" runat="server" OnClick="UpdateButton_OnClick" Text="Update Address" />
</form>

</body>
</html>
<!-- </Snippet1> -->