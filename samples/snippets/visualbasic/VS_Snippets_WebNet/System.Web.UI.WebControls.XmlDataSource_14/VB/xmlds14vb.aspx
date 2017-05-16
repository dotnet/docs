<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>Order</title>
</head>
<body> 
    <form id="form1" runat="server">
      <asp:XmlDataSource
        runat="server"
        id="XmlDataSource1"
        XPath="orders/order"
        DataFile="order.xml" />

      <asp:Repeater ID="Repeater1"
        runat="server"
        DataSourceID="XmlDataSource1">
        <ItemTemplate>
            <h2>Order</h2>
            <table>
              <tr>
                <td>Customer</td>
                <td><%#XPath("customer/@id")%></td>
                <td><%#XPath("customername/firstn")%></td>
                <td><%#XPath("customername/lastn")%></td>
              </tr>
              <tr>
                <td>Ship To</td>
                <td><%#XPath("shipaddress/address1")%></font></td>
                <td><%#XPath("shipaddress/city")%></td>
                <td><%#XPath("shipaddress/state")%>,
                    <%#XPath("shipaddress/zip")%></td>
              </tr>
            </table>
            <h3>Order Summary</h3>
            <asp:Repeater ID="Repeater2"
                 DataSource='<%#XPathSelect("summary/item")%>'
                 runat="server">
                <ItemTemplate>
                     <b><%#XPath("@dept")%></b> -
                         <%#XPath(".")%><br />
                </ItemTemplate>
            </asp:Repeater>
            <hr />
        </ItemTemplate>
    </asp:Repeater>

  </form>
  </body>
</html>
<!-- </Snippet1> -->