  <asp:ListView 
      DataSourceID="LinqDataSource1" 
      ID="ListView1" runat="server">

      <LayoutTemplate>
        <table id="Table1" 
            style="background-color:Teal;color:White" 
            runat="server" 
            class="Layout">
            
          <thead>
            <tr>
              <th><b>Product Category</b></th>
              <th><b>Color</b></th>
              <th><b>Highest Price</b></th>
              <th><b>Lowest Price</b></th>
            </tr>
          </thead>
          <tr runat="server" id="itemPlaceholder">
          </tr>
          
        </table>
      </LayoutTemplate>

      <ItemTemplate>
        <tr>
          <td><%# Eval("key.ProductCategory") %></td>
          <td><%# Eval("key.Color") %></td>
          <td><%# Eval("MaxListPrice") %></td>
          <td><%# Eval("MinListPrice") %></td>
        </tr>
        <tr>
          
          <td colspan="4" style="width:100%;background-color:White;color:Black">
            <asp:ListView 
              DataSource='<%# Eval("Products") %>' 
              runat="server" 
              ID="ListView2">

              <LayoutTemplate>
                <div runat="server" id="itemPlaceholder" />
              </LayoutTemplate>

              <ItemTemplate>
                <%# Eval("ProductName") %><br />
              </ItemTemplate>

            </asp:ListView> 
          </td>
        </tr>
      </ItemTemplate>
    </asp:ListView>