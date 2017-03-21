  <Columns>                  
    <asp:BoundField DataField="EmployeeID" HeaderText="Employee ID" ReadOnly="true"/>                    
    <asp:BoundField DataField="FirstName"  HeaderText="First Name"/>
    <asp:BoundField DataField="LastName"   HeaderText="Last Name"/>                    
    <asp:TemplateField HeaderText="Birth Date">
      <ItemTemplate> 
        <asp:Label ID="BirthDateLabel" Runat="Server" 
                   Text='<%# Eval("BirthDate", "{0:d}") %>' />
      </ItemTemplate>
      <EditItemTemplate>
        <asp:Calendar ID="EditBirthDateCalendar" Runat="Server"
                      VisibleDate='<%# Eval("BirthDate") %>'
                      SelectedDate='<%# Bind("BirthDate") %>' />
      </EditItemTemplate>
    </asp:TemplateField> 
    <asp:HyperLinkField Text="Show Detail"
                        DataNavigateUrlFormatString="~/ShowEmployeeDetail.aspx?EmployeeID={0}"
                        DataNavigateUrlFields="EmployeeID" />                   
  </Columns> 