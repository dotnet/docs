<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!-- <Snippet2> -->
        <!-- Retrieve and display data from array of string values -->
        <asp:LinqDataSource 
            ContextTypeName="MovieLibrary" 
            TableName="AvailableGenres" 
            ID="LinqDataSource1" 
            runat="server">
        </asp:LinqDataSource>
        <asp:DropDownList 
            DataSourceID="LinqDataSource1"
            runat="server" 
            ID="DropDownList1">
        </asp:DropDownList>
        
        <!-- Retrieve and display data from database -->
        <asp:LinqDataSource 
            ContextTypeName="ExampleDataContext" 
            TableName="Movies" 
            Select="Title"
            ID="LinqDataSource2" 
            runat="server">
        </asp:LinqDataSource>
        <asp:DropDownList 
            DataSourceID="LinqDataSource2"
            runat="server" 
            ID="DropDownList2">
        </asp:DropDownList>
         <!-- </Snippet2> -->
    </div>
    </form>
</body>
</html>
