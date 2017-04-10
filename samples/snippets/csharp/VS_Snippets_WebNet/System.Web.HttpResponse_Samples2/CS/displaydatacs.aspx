<!-- <snippet4> -->
<%@ Page language="c#" %>
<%@ Register tagprefix="Samples" tagname="Books" src="Bookscs.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="Server">
    private void Page_Load(object sender, System.EventArgs e)
    {
        lblPageMessage.Text = DateTime.Now.ToString();
    }

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>DisplayData</title>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <table>
        <tr>
          <td>
            This is user control displaying data:
          </td>
          <td>
            <Samples:Books id="ucBooks" runat="server"></Samples:Books>
          </td>
        </tr>
        <tr>
          <td>The page was generated at:
          </td>
          <td>
            <asp:Label ID="lblPageMessage" Runat="server"></asp:Label>
          </td>
        </tr>
      </table>
    </form>
  </body>
</html>
<!-- </snippet4> -->