<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub AuthorsGridView_Sorted(ByVal sender As Object, ByVal e As EventArgs)
      
    ' Display the sort direction.   
    If AuthorsGridView.SortDirection = SortDirection.Ascending Then
 
      Message.Text = "Sorting in ascending order."
    
    Else
    
      Message.Text = "Sorting in descending order."
    
    End If
        
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>SortDirection Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>SortDirection Example</h3>
            
      <asp:label id="Message"
        forecolor="Red"
        runat="server"/>
        
      <br/><br/>    
          
      <asp:gridview id="AuthorsGridView"
        datasourceid="AuthorsSqlDataSource"
        allowsorting="true"
        onsorted="AuthorsGridView_Sorted"  
        runat="server"/>
            
      <!-- This example uses Microsoft SQL Server and connects -->
      <!-- to the Pubs sample database.                        -->
      <asp:sqldatasource id="AuthorsSqlDataSource"  
        selectcommand="SELECT [au_id], [au_lname], [au_fname], [address], [city], [state], [zip], [contract] FROM [authors]"
        updatecommand="UPDATE authors SET au_lname=@au_lname, au_fname=@au_fname, address=@address, city=@city, state=@state, zip=@zip, contract=@contract WHERE (authors.au_id = @au_id)"
        connectionstring="server=localhost;database=pubs;integrated security=SSPI"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->