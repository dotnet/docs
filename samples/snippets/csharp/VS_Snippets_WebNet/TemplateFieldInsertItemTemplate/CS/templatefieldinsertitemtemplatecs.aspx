<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void StoresGridView_SelectedIndexChanged(Object sender, EventArgs e)
  {
    // Set the DataItemIndex property of the DetailsView control to display
    // the record selected from the GridView control.
   // StoresDetailView.DataItemIndex = StoresGridView.SelectedIndex;
  }
  
  void StoresDetailView_ItemInserting(Object sender, DetailsViewInsertEventArgs e)
  {
    // Get the state value from the DropDownList control in the 
    // DetailsView control.
    String state = GetState(); 
    
    // Add the state to the dictionary of values to 
    // insert into the database.
    e.Values["state"] = state;
  }
  
  void StoresDetailView_ItemInserted (Object sender, DetailsViewInsertedEventArgs e)
  {
    // Refresh the GridView control after a new record is inserted.
    StoresGridView.DataBind ();
  }
  
  String GetState()
  {
    String state;
    
    // Get the DropDownList control that contains the state value
    // in the DetailsView control.
    DropDownList list = (DropDownList)StoresDetailView.Rows[4].FindControl("StateList");
    
    if (list != null)
    {
      // Get the selected value of the DropDownList control.
      state = list.SelectedItem.Text;
    }
    else
    {
      // Set the state to an empty string ("").
      state = "";
    }
    
    return state;
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TemplateField InsertItemTemplate Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>TemplateField InsertItemTemplate Example</h3>

        <table cellspacing="10">
            
          <tr>
              
            <td>
                
              <asp:gridview id="StoresGridView" 
                datasourceid="StoresSqlDataSource" 
                autogeneratecolumns="false"
                autogenerateselectbutton="true"
                datakeynames="stor_id"
                onselectedindexchanged="StoresGridView_SelectedIndexChanged"   
                runat="server">
                
                <headerstyle backcolor="Blue"
                  forecolor="White"/>
                
                <columns>
                
                  <asp:boundfield datafield="stor_name"
                    headertext="Store Name"/>
                    
                  <asp:boundfield datafield="stor_address"
                    headertext="Address"/>
                    
                  <asp:boundfield datafield="city"
                    headertext="City"/>
                        
                  <asp:boundfield datafield="state"
                    headertext="State"/>
                    
                  <asp:boundfield datafield="zip"
                    headertext="ZIP Code"/>
                    
                </columns>
                
              </asp:gridview>
            
            </td>
                
            <td valign="top">
                
              <asp:detailsview id="StoresDetailView"
                datasourceid="StoresDetailsSqlDataSource"
                autogenerateinsertbutton="true"
                autogeneraterows="false" 
                datakeynames="stor_id"        
                gridlines="Both"
                oniteminserting="StoresDetailView_ItemInserting"
                oniteminserted="StoresDetailView_ItemInserted"    
                runat="server">
                
                <headerStyle backcolor="Navy"
                  forecolor="White"/>
                  <Fields>               
                  
                  <asp:boundfield datafield="stor_id"
                    headertext="Store ID"/>
                    
                  <asp:boundfield datafield="stor_name"
                    headertext="Store Name"/>
                    
                  <asp:boundfield datafield="stor_address"
                    headertext="Address"/>
                    
                  <asp:boundfield datafield="city"
                    headertext="City"/>
                        
                  <asp:templatefield headertext="State">
                    <itemtemplate>
                      <%#Eval("state")%>
                    </itemtemplate>
                    <insertitemtemplate>
                      <asp:dropdownlist id="StateList"
                        datasourceid="StateSqlDataSource"
                        datatextfield="state" 
                        runat="server"/>
                    </insertitemtemplate>
                  </asp:templatefield>
                    
                  <asp:boundfield datafield="zip"
                    headertext="ZIP Code"/>
                    
                </Fields>                    
              </asp:detailsview>
            
            </td>
                
          </tr>
            
        </table>
            
        <!-- This example uses Microsoft SQL Server and connects -->
        <!-- to the Pubs sample database.                        -->
        <asp:sqldatasource id="StoresSqlDataSource"  
          selectcommand="SELECT [stor_id], [stor_name], [stor_address], [city], [state], [zip] FROM [stores]" 
          connectionstring="server=localhost;database=pubs;integrated security=SSPI"
          runat="server">
        </asp:sqldatasource>
            
        <asp:sqldatasource id="StoresDetailsSqlDataSource"  
          selectcommand="SELECT [stor_id], [stor_name], [stor_address], [city], [state], [zip] FROM [stores]"
          insertcommand="INSERT INTO stores([stor_id], [stor_name], [stor_address], [city], [state], [zip]) VALUES (@stor_id, @stor_name, @stor_address, @city, @state, @zip)" 
          connectionstring="server=localhost;database=pubs;integrated security=SSPI"
          runat="server">
        </asp:sqldatasource>
        
        <!-- For this example, the states are retrieved from the  -->
        <!-- state field. For your application, you should use a  -->
        <!-- more complete source for the state values.           -->
        <asp:sqldatasource id="StateSqlDataSource"  
          selectcommand="SELECT Distinct [state] FROM [stores]"
          connectionstring="server=localhost;database=pubs;integrated security=SSPI"
          runat="server">
        </asp:sqldatasource>
            
      </form>
  </body>
</html>

<!-- </Snippet1> -->