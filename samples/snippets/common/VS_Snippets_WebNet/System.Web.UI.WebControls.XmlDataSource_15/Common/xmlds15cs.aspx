<!-- <Snippet1> -->
<%@ Page  %>
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
        DataFile="order.xml" >
        <Transform>
          <xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
          <xsl:template match="orders">
            <orders>
              <xsl:apply-templates select="order"/>
            </orders>
          </xsl:template>
          <xsl:template match="order">
            <order>
            <customer>
              <id>
                <xsl:value-of select="customer/@id"/>
              </id>
              <firstname>
                <xsl:value-of select="customername/firstn"/>
              </firstname>
              <lastname>
                <xsl:value-of select="customername/lastn"/>
              </lastname>
            </customer>
            </order>
          </xsl:template>
          </xsl:stylesheet>
        </Transform>
      </asp:XmlDataSource>

      <asp:Repeater
        runat="server"
        DataSourceID="XmlDataSource1">
        <ItemTemplate>
            <h2>Order</h2>
            <table border="1px">
              <tr>
                <td>Customer</td>
                <td style="color:Blue"><%# XPath ("//id") %></td>
                <td><%# XPath ("//firstname") %></td>
                <td><%# XPath ("//lastname") %></td>
              </tr>
            </table>
            <hr />
        </ItemTemplate>
    </asp:Repeater>

  </form>
  </body>
</html>
<!-- </Snippet1> -->