<!-- <Snippet3> -->
<%@ Control Language="vb" %>
<%@ Outputcache duration="10" varybyparam="none" shared="True" %>
<%@ Import Namespace="Samples.AspNet.VB" %>
<%@ Import Namespace="System.Data" %>
<script runat="server">

    Private Sub Page_Load(sender As Object, e As System.EventArgs)
    
        ' Make user control invalid if the 
        ' cache item changes or expires.
        Response.AddCacheItemDependency("bookData")


        ' Create a DataView object.
        Dim source As DataView = Cache("bookData")
    
        ' Check if the view is stored in the cache
        ' and generate the right label text
        ' dependent upon what is returned.
        If source Is Nothing Then

           source = DataHelper.GetBookData()
           lblCacheMsg.Text = "Data generated explicitly."
        Else
           lblCacheMsg.Text = "Data retrieved from application cache."
        End If
    
        dgBooks.DataSource = source
        dgBooks.DataBind()
    
        lblOutputMessage.Text = DateTime.Now.ToString()
    End Sub

</script>

    <table>
        <tbody>
            <tr>
                <th>
                    Books</th>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DataGrid id="dgBooks" runat="server"></asp:DataGrid>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label id="lblCacheMsg" runat="server"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    The control was created at: 
                </td>
                <td>
                    <asp:Label id="lblOutputMessage" runat="server"></asp:Label>
                </td>
            </tr>
        </tbody>
    </table>
     
<!-- </Snippet3> -->
