<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
<form id="Form1" runat="server">
<asp:DataList id = "DataList1"
    RepeatLayout = "Table"
    RepeatDirection = "Horizontal"
    RepeatColumns = "5"
    GridLines = "Both"
    runat = "server">
    <HeaderTemplate>
    Items
    </HeaderTemplate>
    <ItemTemplate>
    
<!--<Snippet1>-->

<%# DataBinder.Eval(Container.DataItem, "Price") %>

<!--</Snippet1>-->

<!--<Snippet2>-->

<%# DataBinder.GetIndexedPropertyValue(Container.DataItem, "[0][0]", "{0:c}") %> 

<!--</Snippet2>-->

    </ItemTemplate>
    </asp:DataList>
    <br />
</form>
</body>
</html>
