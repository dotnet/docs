<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Button_Click(Object sender, EventArgs e)
  {

    // Iterate through the rows of the table.
    for (int i = 0; i <= Table1.Rows.Count - 1; i++)
    {

      // Iterate through the cells of a row.
      for (int j = 0; j <= Table1.Rows[i].Cells.Count - 1; j++)
      {
        // Change the inner HTML of the cell.
        Table1.Rows[i].Cells[j].InnerHtml = "Row " + i.ToString() +
                                            ", Column " + j.ToString();
      }

    }

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>HtmlTableCell</title>
  </head>

  <body>

    <form id="form1" runat="server">

      <h3>HtmlTableCell Example</h3>

          <table id="Table1" runat="server" 
                style="border-width: 1; border-color: Black">

         <tr>
            <td>
               Cell 1
            </td>
            <td>
               Cell 2
            </td>
         </tr>
         <tr>
            <td>
               Cell 3
            </td>
            <td>
               Cell 4
            </td>
         </tr>

      </table>

      <br /><br />
  
      <input type="button" 
             value="Change Table Contents"
             onserverclick="Button_Click"
             runat="server"/>

    </form>

  </body>
</html>
<!--</Snippet1>-->