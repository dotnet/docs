<!-- <Snippet2> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Profile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Public Sub Page_Load()

  If Not IsPostBack Then
    PropertiesListBox.DataSource = ProfileBase.Properties
    PropertiesListBox.DataBind()
  End If

  If Not PropertiesListBox.SelectedItem Is Nothing Then
    Dim propValue As Object = Profile(PropertiesListBox.SelectedItem.Text)

    Dim propType As Type = propValue.GetType()

    ' If the property is a value type, return ToString().

    If propType Is GetType(String) Or propType.IsValueType Then
      ValueLabel.Visible = True
      ValueGridView.Visible = False
      ValueLabel.Text = propValue.ToString()
      Return
    End If


    ' Bind the property to a GridView.

    Try
      ValueGridView.DataSource = propValue
      ValueGridView.DataBind()
      ValueGridView.Visible = True
      ValueLabel.Visible = False 
    Catch
      ' If the property is not bindable, return ToString().

      ValueLabel.Visible = True
      ValueGridView.Visible = False
      ValueLabel.Text = propValue.ToString()
    End Try
  End If
End Sub

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