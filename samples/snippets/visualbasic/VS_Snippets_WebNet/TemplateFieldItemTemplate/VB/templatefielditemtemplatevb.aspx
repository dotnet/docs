<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub TitleGridView_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
    
    ' Get the RadioButtonList control from the row.
    Dim radio As RadioButtonList = CType(e.Row.FindControl("TypeList"), RadioButtonList)
    
    ' Select the appropriate option button based on the value
    ' of the Type field for the row. In this example, the Type
    ' field values are stored in the column in the 
    ' GridView control.
    If Not radio Is Nothing Then

      Select Case e.Row.Cells(3).Text.Trim()

        Case "business"
          radio.SelectedIndex = 0

        Case "mod_cook"
          radio.SelectedIndex = 1

        Case "popular_comp"
          radio.SelectedIndex = 2

        Case "psychology"
          radio.SelectedIndex = 3

        Case "trad_cook"
          radio.SelectedIndex = 4

        Case Else
          radio.SelectedIndex = 5
      
      End Select
      
    End If
    
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TemplateField ItemTemplate Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>TemplateField ItemTemplate Example</h3>

      <!-- Populate the Columns collection declaratively. -->
      <!-- Create a custom TemplateField column that uses      -->
      <!-- two Label controls to display an author's first and -->
      <!-- last name in the same column.                       -->
      <asp:gridview id="TitleGridView" 
        datasourceid="TitleSqlDataSource" 
        autogeneratecolumns="false"
        onrowdatabound="TitleGridView_RowDataBound" 
        runat="server">
                
        <columns>
          
          <asp:boundfield datafield="title"
            headertext="Title"/>
          
          <asp:boundfield datafield="price"
            dataformatstring="{0:c}"
            headertext="Price"/>  
                  
          <asp:templatefield headertext="Type">
            <itemtemplate>
              <asp:radiobuttonlist id="TypeList"
                datasourceid="TypeSqlDataSource"
                datatextfield="type"
                enabled="false"  
                runat="server"/>  
            </itemtemplate>
          </asp:templatefield>
          
          <asp:boundfield datafield="type"/>
                
        </columns>
                
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects -->
      <!-- to the Pubs sample database.                        -->
      <asp:sqldatasource id="TitleSqlDataSource"  
        selectcommand="SELECT [title], [price], [type] FROM [titles]"
        connectionstring="server=localhost;database=pubs;integrated security=SSPI"
        runat="server">
      </asp:sqldatasource>
      
      <asp:sqldatasource id="TypeSqlDataSource"  
        selectcommand="SELECT Distinct [type] FROM [titles]"
        connectionstring="server=localhost;database=pubs;integrated security=SSPI"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->