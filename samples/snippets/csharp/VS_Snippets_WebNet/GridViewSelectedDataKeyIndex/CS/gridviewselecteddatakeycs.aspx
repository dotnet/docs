<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>Selecting Data Key Values</title>
</head>
<body>
  <form id="form1" runat="server">
  <div>
    <asp:SqlDataSource 
      ID="SqlDataSource1" 
      runat="server" 
      ConnectionString="<%$ ConnectionStrings:NorthWindConnectionString%>"
      ProviderName="System.Data.SqlClient" 
      SelectCommand="SELECT * FROM [Order Details]">
    </asp:SqlDataSource>

    <asp:SqlDataSource 
      ID="SqlDataSource2" 
      runat="server" 
      ConnectionString="<%$ ConnectionStrings:NorthWindConnectionString%>"
      ProviderName="System.Data.SqlClient" 
      SelectCommand="SELECT * FROM [Products]WHERE [ProductID] = @productid">
      <SelectParameters>
        <asp:ControlParameter 
          Name="productid" 
          ControlID="GridView1" 
          PropertyName="SelectedDataKey[1]" />
      </SelectParameters>
    </asp:SqlDataSource>
    
  </div>

  <asp:GridView 
    ID="GridView1" 
    runat="server" 
    AllowPaging="True" 
    AutoGenerateColumns="False"
    DataKeyNames="OrderID,ProductID" DataSourceID="SqlDataSource1">
    <Columns>
      <asp:CommandField ShowSelectButton="True" />
      <asp:BoundField DataField="OrderID" HeaderText="OrderID" ReadOnly="True"/>
      <asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True" />
      <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" />
      <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
      <asp:BoundField DataField="Discount" HeaderText="Discount" />
      </Columns>
    </asp:GridView>
    <br />
    <asp:DetailsView 
      ID="DetailsView1" 
      runat="server" 
      AutoGenerateRows="False" 
      DataKeyNames="ProductID"
      DataSourceID="SqlDataSource2" 
      Height="50px" Width="125px">
      <Fields>
        <asp:BoundField 
          DataField="ProductID" 
          HeaderText="ProductID" 
          InsertVisible="False"
          ReadOnly="True" />
        <asp:BoundField DataField="ProductName" HeaderText="ProductName"/>
        <asp:BoundField DataField="SupplierID" HeaderText="SupplierID"/>
        <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" />
        <asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" />
        <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" />
        <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" />
        <asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder" />
        <asp:BoundField DataField="ReorderLevel" HeaderText="ReorderLevel" />
        <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" />
      </Fields>
    </asp:DetailsView>
  </form>
</body>
</html>

<!-- </Snippet1> -->