<!-- <Snippet1> -->

<%@ Page language="VB" %>

<script runat="server">

  Sub AuthorsGridView_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
  
    ' If multiple ButtonField columns are used, use the
    ' CommandName property to determine which button was clicked.
    Select Case e.CommandName
    
      Case "Edit"
        AuthorsGridView.Columns(0).Visible = False
        AuthorsGridView.Columns(1).Visible = True
      Case "Update"
        AuthorsGridView.Columns(0).Visible = True
        AuthorsGridView.Columns(1).Visible = False
      Case Else
        ' Do nothing.
   
    End Select
    
  End Sub
  
  Sub AuthorsGridView_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)
    
    ' Retrieve the row being edited.    
    Dim index As Integer = AuthorsGridView.EditIndex
    Dim row As GridViewRow = AuthorsGridView.Rows(index)
    
    ' Retrieve the new value for the author's first name from the row. 
    ' In this example, the author's first name is in the second cell 
    ' of the row (index 1). To get the value, first retrieve the TextBox
    ' that contains the value.
    Dim firstNameTextBox As TextBox = CType(row.Cells(1).FindControl("FirstNameTextBox"), TextBox)
    
    ' Make sure the control was found. 
    Dim firstName As String = ""
    If Not firstNameTextBox Is Nothing Then

      firstName = firstNameTextBox.Text
      
    End If
    
    ' Retrieve the new value for the author's last name from the row. 
    ' In this example, the author's last name is in the third cell 
    ' of the row (index 2).
    Dim lastNameTextBox As TextBox = CType(row.Cells(2).FindControl("LastNameTextBox"), TextBox)
    
    Dim lastName As String = ""
    If Not lastNameTextBox Is Nothing Then
    
      lastName = lastNameTextBox.Text
      
    End If
    
    ' Because custom TemplateField field columns are used, parameters 
    ' are not automatically created and passed to the data source control.
    ' Create Parameter objects to represent the fields to update and 
    ' add the Parameter objects to the UpdateParameters collection.
    Dim lastNameParameter As New Parameter("au_lname", TypeCode.String, lastName)
    Dim firstNameParameter As New Parameter("au_fname", TypeCode.String, firstName)
    
    ' Clear the UpdateParameters collection before adding the 
    ' Parameter objects. Otherwise, there will be duplicate
    ' parameters.
    AuthorsSqlDataSource.UpdateParameters.Clear()
    AuthorsSqlDataSource.UpdateParameters.Add(lastNameParameter)
    AuthorsSqlDataSource.UpdateParameters.Add(firstNameParameter)
    
  End Sub
    
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