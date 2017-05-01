<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server" >
  
  void Page_Load(Object sender, EventArgs e)
  {

    // Create an instance of an HtmlTable control.
    HtmlTable table = new HtmlTable();
    table.Border = 1;
    table.CellPadding = 3;

    // Populate the HtmlTable control by adding rows to it. 
    for (int rowcount = 0; rowcount < 5; rowcount++)
    {
      // Create a new HtmlTableRow control.
      HtmlTableRow row = new HtmlTableRow();

      // Add cells to the HtmlTableRow control.
      for (int cellcount = 0; cellcount < 4; cellcount++)
      {
        // Define a new HtmlTableCell control.
        HtmlTableCell cell;

        // Create table header cells for the first row.
        if (rowcount <= 0)
        {
          cell = new HtmlTableCell("th");
        }
        else
        {
          cell = new HtmlTableCell();
        }

        // Create the text for the cell.
        cell.Controls.Add(new LiteralControl(
          "row " + rowcount.ToString() + ", " +
          "column " + cellcount.ToString()));

        // Add the cell to the HtmlTableRow Cells collection. 
        row.Cells.Add(cell);

      }

      // Add the row to the HtmlTable Rows collection.
      table.Rows.Add(row);

    }

    // Add the control to the Controls collection of the 
    // PlaceHolder control.
    Place.Controls.Clear();
    Place.Controls.Add(table);

  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
   <title>HtmlTable Example</title>
</head>
<body>

   <form id="form1" runat="server">
  
      <h3> HtmlTable Example </h3> 
  
      <asp:PlaceHolder id="Place" 
                       runat="server"/>
  
   </form>

</body>
</html>
 
<!--</Snippet1>-->
