<%@ Page language="VB" %>

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

<!--<Snippet4>-->  
<asp:DetailsView ID="DetailsView1"
  DataSourceID="SqlDataSource1"  
  RunAt="Server" />     
<!--</Snippet4>-->  
            
            </td>

            <td valign="top">

<!--<Snippet5>-->  
<asp:DetailsView ID="DetailsView2"
  DataSourceID="SqlDataSource1"
  AutoGenerateRows="false"
  DataKeyNames="EmployeeID"     
  RunAt="Server">     
  <Fields>
   <asp:BoundField DataField="EmployeeID" HeaderText="Employee ID" readonly="true"/>                    
   <asp:BoundField DataField="FirstName"  HeaderText="First Name"/>
   <asp:BoundField DataField="LastName"   HeaderText="Last Name"/>                    
  </Fields>                  
</asp:DetailsView>
<!--</Snippet5>-->  
            
            </td>
                
          </tr>
            
        </table>
            
<!--<Snippet3>-->  
<asp:SqlDataSource ID="SqlDataSource1" 
  SelectCommand="SELECT * FROM [Employees]"
  ConnectionString="<%$ ConnectionStrings:NorthwindConnection %>"
  RunAt="server">
</asp:SqlDataSource>
<!--</Snippet3>-->
            
      </form>
  </body>
</html>
