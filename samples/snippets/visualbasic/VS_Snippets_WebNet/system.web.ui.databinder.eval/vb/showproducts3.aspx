<!-- <snippet3> -->
<asp:Repeater ID="ProductList" runat="server">
    <ItemTemplate>
        <%# DataBinder.Eval(Container.DataItem, "Name") %> for only <%# DataBinder.Eval(Container.DataItem, "Price", "{0:c}") %>
        <br />
        <a href='<%# DataBinder.Eval(Container.DataItem, "ProductID", "details.asp?id={0}") %>'>See Details</a>
        <br />
        <br />
    </ItemTemplate>
</asp:Repeater>
<!-- </snippet3> -->