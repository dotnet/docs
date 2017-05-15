<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    void Page_Load(Object sender, EventArgs e)
    {
        
        // Create a new GridView object.
        GridView authorGridView = new GridView();
         
        // Set the GridView object's properties.
        authorGridView.ID = "AuthorGridView";
        authorGridView.DataSourceID = "AuthorsSqlDataSource"; 
        authorGridView.AutoGenerateColumns = true;
        authorGridView.AllowSorting = true;
        
        // Programmatically register the event-handling methods.
        authorGridView.Sorting += new GridViewSortEventHandler(this.AuthorsGridView_Sorting);
        
        // Add the GridView object to the Controls collection
        // of the PlaceHolder control.
        GridViewPlaceHolder.Controls.Add(authorGridView);
        
    }
    
    void AuthorsGridView_Sorting(Object sender, GridViewSortEventArgs e)
    {
    
        // Cancel the sorting operation if the user attempts to sort
        // the Contract column.
        if(e.SortExpression == "contract")
        {
            e.Cancel = true;
            Message.Text = "You cannot sort the Contract column.";
        }
        else
        {
            // Clear the message label.
            Message.Text = "";
        }
    
    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>GridViewSortEventHandler Example</title>
</head>
<body>
        <form id="form1" runat="server">
        
            <h3>GridViewSortEventHandler Example</h3>
            
            <asp:label id="Message"
                forecolor="Red"
                runat="server"/>
                
            <br/>
            
            <asp:placeholder id="GridViewPlaceHolder"
                runat="Server"/>
            
            <!-- This example uses Microsoft SQL Server and connects -->
            <!-- to the Pubs sample database.                         -->
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