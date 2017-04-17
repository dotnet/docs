<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  ' Create a template class to represent a dynamic template column.
  Public Class GridViewTemplate   
    Implements ITemplate

    Private templateType As DataControlRowType
    Private columnName As String
   
    Sub New(ByVal type As DataControlRowType, ByVal colname As String)

      templateType = type
      columnName = colname
    
    End Sub

    Sub InstantiateIn(ByVal container As System.Web.UI.Control) _
      Implements ITemplate.InstantiateIn
      
      ' Create the content for the different row types.
      Select Case templateType

        Case DataControlRowType.Header
          ' Create the controls to put in the header
          ' section and set their properties.
          Dim lc As New Literal
          lc.Text = "<b>" & columnName & "</b>"
          
          ' Add the controls to the Controls collection
          ' of the container.
          container.Controls.Add(lc)

        Case DataControlRowType.DataRow
          ' Create the controls to put in a data row
          ' section and set their properties.
          Dim firstName As New Label
          Dim lastName As New Label
          
          Dim spacer = New Literal
          spacer.Text = " "
          
          ' To support data binding, register the event-handling methods
          ' to perform the data binding. Each control needs its own event
          ' handler.
          AddHandler firstName.DataBinding, AddressOf FirstName_DataBinding
          AddHandler lastName.DataBinding, AddressOf LastName_DataBinding
          
          ' Add the controls to the Controls collection
          ' of the container.
          container.Controls.Add(firstName)
          container.Controls.Add(spacer)
          container.Controls.Add(lastName)
          
          ' Insert cases to create the content for the other 
          ' row types, if desired.
          
        Case Else
        
          ' Insert code to handle unexpected values. 
          
      End Select
      
    End Sub
    
    Private Sub FirstName_DataBinding(ByVal sender As Object, ByVal e As EventArgs)

      ' Get the Label control to bind the value. The Label control
      ' is contained in the object that raised the DataBinding 
      ' event (the sender parameter).
      Dim l As Label = CType(sender, Label)
      
      ' Get the GridViewRow object that contains the Label control. 
      Dim row As GridViewRow = CType(l.NamingContainer, GridViewRow)
      
      ' Get the field value from the GridViewRow object and 
      ' assign it to the Text property of the Label control.
      l.Text = DataBinder.Eval(row.DataItem, "au_fname").ToString()
    
    End Sub
    
    Private Sub LastName_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
 
      ' Get the Label control to bind the value. The Label control
      ' is contained in the object that raised the DataBinding 
      ' event (the sender parameter).
      Dim l As Label = CType(sender, Label)
      
      ' Get the GridViewRow object that contains the Label control.
      Dim row As GridViewRow = CType(l.NamingContainer, GridViewRow)
      
      ' Get the field value from the GridViewRow object and 
      ' assign it to the Text property of the Label control.
      l.Text = DataBinder.Eval(row.DataItem, "au_lname").ToString()
    
    End Sub
    
  End Class

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    
    ' The field columns need to be created only when the page is
    ' first loaded. 
    If Not IsPostBack Then
      ' Dynamically create field columns to display the desired
      ' fields from the data source. Create a TemplateField object 
      ' to display an author's first and last name.
      Dim customField As New TemplateField

      ' Create the dynamic templates and assign them to
      ' the appropriate template property.
      customField.ItemTemplate = New GridViewTemplate(DataControlRowType.DataRow, "Author Name")
      customField.HeaderTemplate = New GridViewTemplate(DataControlRowType.Header, "Author Name")

      ' Add the field column to the Columns collection of the
      ' GridView control.
      AuthorsGridView.Columns.Add(customField)
    End If
  
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TemplateField Constructor Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>TemplateField Constructor Example</h3>

      <asp:gridview id="AuthorsGridView" 
        datasourceid="AuthorsSqlDataSource" 
        autogeneratecolumns="False"
        runat="server">                
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects -->
      <!-- to the Pubs sample database.                        -->
      <asp:sqldatasource id="AuthorsSqlDataSource"  
        selectcommand="SELECT [au_fname], [au_lname] FROM [authors]"
        connectionstring="server=localhost;database=pubs;integrated security=SSPI"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->