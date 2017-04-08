<!-- <Snippet4> -->
<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:XmlDataSource
        id="PeopleDataSource"
        runat="server"
        XPath="/People/Person"
        DataFile="~/App_Data/people.xml" />

      <asp:DataList
        id="PeopleDataList"
        DataSourceID="PeopleDataSource"
        Runat="server">

        <ItemTemplate>
          <table cellpadding="4" cellspacing="4">
            <tr>
              <td style="vertical-align:top; width:120">
                <asp:Label id="LastNameLabel" Text='<%# XPath("Name/LastName")%>' runat="server" />, 
                <asp:Label id="FirstNameLabel" Text='<%# XPath("Name/FirstName")%>' runat="server" />
              </td>
              <td valign="top">
                 <asp:Label id="StreetLabel" Text='<%# XPath("Address/Street") %>' runat="server" /><br />
                 <asp:Label id="CityLabel" Text='<%# XPath("Address/City") %>' runat="server" />, 
                 <asp:Label id="RegionLabel" Text='<%# XPath("Address/Region") %>' runat="server" />
                 <asp:Label id="ZipCodeLabel" Text='<%# XPath("Address/ZipCode") %>' runat="server" />
              </td>
            </tr>
          </table>
        </ItemTemplate>
      </asp:DataList>
    </form>
  </body>
</html>
<!-- </Snippet4> -->