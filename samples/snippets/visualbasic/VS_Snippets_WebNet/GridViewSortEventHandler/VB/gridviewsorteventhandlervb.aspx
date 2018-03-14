<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        
        ' Create a new GridView object.
        Dim authorGridView As GridView = New GridView
         
        ' Set the GridView object's properties.
        authorGridView.ID = "AuthorGridView"
        authorGridView.DataSourceID = "AuthorsSqlDataSource"
        authorGridView.AutoGenerateColumns = True
        authorGridView.AllowSorting = True
        
        ' Programmatically register the event-handling methods.
        AddHandler authorGridView.Sorting, AddressOf AuthorsGridView_Sorting
        
        ' Add the GridView object to the Controls collection
        ' of the PlaceHolder control.
        GridViewPlaceHolder.Controls.Add(authorGridView)
        
    End Sub
    
    Sub AuthorsGridView_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)
    
        ' Cancel the sorting operation if the user attempts to sort
        ' the Contract column.
        If e.SortExpression = "contract" Then

            e.Cancel = True
            Message.Text = "You cannot sort the Contract column."
        
        Else
      
            ' Clear the message label.
            Message.Text = ""
        
        End If
    
    End Sub

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