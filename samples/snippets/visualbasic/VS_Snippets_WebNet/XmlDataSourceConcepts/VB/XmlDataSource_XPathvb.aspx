<!-- <Snippet2> -->
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

Sub SelectRegion(sender As Object, e As EventArgs)
  If RegionDropDownList.SelectedValue = "(Show All)" Then
    PeopleDataSource.XPath = "/People/Person"
  Else
    Dim selectedValue As String = ""

    Select Case RegionDropDownList.SelectedValue
      Case "CA"
        selectedValue = "CA"
      Case "HI"
        selectedValue = "HI"
      Case "WA"
        selectedValue = "WA"
      Case Else
        ' Invalid value.
    End Select

    PeopleDataSource.XPath = "/People/Person[Address/Region='" & selectedValue & "']"
  End If

  PeopleTreeView.DataBind()
End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <table border="0" cellpadding="3">
        <tr>
          <td valign="top">
            <b>Select Region:</b>
            <asp:DropDownList runat="server" id="RegionDropDownList" AutoPostBack="True"
                              OnSelectedIndexChanged="SelectRegion">                              
              <asp:ListItem Selected="True">(Show All)</asp:ListItem>
              <asp:ListItem>CA</asp:ListItem>
              <asp:ListItem>HI</asp:ListItem>
              <asp:ListItem>WA</asp:ListItem>
            </asp:DropDownList>
          </td>
          <td valign="top">
            <asp:XmlDataSource
              id="PeopleDataSource"
              runat="server"
              XPath="/People/Person"
              DataFile="~/App_Data/people.xml" />

            <asp:TreeView
              id="PeopleTreeView"
              runat="server"
              DataSourceID="PeopleDataSource">
              <DataBindings>
                <asp:TreeNodeBinding DataMember="LastName"    TextField="#InnerText" />
                <asp:TreeNodeBinding DataMember="FirstName"   TextField="#InnerText" />
                <asp:TreeNodeBinding DataMember="Street"      TextField="#InnerText" />
                <asp:TreeNodeBinding DataMember="City"        TextField="#InnerText" />
                <asp:TreeNodeBinding DataMember="Region"      TextField="#InnerText" />
                <asp:TreeNodeBinding DataMember="ZipCode"     TextField="#InnerText" />
                <asp:TreeNodeBinding DataMember="Title"       TextField="#InnerText" />
                <asp:TreeNodeBinding DataMember="Description" TextField="#InnerText" />
              </DataBindings>
            </asp:TreeView>
          </td>
        </tr>
      </table>
    </form>
  </body>
</html>
<!-- </Snippet2> -->