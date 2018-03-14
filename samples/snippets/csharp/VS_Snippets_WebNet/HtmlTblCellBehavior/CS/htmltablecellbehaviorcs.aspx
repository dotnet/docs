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
        // Update the properties of each cell. 
        Table1.Rows[i].Cells[j].Align = AlignSelect.Value;
        Table1.Rows[i].Cells[j].NoWrap = Convert.ToBoolean(NoWrapSelect.Value);
        Table1.Rows[i].Cells[j].VAlign = VAlignSelect.Value;
      }

    }

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
   <title>HtmlTableCell Example</title>
</head>
<body>

   <form id="form1" runat="server">

      <h3>HtmlTableCell Example</h3>

          <table id="Table1" runat="server" 
                style="border-width: 1; border-color: Black">

         <tr>
            <td>
               Here is some content for Cell 1.
            </td>
            <td>
               Here is some content for Cell 2.
            </td>
         </tr>
         <tr>
            <td style="width:100; height:100">
               Here is some content for Cell 3.
            </td>
            <td style="width:100; height:100">
               Here is some content for Cell 4.
            </td>
         </tr>

      </table>

      <hr />

      Select the display settings for the cells in the table: <br /><br />

      Align:
      <select id="AlignSelect" 
              runat="server">

         <option value="Left" selected="selected">Left</option>
         <option value="Center">Center</option>
         <option value="Right">Right</option>
        
      </select>

      &nbsp;&nbsp;

      NoWrap:
      <select id="NoWrapSelect" 
              runat="server">

         <option value="true">True</option>
         <option value="false" selected="selected">False</option>

      </select>

      &nbsp;&nbsp;

      VAlign:
      <select id="VAlignSelect" 
              runat="server">

         <option value="Top">Top</option>
         <option value="Middle" selected="selected">Middle</option>
         <option value="Bottom">Bottom</option>

      </select>
       
      <br /><br />
  
      <input type="button" 
             value="Generate Table"
             onserverclick="Button_Click" 
             runat="server"/>

   </form>

</body>
</html>
<!--</Snippet1>-->