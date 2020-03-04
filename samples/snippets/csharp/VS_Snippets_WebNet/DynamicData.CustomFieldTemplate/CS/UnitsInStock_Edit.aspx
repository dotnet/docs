<!-- <Snippet7> -->
<%@ Page Language="C#" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Site.css" rel="stylesheet" type="text/css" />
    <script runat="server">
        protected MetaTable _table;
            
       
        protected void Page_Init(object sender, EventArgs e) {
            // Register control with the data manager for complete
            // data base access such as column names, keys, etc...
            DynamicDataManager1.RegisterControl(GridView1);
        }

        // Get run-time table information.
        protected void Page_Load(object sender, EventArgs e) {
            _table = GridDataSource.GetTable();
            Title = _table.DisplayName + " Custom Edit Field Template";
            
        }
 </script>
</head>
<body>
    <h2>Example: Customize <i>UnitsInStock</i> Data Field Editing </h2>
    
    The <i>UnitsInStock</i> column in the <%=_table.DisplayName%> table
    is handled by a custom field template which assures that the value             entered by the user is in the allowed range. This range is [100, 10000]
    and is set by <b>RangeAttribute</b> in the Product data model class.
       
     <!-- Enable dynamic behavior of the data controls. -->
     <asp:DynamicDataManager ID="DynamicDataManager1" runat="server"
         AutoLoadForeignKeys="true" />
  
    <form id="form1" runat="server">
        <!-- Enable communication with server without 
        full page postback -->
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
             EnablePartialRendering="true" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" > 
            <ContentTemplate>         
                <asp:GridView ID="GridView1" 
                    runat="server" 
                    DataSourceID="GridDataSource" 
                    AutoGenerateColumns="false" 
                    AllowPaging="true" AllowSorting="true"
                    AutoGenerateEditButton="true">
                    <Columns>
                        <asp:DynamicField DataField="ProductName" />
                        <asp:DynamicField DataField="UnitsInStock" />
                        <asp:DynamicField DataField="Category" />
                    </Columns>
                    <EmptyDataTemplate>
                        There are currently no items in this table.
                    </EmptyDataTemplate>
                </asp:GridView>
            </ContentTemplate> 
        </asp:UpdatePanel> 
    </form>
    
    <!-- Connect to the database. -->
    <asp:LinqDataSource ID="GridDataSource" runat="server"  
        EnableUpdate="true" TableName="Products" 
        ContextTypeName="NorthwndDataContext">
    </asp:LinqDataSource>
</body>
</html>
<!-- </Snippet7> -->