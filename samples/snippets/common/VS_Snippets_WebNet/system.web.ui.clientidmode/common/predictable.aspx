<%@ Page AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

<!-- <Snippet11> -->
<asp:XmlDataSource ID="XmlDataSource1" runat="server" 
                   XPath="Products/Product">
  <Data>
    <Products>
      <Product ProductID="1"  ProductName="Chai" />
      <Product ProductID="34" ProductName="Ale" />
      <Product ProductID="43" ProductName="Coffee" />
    </Products>
  </Data>
</asp:XmlDataSource>

<asp:ListView ID="ListView1" 
              ClientIDMode="Predictable" 
              ClientIDRowSuffix="ProductID"  
              DataSourceID="XmlDataSource1" runat="server" >
  <ItemTemplate>
    ProductID: 
    <asp:Label ID="ProductIDLabel" runat="server" 
               Text='<%# Eval("ProductID") %>' />
    <br />
    ProductName:
    <asp:Label ID="ProductNameLabel" runat="server" 
               Text='<%# Eval("ProductName") %>' />
    <br />
    <br />
  </ItemTemplate>

  <LayoutTemplate>
    <div ID="itemPlaceholderContainer" runat="server">
      <span ID="itemPlaceholder" runat="server" />
    </div>
    <div>
    </div>
  </LayoutTemplate>
  
</asp:ListView>
<!-- </Snippet11> -->
    
    </div>
    </form>
</body>
</html>
