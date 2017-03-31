<!-- <snippet4> -->
<asp:Repeater ID="ProductList" runat="server">
    <ItemTemplate>
        <%# Eval("Name") %> for only <%# Eval("Price", "{0:c}") %>
        <br />
        <a href='<%# Eval("ProductID", "details.asp?id={0}") %>'>See Details</a>
        <br />
        <br />
    </ItemTemplate>
</asp:Repeater>
<!-- </snippet4> -->