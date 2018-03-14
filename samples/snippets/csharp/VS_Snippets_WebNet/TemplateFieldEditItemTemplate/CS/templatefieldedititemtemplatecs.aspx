<!-- <Snippet1> -->
<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  void AuthorsGridView_RowUpdating (Object sender, GridViewUpdateEventArgs e)
  {
    
    // The GridView control does not automatically extract updated values 
    // from TemplateField column fields. These values must be added manually 
    // to the NewValues dictionary.
    
    // Get the GridViewRow object that represents the row being edited
    // from the Rows collection of the GridView control.
    int index = AuthorsGridView.EditIndex;
    GridViewRow row = AuthorsGridView.Rows[index];
    
    // Get the controls that contain the updated values. In this
    // example, the updated values are contained in the TextBox 
    // controls declared in the edit item templates of each TemplateField 
    // column fields in the GridView control.
    TextBox lastName = (TextBox)row.FindControl("LastNameTextBox");
    TextBox firstName = (TextBox)row.FindControl("FirstNameTextBox");
    
    // Add the updated values to the NewValues dictionary. Use the
    // parameter names declared in the parameterized update query 
    // string for the key names.
    e.NewValues["au_lname"] = lastName.Text;
    e.NewValues["au_fname"] = firstName.Text;    
          
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TemplateField EditItemTemplate Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>TemplateField EditItemTemplate Example</h3>

      <!-- The GridView control automatically sets the columns     -->
      <!-- specified in the datakeynames attribute as read-only.   -->
      <!-- No input controls are rendered for these columns in     -->
      <!-- edit mode.                                              -->
      <asp:gridview id="AuthorsGridView" 
        datasourceid="AuthorsSqlDataSource" 
        autogeneratecolumns="false"
        autogenerateeditbutton="true"
        datakeynames="au_id"
        cellpadding="10"
        onrowupdating="AuthorsGridView_RowUpdating"      
        runat="server">
                
        <columns>
        
          <asp:boundfield datafield="au_id"
            headertext="Author ID"
            readonly="true"/>
            
          <asp:templatefield headertext="Last Name"
            itemstyle-verticalalign="Top">
            
            <itemtemplate>
              <%#Eval("au_lname")%>
            </itemtemplate>
            
            <edititemtemplate>
              <asp:textbox id="LastNameTextBox"
                text='<%#Eval("au_lname")%>'
                width="90"
                runat="server"/>
              <br/>
              <asp:requiredfieldvalidator id="LastNameRequiredValidator"
                controltovalidate="LastNameTextBox"
                display="Dynamic"
                text="Please enter a last name." 
                runat="server" />                                      
            </edititemtemplate>
            
          </asp:templatefield>
          
          <asp:templatefield headertext="First Name"
            itemstyle-verticalalign="Top">
            
            <itemtemplate>
              <%#Eval("au_fname")%>
            </itemtemplate>
            
            <edititemtemplate>
              <asp:textbox id="FirstNameTextBox"
                text='<%#Eval("au_fname")%>'
                width="90"
                runat="server"/>
              <br/>
              <asp:requiredfieldvalidator id="FirstNameRequiredValidator"
                controltovalidate="FirstNameTextBox"
                display="Dynamic"
                text="Please enter a first name."
                runat="server" />                      
            </edititemtemplate>
            
          </asp:templatefield>
          
          <asp:checkboxfield datafield="contract" 
            headertext="Contract"
            readonly="true"/>
            
        </columns>
                
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects -->
      <!-- to the Pubs sample database.                         -->
      <asp:sqldatasource id="AuthorsSqlDataSource"  
        selectcommand="SELECT [au_id], [au_lname], [au_fname], [contract] FROM [authors]"             
        updatecommand="UPDATE authors SET au_lname=@au_lname, au_fname=@au_fname WHERE (authors.au_id = @au_id)" 
        connectionstring="server=localhost;database=pubs;integrated security=SSPI"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->