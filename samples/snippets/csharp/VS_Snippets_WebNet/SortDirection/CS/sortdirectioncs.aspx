<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void AuthorsGridView_Sorted(Object sender, EventArgs e)
  {
      
    // Display the sort direction.   
    if(AuthorsGridView.SortDirection == SortDirection.Ascending)
    {  
      Message.Text = "Sorting in ascending order.";
    }
    else
    {
      Message.Text = "Sorting in descending order.";
    }
        
  }

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