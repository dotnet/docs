        <asp:SqlDataSource 
            ID="SqlDataSource1" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT Count(*) FROM [Products] WHERE ([ReorderLevel] &gt; 0)">
        </asp:SqlDataSource>
        <asp:Label 
            ID="Label1" 
            runat="server" 
            Text="">
        </asp:Label>
        <br />
        <asp:Button 
           ID="Button1" 
           Text="Check Reorder Status" 
           runat="server" 
           onclick="Button1_Click" />