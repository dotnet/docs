<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Button_Click(Object sender, EventArgs e)
  {

    // Clear the rows from the table.
    Table1.Rows.Clear();

    // Create a new table.
    // Iterate through the rows.
    for (int j = 0; j < 5; j++)
    {

      // Create a new row and add it to the Rows collection.
      HtmlTableRow row = new HtmlTableRow();

      // Provide a different background color for alternating rows.
      if (j % 2 == 1)
        row.BgColor = "Gray";

      // Iterate through the cells of a row.
      for (int i = 0; i < 5; i++)
      {
        // Create a new cell and add it to the Cells collection.
        HtmlTableCell cell = new HtmlTableCell();
        cell.Controls.Add(new LiteralControl("row " +
                          j.ToString() +
                          ", cell " +
                          i.ToString()));
        row.Cells.Add(cell);
      }
      Table1.Rows.Add(row);

    }
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
   <title>HtmlTableRowCollection Example</title>
</head>
<body>

   <form id="form1" runat="server">

      <h3>HtmlTableRowCollection Example</h3>
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
             value="Create New Table"
             onserverclick="Button_Click" 
             runat="server"/>

   </form>

</body>
</html>
<!--</Snippet1>-->