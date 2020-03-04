<!-- <Snippet3> -->
<%@ Page Language="VB" 
AutoEventWireup="true" CodeFile="CustomValidation.aspx.vb" 
Inherits="CustomValidation" %>


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
        <asp:DynamicValidator ID="DynamicValidator1" ControlToValidate="GridView2" 
            runat="server" /> 
        <table>
            <tr>
                <td align="left" valign="top" style="font-weight:bold">
                    Customize Validation Using the Table OnValidate 
                </td>
                <td>
                    <asp:GridView ID="GridView1" 
                        runat="server" 
                        DataSourceID="GridDataSource" 
                        AutoGenerateColumns="false"  
                        AutoGenerateEditButton="true"
                        AllowPaging="true" 
                        PageSize="5"
                        AllowSorting="true">
                        <Columns>
                            <asp:DynamicField DataField="Title" />
                            <asp:DynamicField DataField="FirstName" />
                            <asp:DynamicField DataField="LastName" />
                        </Columns>
                        <EmptyDataTemplate>
                            There are currently no items in this table.
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" style="font-weight:bold">
                    Customize Validation Using OnOrderQtyChanging
                </td>
                <td>
                    <asp:GridView ID="GridView2" 
                        runat="server" 
                        DataSourceID="GridDataSource2" 
                        AutoGenerateColumns="false"  
                        AutoGenerateEditButton="true"
                        AllowPaging="true" 
                        PageSize="5"
                        AllowSorting="true">
                        <Columns>
                            <asp:DynamicField DataField="OrderQty" />
                        </Columns>
                        <EmptyDataTemplate>
                            There are currently no items in this table.
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
        </table>
       
    </form>
    
    <!-- Connect to the database -->
    <asp:LinqDataSource ID="GridDataSource" runat="server"  
         TableName="Customers" EnableUpdate="true"
        ContextTypeName="AdventureWorksLTDataContext">
        
    </asp:LinqDataSource>
    
     <!-- Connect to the database -->
    <asp:LinqDataSource ID="GridDataSource2" runat="server"  
         TableName="SalesOrderDetails" EnableUpdate="true"
        ContextTypeName="AdventureWorksLTDataContext">
        
    </asp:LinqDataSource>
</body>
</html>
<!-- </Snippet3> -->