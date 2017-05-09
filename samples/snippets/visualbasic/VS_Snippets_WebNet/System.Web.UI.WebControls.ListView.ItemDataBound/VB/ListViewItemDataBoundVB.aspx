<%-- <Snippet1> --%>

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    ' <Snippet2>
    Protected Sub ContactsListView_ItemDataBound(ByVal sender As Object, _
                                                 ByVal e As ListViewItemEventArgs)
  
        If e.Item.ItemType = ListViewItemType.DataItem Then
            ' Display the e-mail address in italics.
            Dim EmailAddressLabel As Label = _
              CType(e.Item.FindControl("EmailAddressLabel"), Label)
            EmailAddressLabel.Font.Italic = True

            Dim rowView As System.Data.DataRowView
            rowView = CType(e.Item.DataItem, System.Data.DataRowView)
            Dim currentEmailAddress As String = rowView("EmailAddress").ToString()
            If currentEmailAddress = "orlando0@adventure-works.com" Then
                EmailAddressLabel.Font.Bold = True
            End If
        End If
        
    End Sub
    ' </Snippet2>

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ListView ItemDataBound Example</title>
</head>
<body style="font: 10pt Trebuchet MS">
    <form id="form1" runat="server">
    <h3>
        ListView ItemDataBound Example</h3>
    <asp:ListView ID="ContactsListView" DataSourceID="ContactsDataSource" ConvertEmptyStringToNull="true"
        OnItemDataBound="ContactsListView_ItemDataBound" runat="server">
        <layouttemplate>
          <table cellpadding="2" width="680px" border="0">
            <tr style="background-color: #ADD8E6" runat="server">
                <th runat="server">First Name</th>
                <th runat="server">Last Name</th>
                <th runat="server">E-mail Address</th>
            </tr>
            <tr runat="server" id="itemPlaceholder" />
          </table>
          <asp:DataPager runat="server" ID="PeopleDataPager" PageSize="12">
            <Fields>
              <asp:NumericPagerField ButtonCount="10" /> 
            </Fields>
          </asp:DataPager>
        </layouttemplate>
        <itemtemplate>
          <tr style="background-color: #CAEEFF" runat="server">
            <td>
              <asp:Label ID="FirstNameLabel" runat="server" Text='<%#Eval("FirstName") %>' />
            </td>
            <td>
              <asp:Label ID="LastNameLabel" runat="server" Text='<%#Eval("LastName") %>' />
            </td>
            <td>
              <asp:Label ID="EmailAddressLabel" runat="server" Text='<%#Eval("EmailAddress") %>' />
            </td>
          </tr>
        </itemtemplate>
    </asp:ListView>
    <!-- This example uses Microsoft SQL Server and connects      -->
    <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
    <!-- expression to retrieve the connection string value       -->
    <!-- from the Web.config file.                                -->
    <asp:SqlDataSource ID="ContactsDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:AdventureWorksConnectionString %>"
        SelectCommand="SELECT FirstName, LastName, EmailAddress FROM SalesLT.Customer">
    </asp:SqlDataSource>
    </form>
</body>
</html>
<%-- </Snippet1> --%>