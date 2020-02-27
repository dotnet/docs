<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

public void Page_PreRender()
{
  if (Profile.ZipCode == null)
  {
    PersonalizePanel.Visible = false;
    GetZipCodePanel.Visible = true;
  }
  else
  {
    ZipCodeLabel.Text = Profile.ZipCode;

    // Get personalized information for zip code here.

    PersonalizePanel.Visible = true;
    GetZipCodePanel.Visible = false;
  }
}

public void ChangeZipCode_OnClick(object sender, EventArgs args)
{
  ZipCodeTextBox.Text = Profile.ZipCode;
  Profile.ZipCode = null;

  PersonalizePanel.Visible = false;
  GetZipCodePanel.Visible = true;
}

public void EnterZipCode_OnClick(object sender, EventArgs args)
{
  Profile.ZipCode = ZipCodeTextBox.Text;
}

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Home Page</title>
</head>
<body>

<form id="form1" runat="server">
  <table border="1" cellpadding="2" cellspacing="2">
    <tr>
      <td>
        <asp:Panel id="PersonalizePanel" runat="Server" Visible="False">
          Information for Zip Code: <asp:Label id="ZipCodeLabel" Runat="Server" /><br />
          <!-- Information for Zip Code here. -->
          <br />
          <asp:LinkButton id="ChangeZipCodeButton" Runat="Server" Text="Change Your Zip Code"
                          OnClick="ChangeZipCode_OnClick" />
        </asp:Panel>
        <asp:Panel id="GetZipCodePanel" runat="Server" Visible="False">
          You can personalize this page by entering your Zip Code: 
          <asp:TextBox id="ZipCodeTextBox" Columns="5" MaxLength="5" runat="Server" />
          <asp:LinkButton id="EnterZipCodeButton" Runat="Server" Text="Go"
                          OnClick="EnterZipCode_OnClick" />
        </asp:Panel>
      </td>
    </tr>
  </table>
</form>

</body>
</html>
<!-- </Snippet1> -->