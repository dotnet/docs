<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LinqDataSource OnInserting="LinqDataSource_Inserting" ID="LinqDataSource1" ContextTypeName="ExampleDataContext" TableName="Products" runat="server">
        </asp:LinqDataSource>
    </div>
    	
    </form>
</body>
</html>
