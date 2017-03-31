<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!-- <Snippet1> -->
        <asp:Literal ID="Literal1" runat="server"></asp:Literal> Total Records
        <br />
        <asp:LinqDataSource 
          AutoPage="true"
          ID="LinqDataSource1" 
          runat="server" 
          ContextTypeName="ExampleDataContext" 
          TableName="Customers">
        </asp:LinqDataSource>
        <asp:GridView 
          ID="GridView1" 
          runat="server" 
          AllowPaging="true" 
          AutoGenerateColumns="True" 
          DataKeyNames="CustomerID" 
          DataSourceID="LinqDataSource1">
        </asp:GridView>
        <!-- </Snippet1> -->
    </div>
    </form>
</body>
</html>
