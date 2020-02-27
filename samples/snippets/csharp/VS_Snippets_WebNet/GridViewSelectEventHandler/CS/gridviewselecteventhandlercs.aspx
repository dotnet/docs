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
        authorGridView.AutoGenerateSelectButton = true;
        authorGridView.AllowPaging = true; 
        authorGridView.SelectedIndex = 1;
        authorGridView.SelectedRowStyle.BackColor = System.Drawing.Color.LightCyan;
        authorGridView.SelectedRowStyle.ForeColor = System.Drawing.Color.DarkBlue;
        authorGridView.SelectedRowStyle.Font.Bold = true;
        
        // Programmatically register the event-handling methods.
        authorGridView.SelectedIndexChanged += new EventHandler(this.AuthorsGridView_SelectedIndexChanged);
        authorGridView.SelectedIndexChanging += new GridViewSelectEventHandler(this.AuthorsGridView_SelectedIndexChanging);
        
        // Add the GridView object to the Controls collection
        // of the PlaceHolder control.
        GridViewPlaceHolder.Controls.Add(authorGridView);
        
    }
    
    void AuthorsGridView_SelectedIndexChanged(Object sender, EventArgs e)
    {
    
        // Get the currently selected row using the SelectedRow property.
        GridView AuthorsGridView = (GridView)sender;
        GridViewRow row = AuthorsGridView.SelectedRow;
        
        // Display the author's name from the selected row.
        // In this example, the second and third columns contain
        // the author's last and first name, respectively.
        Message.Text = "You selected " + row.Cells[2].Text +
            " " + row.Cells[1].Text + ".";
    
    }
    
    void AuthorsGridView_SelectedIndexChanging(Object sender, GridViewSelectEventArgs e)
    {
        
        // Get the currently selected row. Because the SelectedIndexChanging event
        // occurs before the select operation in the GridView control, the
        // SelectedRow property cannot be used. Instead, use the Rows collection
        // and the NewSelectedIndex property of the e argument passed to this 
        // event handler.
        GridView AuthorsGridView = (GridView)sender;
        GridViewRow row = AuthorsGridView.Rows[e.NewSelectedIndex];
        
        // If the user selects an author with the last name White,
        // cancel the selection operation and display an error message.
        if(row.Cells[1].Text == "White")
        {
        
            e.Cancel = true;
            Message.Text = "You cannot select " + row.Cells[2].Text +
            " " + row.Cells[1].Text + ".";
        
        }
    
    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>GridViewSelectEventHandler Example</title>
</head>
<body>
        <form id="form1" runat="server">
        
            <h3>GridViewSelectEventHandler Example</h3>
            
            <asp:placeholder id="GridViewPlaceHolder"
                runat="Server"/>
            
            <!-- This example uses Microsoft SQL Server and connects -->
            <!-- to the Pubs sample database.                         -->
            <asp:sqldatasource id="AuthorsSqlDataSource"  
                selectcommand="SELECT [au_lname], [au_fname], [address], [city], [state], [zip], [contract] FROM [authors]"
                connectionstring="server=localhost;database=pubs;integrated security=SSPI"
                runat="server">
            </asp:sqldatasource>
            
            <br/>
            
            <asp:label id="Message"
                runat="server"/>
            
        </form>
    </body>
</html>

<!-- </Snippet1> -->