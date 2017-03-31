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
              <asp:GridView ID="EmployeesGridView"
                DataSourceID="EmployeeDetailsSqlDataSource"
                AutoGenerateColumns="false"
                AutoGenerateEditButton="true"
                DataKeyNames="EmployeeID"     
                Gridlines="Both"
                RunAt="server">
                
                <HeaderStyle backcolor="Navy"
                  forecolor="White"/>
                  
                <RowStyle backcolor="White"/>
                
                <AlternatingRowStyle backcolor="LightGray"/>
                
                <EditRowStyle backcolor="LightCyan"/>

<%-- <Snippet1> --%>                  
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
<%-- </Snippet1> --%>                  
              </asp:GridView>
            </td>                
          </tr>            
        </table>
            
        <asp:SqlDataSource ID="EmployeeDetailsSqlDataSource" 
          SelectCommand="SELECT EmployeeID, LastName, FirstName, BirthDate FROM Employees"
          UpdateCommand="UPDATE Employees SET LastName=@LastName, FirstName=@FirstName, BirthDate=@BirthDate
                         WHERE EmployeeID=@EmployeeID"
          ConnectionString="<%$ ConnectionStrings:NorthwindConnection %>"
          RunAt="server">

          <UpdateParameters>
            <asp:Parameter Name="LastName"   Type="String" />
            <asp:Parameter Name="FirstName"  Type="String" />
            <asp:Parameter Name="BirthDate"  Type="DateTime" />
            <asp:Parameter Name="EmployeeID" Type="Int32" DefaultValue="0" />
          </UpdateParameters>

        </asp:SqlDataSource>
      </form>
  </body>
</html>

