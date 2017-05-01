<!-- <snippet6> -->
<%@ Page Language="vb" %>
<%@ outputcache duration="30" varybyparam="none" %>
<%@ Import Namespace="Samples.AspNet.VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    Private Sub Page_Load(sender As Object, e As System.EventArgs)
    
       ' Create variable and assign file paths to them.
       Dim file1 As String = Server.MapPath("authors.xml")
       Dim file2 As String = Server.MapPath("books.xml")
    
       ' Create an array list to contain the file paths.
       Dim fileList As New ArrayList()
       fileList.Add(file1)
       fileList.Add(file2)
    
       ' Use the AddFileDependencies method to
       ' invalidate the output cached page if 
       ' one of the files changes.
       Response.AddFileDependencies(fileList)
    
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
    <title>PageDataDisplay</title>
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
<!-- </snippet6> -->