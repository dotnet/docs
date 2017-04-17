<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub SelectAllCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
  
    ' Get the CheckBox control that indicates whether to show or 
    ' hide the rows in the GridView control. The sender parameter
    ' contains the control that raised the event.
    Dim showCheckBox As CheckBox = CType(sender, CheckBox)
    
    ' Show or hide the rows of the GridView control based
    ' on the check box value selected by the user.
    If showCheckBox.Checked Then

      ShowRows(True)

    Else

      ShowRows(False)
    
    End If
    
  End Sub
  
  Sub ShowRows(ByVal show As Boolean)
    
    ' Iterate through the Rows collection of the GridView
    ' control and show or hide the rows based on the value
    ' of the show parameter.
    Dim row As GridViewRow
    For Each row In AuthorsGridView.Rows
    
      row.Visible = show
    
    Next
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TemplateField HeaderTemplate Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>TemplateField HeaderTemplate Example</h3>

      <!-- Populate the Columns collection declaratively. -->
      <!-- Create a TemplateField column field that contains   -->
      <!-- a CheckBox control in the header section to show or -->
      <!-- hide the rows in the GridView control.              -->
      <asp:gridview id="AuthorsGridView" 
        datasourceid="AuthorsSqlDataSource" 
        autogeneratecolumns="False"
        width="250" 
        runat="server">
                
        <columns>
          <asp:templatefield>
            <headerstyle backcolor="Navy"
              forecolor="White"/>
            <itemtemplate>
              <%#Eval("au_fname")%>
              <%#Eval("au_lname")%>
            </itemtemplate>
            <headertemplate>
              <asp:checkbox id="ShowAllCheckBox"
                text="Show All"
                checked="True" 
                autopostback="true"
                oncheckedchanged="SelectAllCheckBox_CheckedChanged"  
                runat="server"/>
            </headertemplate>
          </asp:templatefield>                      
        </columns>
                
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects -->
      <!-- to the Pubs sample database.                        -->
      <asp:sqldatasource id="AuthorsSqlDataSource"  
        selectcommand="SELECT [au_id], [au_lname], [au_fname], [address], [city], [state], [zip], [contract] FROM [authors]"
        connectionstring="server=localhost;database=pubs;integrated security=SSPI"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->