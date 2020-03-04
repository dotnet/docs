<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Page_Load(Object sender, EventArgs e)
  {

    // Get the number of rows and columns selected by the user.
    int numrows = Convert.ToInt32(Select1.Value);
    int numcells = Convert.ToInt32(Select2.Value);

    // Iterate through the rows.
    for (int j = 0; j < numrows; j++)
    {

      // Create a new row and add it to the Rows collection.
      HtmlTableRow row = new HtmlTableRow();

      // Provide a different background color for alternating rows.
      if (j % 2 == 1)
        row.BgColor = "Gray";

      // Iterate through the cells of a row.
      for (int i = 0; i < numcells; i++)
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
   <title>HtmlTableCellCollection Example</title>
</head>
<body>

   <form id="form1" runat="server">

      <h3>HtmlTableCellCollection Example</h3>

      <table id="Table1" 
             style="border-width:1; border-color:Black; padding:5"
             cellspacing="0" 
             runat="server"/>
        
      <hr />

      Select the number of rows and columns to create: <br /><br />

      Table rows:
      <select id="Select1" 
              runat="server">

         <option value="1">1</option>
         <option value="2">2</option>
         <option value="3">3</option>
         <option value="4">4</option>
         <option value="5">5</option>

      </select>

      &nbsp;&nbsp;

      Table cells:
      <select id="Select2" 
              runat="server">

         <option value="1">1</option>
         <option value="2">2</option>
         <option value="3">3</option>
         <option value="4">4</option>
         <option value="5">5</option>

      </select>
       
      <br /><br />
  
      <input type="submit" 
             value="Generate Table" 
             runat="server"/>

   </form>

</body>
</html>
<!--</Snippet1>-->