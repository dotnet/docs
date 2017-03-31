<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="ASPSample" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
protected void  Page_Load(object sender, EventArgs e)
{
        // Create and populate an ArrayList to store the products.
        ArrayList ProductList = new ArrayList();
        ProductList.Add(new Product("Standard", 99.95));
        ProductList.Add(new Product("Deluxe", 159.95));

        // Bind the array list to Repeater
        ListRepeater.DataSource = ProductList;
        ListRepeater.DataBind();
}
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>DataBinder Example</title>
</head>
<body>
<form id="Form2" runat="server">
<table>
<asp:Repeater id="ListRepeater" runat="server">
    <HeaderTemplate>
	<tr>
		<th style="width:50; text-align:left">Model</th>
		<th style="width:100; text-align:right">Unit Price</th>
	</tr>
	</HeaderTemplate>
	<ItemTemplate>
    <tr>
        <!-- Databind to the Product information using the DataBinder methods. 
             The Container.DataItem refers to the ArrayList object bound to 
             the ASP:Repeater in the Page Load event. -->
	    <td>
	        <%#DataBinder.GetPropertyValue(Container.DataItem, "Model")%>
	    </td>
	    <!-- Format the UnitPrice as currency. ({0:c}) -->
	    <td style="text-align:right">
	        <%#DataBinder.GetPropertyValue(Container.DataItem,
	                     "UnitPrice", "{0:c}")%>
	    </td>
    </tr>
	</ItemTemplate>
</asp:Repeater>
</table>
</form>
</body>
</html>
<!-- </Snippet1> -->