<!-- <Snippet1> -->

<%@ Page language="C#" %>
<%@ import namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  void AuthorsGridView_RowDataBound (Object sender, GridViewRowEventArgs e)
  {
    // Check for a row in edit mode.
    if(e.Row.RowState == DataControlRowState.Edit)
    {
      // Preselect the DropDownList control with the state value
      // for the current row.
      
      // Retrieve the underlying data item. In this example
      // the underlying data item is a DataRowView object. 
      DataRowView rowView = (DataRowView)e.Row.DataItem;
      
      // Retrieve the state value for the current row. 
      String state = rowView["state"].ToString();
      
      // Retrieve the DropDownList control from the current row. 
      DropDownList list = (DropDownList)e.Row.FindControl("StatesList");
      
      // Find the ListItem object in the DropDownList control with the 
      // state value and select the item.
      ListItem item = list.Items.FindByText(state);
      list.SelectedIndex = list.Items.IndexOf(item);
    }
  }
  
  void AuthorsGridView_RowUpdating(Object sender, GridViewUpdateEventArgs e)
  {
    // Retrieve the row being edited.
    GridViewRow row = AuthorsGridView.Rows[AuthorsGridView.EditIndex];
    
    // Retrieve the DropDownList control from the row.
    DropDownList list = (DropDownList)row.FindControl("StatesList");
    
    // Add the selected value of the DropDownList control to 
    // the NewValues collection. The NewValues collection is
    // passed to the data source control, which then updates the 
    // data source.
    e.NewValues["state"] = list.SelectedValue;
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridViewRow DataItem Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridViewRow DataItem Example</h3>

      <asp:gridview id="AuthorsGridView" 
        datasourceid="AuthorsSqlDataSource" 
        autogeneratecolumns="false"
        autogenerateeditbutton="true" 
        datakeynames="au_id"
        onrowdatabound="AuthorsGridView_RowDataBound"
        onrowupdating="AuthorsGridView_RowUpdating"   
        runat="server"> 
               
        <columns>
          <asp:boundfield datafield="au_lname"
            headertext="Last Name"/>
          <asp:boundfield datafield="au_fname"
            headertext="First Name"/>
          <asp:templatefield headertext="State">
            <itemtemplate>
              <%#Eval("state")%>
            </itemtemplate>
            <edititemtemplate>
              <asp:dropdownlist id="StatesList"
                datasourceid="StatesSqlDataSource"
                datatextfield="state"  
                runat="server"/>  
              <asp:sqldatasource id="StatesSqlDataSource"  
                selectcommand="SELECT Distinct [state] FROM [authors]"
                connectionstring="server=localhost;database=pubs;integrated security=SSPI"
                runat="server">
              </asp:sqldatasource>
            </edititemtemplate>            
          </asp:templatefield>
        </columns>
                              
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects -->
      <!-- to the Pubs sample database.                        -->
      <asp:sqldatasource id="AuthorsSqlDataSource"  
        selectcommand="SELECT [au_id], [au_lname], [au_fname], [state] FROM [authors]"
        updatecommand="UPDATE authors SET [au_lname]=@au_lname, [au_fname]=@au_fname, [state]=@state WHERE au_id=@au_id"
        connectionstring="server=localhost;database=pubs;integrated security=SSPI"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->