<!-- <Snippet2> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Profile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

public void Page_Load()
{
  if (!IsPostBack)
  {
    PropertiesListBox.DataSource = ProfileBase.Properties;
    PropertiesListBox.DataBind();
  }

  if (PropertiesListBox.SelectedItem != null)
  {
    object propValue = Profile[PropertiesListBox.SelectedItem.Text];

    Type propType = propValue.GetType();

    // If the property is a value type, return ToString().

    if (propType == typeof(string) || propType.IsValueType)
    {
      ValueLabel.Visible = true;
      ValueGridView.Visible = false;
      ValueLabel.Text = propValue.ToString();
      return;
    }


    // Bind the property to a GridView.

    try
    {
      ValueGridView.DataSource = propValue;
      ValueGridView.DataBind();
      ValueGridView.Visible = true;
      ValueLabel.Visible = false; 
    }
    catch
    {
      // If the property is not bindable, return ToString().

      ValueLabel.Visible = true;
      ValueGridView.Visible = false;
      ValueLabel.Text = propValue.ToString();
    }
  }
}

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Home Page</title>
</head>
<body>

<h3>View Profile properties:</h3>

<form id="form1" runat="server">
  <table border="0" cellpadding="2" cellspacing="2">
    <tr>
      <td>Property</td>
      <td>Value</td>
    </tr>
    <tr>
      <td valign="top">
        <asp:ListBox runat="server" id="PropertiesListBox" Rows="10" AutoPostBack="True" DataTextField="Name" />
      </td>
      <td valign="top">
        <asp:GridView runat="Server" id="ValueGridView" Visible="False" />
        <asp:Label runat="Server" id="ValueLabel" Visible="False" />
      </td>
    </tr>
  </table>
</form>

</body>
</html>
<!-- </Snippet2> -->