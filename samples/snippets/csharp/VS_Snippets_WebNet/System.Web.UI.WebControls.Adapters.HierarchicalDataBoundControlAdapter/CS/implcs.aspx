<!--<Snippet4>-->
<%@ page language="c#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HierarchicalDataBoundControl Adapter</title>
</head>
<body>
    <form id="Form1" runat="server">
        <asp:TreeView ID="TreeView1" 
            Runat="server" 
            DataSourceID="XmlDataSource1">

            <DataBindings>
                <asp:TreeNodeBinding    
                    DataMember="employees" Text="Employees"/>
                <asp:TreeNodeBinding    
                    DataMember="employee" TextField="id" />
                <asp:TreeNodeBinding    
                    DataMember="name" TextField="fullname" />
            </DataBindings>
        </asp:TreeView>
        
        <asp:XmlDataSource ID="XmlDataSource1"  
            Runat="server" 
            DataFile="employees.xml" />
        <br />
    </form>
</body>
</html>
<!--</Snippet4>-->
