<!-- <Snippet3> -->
<%@ Page Language="C#" 
AutoEventWireup="true" CodeFile="CustomAttributeValidation.aspx.cs" 
Inherits="CustomAttributeValidation" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
     <h2>Example: <%=Title%></h2>
     
     <!-- Enable dynamic behavior. The GridView must be 
     registered with the manager. See code-behind file. -->
    <asp:DynamicDataManager ID="DynamicDataManager1" runat="server"
        AutoLoadForeignKeys="true" />
   
        
    <form id="form1" runat="server">
    
        <!-- Capture validation exceptions -->
        <asp:DynamicValidator ID="ValidatorID" ControlToValidate="GridView1" 
            runat="server" /> 
   
        <asp:GridView ID="GridView1" 
            runat="server" 
            DataSourceID="GridDataSource" 
            AutoGenerateColumns="false"  
            AutoGenerateEditButton="true"
            AllowPaging="true"
            PageSize="10"
            AllowSorting="true">
            <Columns>
                <asp:DynamicField DataField="FirstName" />
                <asp:DynamicField DataField="LastName" />
                <asp:DynamicField DataField="Phone" />
            </Columns>
       </asp:GridView>
    </form>
    
    <!-- Connect to the database -->
    <asp:LinqDataSource ID="GridDataSource" runat="server"  
        TableName="Customers" EnableUpdate="true"
        ContextTypeName="AdventureWorksLTDataContext">
    </asp:LinqDataSource>
</body>
</html>
<!-- </Snippet3> -->