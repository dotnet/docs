    <form id="form1" runat="server">
    
        <asp:objectdatasource
          ID="ObjectDataSource1"
          runat="server"
          SelectMethod="GetFullNamesAndIDs"
          TypeName="Samples.AspNet.CS.EmployeeLogic" />

        <p>
        <asp:dropdownlist
          ID="DropDownList1"
          runat="server" 
          DataSourceID="ObjectDataSource1"
          DataTextField="FullName"
          DataValueField="EmployeeID" 
          AutoPostBack="True" 
          AppendDataBoundItems="true">
            <asp:ListItem Text="Select One" Value=""></asp:ListItem>
        </asp:dropdownlist>
        </p>

        <asp:objectdatasource
          ID="ObjectDataSource2"
          runat="server"
          SelectMethod="GetEmployee"
          UpdateMethod="UpdateEmployeeAddress"
          OnUpdating="EmployeeUpdating"
          OnSelected="EmployeeSelected"
          TypeName="Samples.AspNet.CS.EmployeeLogic" >
          <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" DefaultValue="-1" Name="empID" />
          </SelectParameters>
        </asp:objectdatasource>
        
        <asp:DetailsView
            ID="DetailsView1"
            runat="server"
            DataSourceID="ObjectDataSource2" 
            AutoGenerateRows="false"
            AutoGenerateEditButton="true">  
            <Fields>
                <asp:BoundField HeaderText="Address" DataField="Address" />
                <asp:BoundField HeaderText="City" DataField="City" />
                <asp:BoundField HeaderText="Postal Code" DataField="PostalCode" />
            </Fields>  
        </asp:DetailsView>
       
    </form>