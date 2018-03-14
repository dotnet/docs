<%@ Page AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<Snippet25>--%>
    <script language="javascript" type="text/javascript">

        //Call the web service to get changed prices.
        function UpdatePrices() {
            var pricesService = new PriceWebService();
            pricesService.GetPrices(onSuccess, onFailure, null);
            setTimeout('UpdatePrices()', 5000);
        }

        //Update the web page after a successful web service call.
        function onSuccess(result) {
            for (var i = 0; i < result.length; i++) {
                $get("ListView1_PriceLabel_" + result[i].ProductID).innerHTML = 
                    "<b>" + result[i].ListPrice.toFixed(2) + "</b>";
            }
        }

        function onFailure(results) {
            alert('failed');
        }

    </script>
    <%--</Snippet25>--%>
</head>
<%--<Snippet24>--%>
<body onload="setTimeout('UpdatePrices()', 5000)">
    <%--</Snippet24>--%>
    <form id="form1" runat="server">
    <div>
        <%-- <Snippet22> --%>
        <table>
            <tr>
                <th>Product ID</th>
                <th>Product Name</th>
                <th>List Price</th>
            </tr>
            <asp:ListView ID="ListView1" runat="server" 
                DataSourceID="SqlDataSource1" 
                ClientIDMode="Predictable"
                ClientIDRowSuffix="ProductID">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ProductID") %></td>
                        <td><%# Eval("Name") %></td>
                        <td align="right">
                            <asp:Label ID="PriceLabel" runat="server" 
                            Text='<%# Eval("ListPrice","{0:#.00}") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <div id="itemPlaceholderContainer" runat="server">
                        <span id="itemPlaceholder" runat="server" />
                    </div>
                </LayoutTemplate>
            </asp:ListView>
        </table>
        <%-- </Snippet22> --%>
    </div>
        <%--<Snippet21>--%>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AdventureWorksLTConnectionString %>"
            SelectCommand="SELECT ProductID, Name, ListPrice FROM SalesLT.Product">
        </asp:SqlDataSource>
        <%--</Snippet21>--%>
        <%--<Snippet23>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
            <asp:servicereference Path="PriceWebService.asmx" />
        </Services>
    </asp:ScriptManager>
        <%--</Snippet23>--%>
    </form>
</body>
</html>
