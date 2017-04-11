<!-- <Snippet3> -->
    <%@ Control Language="c#" %>
    <%@ Outputcache duration="10" varybyparam="none" shared="True" %>
    <%@ Import Namespace = "Samples.AspNet.CS" %>
    <%@ Import Namespace = "System.Data" %>

<script runat="server">

    private void Page_Load(object sender, System.EventArgs e)
    {
    
        // Make user control invalid if the
        // cache item changes or expires.
        Response.AddCacheItemDependency("bookData");

        // Create a DataView object.
        DataView source = (DataView)Cache["bookData"];
    
        // Check if the view is stored in the cache
        // and generate the right label text
        // dependent upon what is returned.
        if (source == null)
        {
            source = DataHelper.GetBookData();
            lblCacheMsg.Text = "Data generated explicitly.";
        }
        else
        {
            lblCacheMsg.Text = "Data retrieved from application cache.";
        }
    
        dgBooks.DataSource = source;
        dgBooks.DataBind();
    
        lblOutputMessage.Text = DateTime.Now.ToString();
    }

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
