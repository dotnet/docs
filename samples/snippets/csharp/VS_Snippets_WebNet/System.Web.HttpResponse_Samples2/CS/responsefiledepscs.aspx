<!-- <snippet6> -->
<%@ Page Language="c#" %>
<%@ outputcache duration="30" varybyparam="none" %>
<%@ Import Namespace="Samples.AspNet.CS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    private void Page_Load(object sender, System.EventArgs e) 
    {
        
        // Create variables and assign file paths to them.
        string file1 = Server.MapPath("authors.xml");
        string file2 = Server.MapPath("books.xml");

        // Create an array list to contain the file paths.
        ArrayList fileList = new ArrayList();
        fileList.Add(file1);
    fileList.Add(file2);
            
        // Make the page dependent upon the arrayList.
        Response.AddFileDependencies(fileList);

        // Populate the DataGrids.
        dgAuthors.DataSource = DataHelper.GetAuthorData();
        dgAuthors.DataBind();

        dgBooks.DataSource = DataHelper.GetBookData();
        dgBooks.DataBind();

        lblOutputCacheMsg.Text = DateTime.Now.ToString();

    }

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>PageDataDisplay</title>
  </head>
  <body>  
    <form id="Form1" method="post" runat="server">
      <table>
        <tr>
          <th style="WIDTH: 118px">
            Authors
          </th>
          <td>
            <asp:DataGrid id="dgAuthors" runat="server"></asp:DataGrid>
          </td>
        </tr>
        <tr>
          <th style="WIDTH: 118px">
            Books
          </th>
          <td>
            <asp:DataGrid id="dgBooks" runat="server"></asp:DataGrid>
          </td>
        </tr>
        <tr>
          <td style="WIDTH: 118px">
            The page was generated at:
          </td>
          <td>
            <asp:Label id="lblOutputCacheMsg" runat="server"></asp:Label>
          </td>
        </tr>
      </table>
    </form>
  </body>
</html>
<!-- </snippet6> -->