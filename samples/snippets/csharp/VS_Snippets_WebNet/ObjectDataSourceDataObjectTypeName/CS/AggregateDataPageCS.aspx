<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS" Assembly="Samples.AspNet.CS" %>
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"> 

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ObjectDataSource - DataObjectTypeName Property Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DetailsView 
            ID="DetailsView1" 
            runat="server" 
            AllowPaging="True" 
            AutoGenerateInsertButton="True"
            DataSourceID="ObjectDataSource1" 
            Height="50px" 
            Width="125px">
        </asp:DetailsView>
        <asp:ObjectDataSource 
            ID="ObjectDataSource1" 
            runat="server" 
            DataObjectTypeName="Samples.AspNet.CS.NewData"
            InsertMethod="Insert" 
            SelectMethod="Select" 
            TypeName="Samples.AspNet.CS.AggregateData">
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
