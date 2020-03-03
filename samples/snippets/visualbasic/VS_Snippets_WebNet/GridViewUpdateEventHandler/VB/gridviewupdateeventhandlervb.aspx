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
        authorGridView.AutoGenerateEditButton = True
        authorGridView.DataKeyNames = New [String]() {"au_id"}
        
        ' Programmatically register the event-handling method.
        AddHandler authorGridView.RowUpdating, AddressOf AuthorsGridView_RowUpdating
        
        ' Add the GridView object to the Controls collection
        ' of the PlaceHolder control.
        GridViewPlaceHolder.Controls.Add(authorGridView)
        
    End Sub
    
    Sub AuthorsGridView_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)
     
        ' HTML-encode all user-provided values before updating
        ' the data source.
        Dim i As Integer
        
        For i = 0 To e.NewValues.Count - 1
            
            Dim entry As DictionaryEntry = e.NewValues(i)
            e.NewValues(entry.Key) = Server.HtmlEncode(entry.Value.ToString())
    
        Next i
        
    End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>GridViewUpdateEventHandler Example</title>
</head>
<body>
        <form id="form1" runat="server">
        
            <h3>GridViewUpdateEventHandler Example</h3>
            
            <asp:label id="Message"
                forecolor="Red"
                runat="server"/>
                
            <br/>
            
            <asp:placeholder id="GridViewPlaceHolder"
                runat="Server"/>
            
            <!-- This example uses Microsoft SQL Server and connects -->
            <!-- to the Pubs sample database.                        -->
            <asp:sqldatasource id="AuthorsSqlDataSource"  
                selectcommand="SELECT [au_id], [au_lname], [au_fname], [address], [city], [state], [zip] FROM [authors]"
                updatecommand="UPDATE authors SET au_lname=@au_lname, au_fname=@au_fname, address=@address, city=@city, state=@state, zip=@zip WHERE (authors.au_id = @au_id)"
                connectionstring="server=localhost;database=pubs;integrated security=SSPI"
                runat="server">
            </asp:sqldatasource>
            
        </form>
    </body>
</html>

<!-- </Snippet1> -->