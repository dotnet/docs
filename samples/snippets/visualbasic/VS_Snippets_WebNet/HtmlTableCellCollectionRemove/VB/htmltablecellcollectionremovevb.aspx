<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)

    Dim i As Integer
    Dim cell As HtmlTableCell

    ' Iterate through the rows of the table.
    For i = 0 To Table1.Rows.Count - 1
 
      ' Remove the cells from the first column.
      cell = Table1.Rows(i).Cells(0)
      Table1.Rows(i).Cells.Remove(cell)

    Next i

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
   <title>HtmlTableCellCollection Example</title>
</head>
<body>

   <form id="form1" runat="server">

      <h3>HtmlTableCellCollection Example</h3>

      <table id="Table1" 
             style="border-width:1; border-color:Black"
             runat="server">

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
             value="Remove First Column from Table"
             onserverclick="Button_Click" 
             runat="server"/>

   </form>

</body>
</html>
<!--</Snippet1>-->