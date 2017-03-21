        
	    <!-- Set the QueryableFilterRepeater control attributes. --> 
            <asp:QueryableFilterRepeater runat="server" ID="FilterRepeaterID">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("DisplayName") %>' />
                    <asp:DynamicFilter runat="server" ID="DynamicFilter" 
                        OnFilterChanged="OnFilterSelectionChanged"  /><br />
                </ItemTemplate>
            </asp:QueryableFilterRepeater>
           