<!-- <Snippet1> -->
<%@ Page language="C#" %>

<script runat="server">

  void AuthorsGridView_RowCommand(Object sender, GridViewCommandEventArgs e)
  {
  
    // If multiple ButtonField columns are used, use the
    // CommandName property to determine which button was clicked.
    switch(e.CommandName)
    {
    
      case "Edit":
        AuthorsGridView.Columns[0].Visible = false;
        AuthorsGridView.Columns[1].Visible = true;
        break;
      case "Update":
        AuthorsGridView.Columns[0].Visible = true;
        AuthorsGridView.Columns[1].Visible = false;
        break;
      default:
        // Do nothing.
        break;
    }
    
  }
  
  void AuthorsGridView_RowUpdating (Object sender, GridViewUpdateEventArgs e)
  {
    
    // Retrieve the row being edited.    
    int index = AuthorsGridView.EditIndex;
    GridViewRow row = AuthorsGridView.Rows[index];
    
    // Retrieve the new value for the author's first name from the row. 
    // In this example, the author's first name is in the second cell 
    // of the row (index 1). To get the value, first retrieve the TextBox
    // that contains the value.
    TextBox firstNameTextBox = (TextBox)row.Cells[1].FindControl("FirstNameTextBox");
    
    // Make sure the control was found. 
    String firstName = "";    
    if(firstNameTextBox != null)
    {
      firstName = firstNameTextBox.Text;
    }
    
    // Retrieve the new value for the author's last name from the row. 
    // In this example, the author's last name is in the third cell 
    // of the row (index 2).
    TextBox lastNameTextBox = (TextBox)row.Cells[2].FindControl("LastNameTextBox");
    
    String lastName = "";
    if(lastNameTextBox != null)
    {
      lastName = lastNameTextBox.Text;
    }
    
    // Because custom TemplateField field columns are used, parameters 
    // are not automatically created and passed to the data source control.
    // Create Parameter objects to represent the fields to update and 
    // add the Parameter objects to the UpdateParameters collection.
    Parameter lastNameParameter = new Parameter("au_lname", TypeCode.String, lastName);   
    Parameter firstNameParameter = new Parameter("au_fname", TypeCode.String, firstName);
    
    // Clear the UpdateParameters collection before adding the 
    // Parameter objects. Otherwise, there will be duplicate
    // parameters.
    AuthorsSqlDataSource.UpdateParameters.Clear();
    AuthorsSqlDataSource.UpdateParameters.Add(lastNameParameter);
    AuthorsSqlDataSource.UpdateParameters.Add(firstNameParameter);
    
  }
    
</script>

<head runat="server">
    <title>ButtonFieldBase CausesValidation Example</title>
</head>
<body>
  <form id="form1" runat="server">
  <div>

    <h3>ButtonFieldBase CausesValidation Example</h3>

    <!-- Populate the Columns collection declaratively. -->
    <asp:gridview id="AuthorsGridView" 
      datasourceid="AuthorsSqlDataSource"
      cellpadding="5"  
      autogeneratecolumns="false"
      datakeynames="au_id" 
      onrowcommand="AuthorsGridView_RowCommand"
      onrowupdating="AuthorsGridView_RowUpdating"  
      runat="server">

      <columns>
        <asp:buttonfield commandname="Edit"
          causesvalidation="false" 
          text="Edit" 
          headertext="Edit Author">
        </asp:buttonfield>

        <asp:buttonfield commandname="Update" 
          visible="false" 
          causesvalidation="true" 
          text="Update"
          validationgroup="NameGroup" 
          headertext="Update Author">
        </asp:buttonfield>

        <asp:templatefield headertext="Last Name">
          <itemtemplate>
            <%# Eval("au_lname") %>
          </itemtemplate>

          <edititemtemplate>
            <asp:textbox id="LastNameTextBox"
              text='<%# Eval("au_lname") %>'
              width="175" 
              runat="server" /><br />  

            <asp:RequiredFieldValidator ID="LastNameRequiredValidator"
              ControlToValidate="LastNameTextBox"
              ErrorMessage="Please enter a last name."
              ValidationGroup="NameGroup" 
              Runat="server" />

          </edititemtemplate>
        </asp:templatefield>

        <asp:templatefield headertext="First Name">
          <itemtemplate>
            <%# Eval("au_fname") %>
          </itemtemplate>

          <edititemtemplate>
            <asp:textbox id="FirstNameTextBox"
              text='<%# Eval("au_fname") %>'
              width="175" 
              runat="server" /><br />  

            <asp:RequiredFieldValidator ID="FirstNameRequiredValidator"
              ControlToValidate="FirstNameTextBox"
              ErrorMessage="Please enter a first name."
              ValidationGroup="NameGroup" 
              Runat="server" />

          </edititemtemplate>

        </asp:templatefield>
      </columns>

    </asp:gridview>

    <!-- This example uses Microsoft SQL Server and connects -->
    <!-- to the Pubs sample database.                        -->
    <asp:sqldatasource id="AuthorsSqlDataSource"  
      selectcommand="SELECT [au_id], [au_lname], [au_fname] FROM [authors]"
      updatecommand="UPDATE authors SET au_lname=@au_lname, au_fname=@au_fname WHERE (authors.au_id = @au_id)"
      connectionstring="server=localhost;database=pubs;integrated security=SSPI"
      runat="server">   
    </asp:sqldatasource>

  </div>
  </form>
</body>
</html>

<!-- </Snippet1> -->