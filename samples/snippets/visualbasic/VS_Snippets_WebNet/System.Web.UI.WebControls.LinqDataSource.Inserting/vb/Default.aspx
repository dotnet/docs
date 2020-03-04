<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <asp:LinqDataSource ID="LinqDataSource1" ContextTypeName="ExampleDataContext" TableName="Products" OnInserting="LinqDataSource_Inserting" runat="server">
    </asp:LinqDataSource>
    <asp:DetailsView DataSourceID="LinqDataSource1" ID="DetailsView1" runat="server" Height="50px" Width="125px">
    </asp:DetailsView>
   </div>
    
    </form>
</body>
</html>
