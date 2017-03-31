<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default2.aspx.vb" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!-- <Snippet2> -->
        <asp:LinqDataSource 
          ContextTypeName="ExampleDataContext" 
          TableName="Products" 
          EnableInsert="true" 
          ID="LinqDataSource1" 
          runat="server">
        </asp:LinqDataSource>
        <asp:DetailsView 
          DataSourceID="LinqDataSource1" 
          AllowPaging="true" 
          ID="DetailsView1" 
          runat="server">
        </asp:DetailsView>
        New product name:<br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:button ID="Button1" 
          Text="Add new product with default values" 
          runat="server" 
		  onclick="Add_Click" />
		<!-- </Snippet2> -->
    </div>
    </form>
</body>
</html>
