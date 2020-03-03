<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub AuthorsGridView_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

    If e.Row.RowType = DataControlRowType.Footer Then
    
      Message.Text = "The authors are:<br />"
      
      ' Copy the items in the Rows collection into an array.
      Dim rowArray(AuthorsGridView.Rows.Count - 1) As GridViewRow
      AuthorsGridView.Rows.CopyTo(rowArray, 0)

      ' Iterate though the array and display the value in the
      ' first cell of the row.
      Dim row As GridViewRow
      For Each row In rowArray
      
        Message.Text &= row.Cells(0).Text & "<br />"
      
      Next
      
    End If
      
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridViewRowCollection CopyTo Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridViewRowCollection CopyTo Example</h3>

      <table>
        <tr>
          <td>
            <asp:gridview id="AuthorsGridView" 
              datasourceid="AuthorsSqlDataSource" 
              autogeneratecolumns="false"
              onrowcreated="AuthorsGridView_RowCreated"  
              runat="server"> 
                     
              <columns>
                <asp:boundfield datafield="au_lname"
                  headertext="Last Name"/>
                <asp:boundfield datafield="au_fname"
                  headertext="First Name"/>
              </columns>
                                    
            </asp:gridview>
          </td>
          <td>
            <asp:label id="Message" 
              forecolor="Red"
              runat="server"/>
          </td>
        </tr>
      </table>
            
      <!-- This example uses Microsoft SQL Server and connects -->
      <!-- to the Pubs sample database.                        -->
      <asp:sqldatasource id="AuthorsSqlDataSource"  
        selectcommand="SELECT [au_lname], [au_fname] FROM [authors] WHERE [state]='CA'"
        connectionstring="server=localhost;database=pubs;integrated security=SSPI"
        runat="server">
      </asp:sqldatasource>
          
    </form>
  </body>
</html>

<!-- </Snippet1> -->