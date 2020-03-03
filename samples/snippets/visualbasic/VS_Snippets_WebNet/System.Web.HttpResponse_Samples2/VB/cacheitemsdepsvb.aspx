<!-- <snippet5> -->
<%@ Page Language="vb" %>
<%@ outputcache duration="30" varybyparam="none" %>
<%@ Import namespace="Samples.AspNet.VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    Private Sub Page_Load(sender As Object, e As System.EventArgs)
       ' Create an array list that
       ' contains the keys for two
       ' items stored in the Cache object.
       Dim deps As New ArrayList()
       deps.Add("bookData")
       deps.Add("authorData")
    
       ' Make the page invalid if either of the
       ' cached items change or expire.
       Response.AddCacheItemDependencies(deps)
    
       ' Populate the DataGrids.
       dgAuthors.DataSource = DataHelper.GetAuthorData()
       dgAuthors.DataBind()
    
       dgBooks.DataSource = DataHelper.GetBookData()
       dgBooks.DataBind()
    
       lblOutputCacheMsg.Text = DateTime.Now.ToString()
    End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Cache Item Dependencies</title> 
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <table>
            <tbody>
                <tr>
                    <th style="WIDTH: 118px">
                        Authors</th>
                    <td>
                        <asp:DataGrid id="dgAuthors" runat="server"></asp:DataGrid>
                    </td>
                </tr>
                <tr>
                    <th style="WIDTH: 118px">
                        Books</th>
                    <td>
                        <asp:DataGrid id="dgBooks" runat="server"></asp:DataGrid>
                    </td>
                </tr>
                <tr>
                    <td style="WIDTH: 118px">
                        The page was generated at:</td>
                    <td>
                        <asp:Label id="lblOutputCacheMsg" runat="server"></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
    </form>
</body>
</html>
<!-- </snippet5> -->