<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsView EmptyDataTemplate Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>DetailsView EmptyDataTemplate Example</h3>
                
        <asp:detailsview id="StoresDetailView"
          datasourceid="StoresDetailsSqlDataSource"
          autogeneraterows="true" 
          EmptyDataText="No records." 
          runat="server">
               
          <emptydatarowstyle backcolor="Navy"
            forecolor="Red"/>
            
          <emptydatatemplate>
          
            <table width="100%">
            
              <tr>
                <td>
                  <asp:Image id="NoRecordsImage"
                    AlternateText='No Records' 
                    imageurl="~\images\NoRecords.jpg"
                    runat="server"/> 
                </td>
                <td>
                  <asp:Label id="NoRecordsMessageLabel"
                    forecolor="Red"
                    text="No records."
                    runat="server"/> 
                </td>
              </tr>
            
            </table>
          
          </emptydatatemplate> 
                    
        </asp:detailsview>
            
        <!-- This example uses Microsoft SQL Server and connects -->
        <!-- to the Pubs sample database.                        -->
        
        <!-- The select query of the following SqlDataSource     -->
        <!-- control has been intentionally set to return no     --> 
        <!-- results to demonstrate the empty data row.          -->      
        <asp:sqldatasource id="StoresDetailsSqlDataSource"  
          selectcommand="SELECT [stor_id], [stor_name], [stor_address], [city], [state], [zip] FROM [stores] WHERE [state]='FL'"
          connectionstring="server=localhost;database=pubs;integrated security=SSPI"
          runat="server">
        </asp:sqldatasource>
            
      </form>
  </body>
</html>

<!-- </Snippet1> -->