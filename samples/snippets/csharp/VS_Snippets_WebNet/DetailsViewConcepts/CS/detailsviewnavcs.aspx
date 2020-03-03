<!-- <Snippet2> -->
<%@ Page language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsView Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <h3>DetailsView Example</h3>
        <table cellspacing="10"> 
          <tr>               
            <td valign="top">
                
              <asp:DetailsView ID="EmployeesDetailsView"
                DataSourceID="EmployeesSqlDataSource"
                AutoGenerateRows="false"
                AllowPaging="true"
                DataKeyNames="EmployeeID"     
                runat="server">

                <HeaderStyle forecolor="white" backcolor="Blue" />                
       
                <Fields>
                  <asp:BoundField Datafield="EmployeeID" HeaderText="Employee ID" ReadOnly="true"/>                    
                  <asp:BoundField Datafield="FirstName"  HeaderText="First Name"/>
                  <asp:BoundField Datafield="LastName"   HeaderText="Last Name"/>                    
                </Fields>

                <PagerSettings Mode="NextPreviousFirstLast"
                               FirstPageText="<<"
                               LastPageText=">>"
                               PageButtonCount="1"  
                               Position="Top"/> 
              </asp:DetailsView>
            
            </td>
          </tr>
        </table>
   
        <asp:SqlDataSource ID="EmployeesSqlDataSource" 
          SelectCommand="SELECT * FROM [Employees]" 
          connectionstring="<%$ ConnectionStrings:NorthwindConnection %>" 
          RunAt="server"/>

      </form>
  </body>
</html>
<!-- </Snippet2> -->