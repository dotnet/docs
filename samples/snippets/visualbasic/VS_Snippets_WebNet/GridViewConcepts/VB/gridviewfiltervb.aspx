<!--<Snippet2>-->
<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>Northwind Employees</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>Northwind Employees</h3>

        <table cellspacing="10">            
          <tr>
            <td valign="top">
              <table border="0">
                <tr>
                  <td valign="top">Country</td>
                  <td><asp:DropDownList runat="server" id="CountryListBox" AppendDataBoundItems="True"
                                        DataSourceID="CountrySqlDataSource" 
                                        DataTextField="Country" DataValueField="Country" >
                        <asp:ListItem Selected="True" Value="" >(Show All)</asp:ListItem>
                      </asp:DropDownList>
                  </td>
                </tr>
                <tr>
                  <td>Last Name</td>
                  <td><asp:TextBox runat="server" id="LastNameTextBox" Text="*" /></td>
                </tr>
                <tr>
                  <td></td>
                  <td><asp:Button runat="server" id="FilterButton" Text="Filter Results" /></td>
                </tr>
              </table>
            </td>

            <td valign="top">                
              <asp:GridView ID="EmployeesGridView"
                DataSourceID="EmployeeDetailsSqlDataSource"
                AutoGenerateColumns="false"
                AllowSorting="True"
                DataKeyNames="EmployeeID"     
                Gridlines="Both"
                RunAt="server">
                
                <HeaderStyle backcolor="Navy"
                  forecolor="White"/>
                  
                <RowStyle backcolor="White"/>
                
                <AlternatingRowStyle backcolor="LightGray"/>
                
                <EditRowStyle backcolor="LightCyan"/>
              
                <Columns>                  
                  <asp:BoundField DataField="EmployeeID" HeaderText="Employee ID" ReadOnly="true"/>                    
                  <asp:BoundField DataField="FirstName"  HeaderText="First Name"/>
                  <asp:BoundField DataField="LastName"   HeaderText="Last Name"/>                    
                  <asp:BoundField DataField="Country"    HeaderText="Country"/>                    
                </Columns>                 
              </asp:GridView>
            </td>                
          </tr>            
        </table>
            
        <asp:SqlDataSource ID="CountrySqlDataSource" 
          SelectCommand="SELECT DISTINCT Country FROM Employees"
          EnableCaching="True"
          CacheDuration="60"
          ConnectionString="<%$ ConnectionStrings:NorthwindConnection %>"
          RunAt="server" />

        <asp:SqlDataSource ID="EmployeeDetailsSqlDataSource" 
          SelectCommand="SELECT EmployeeID, LastName, FirstName, Country FROM Employees"
          EnableCaching="True"
          CacheDuration="60"
          ConnectionString="<%$ ConnectionStrings:NorthwindConnection %>"
          FilterExpression="Country LIKE '{0}' AND LastName LIKE '{1}'"
          RunAt="server">

          <FilterParameters>
            <asp:ControlParameter ControlID="CountryListBox"   PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="LastNameTextBox" PropertyName="Text" />
          </FilterParameters>
        </asp:SqlDataSource>
      </form>
  </body>
</html>
<!--</Snippet2>-->
