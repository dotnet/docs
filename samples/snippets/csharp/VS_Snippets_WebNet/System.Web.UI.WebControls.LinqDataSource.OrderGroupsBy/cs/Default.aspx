<%@ Page Language="C#" AutoEventWireup="true"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!-- <Snippet1> -->
        <asp:LinqDataSource 
           ContextTypeName="DataClassesDataContext" 
           TableName="Products" 
           GroupBy="new (CategoryID, Discontinued)" 
           OrderGroupsBy="Key.CategoryID"
           Select="new(Key.CategoryID, Key.Discontinued, Average(UnitPrice) As AvePrice)" 
           ID="LinqDataSource1" 
           runat="server" >
        </asp:LinqDataSource>
        <!-- </Snippet1> -->
    </div>
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True" 
        DataSourceID="LinqDataSource1">
    </asp:GridView>
    
    </form>
</body>
</html>
