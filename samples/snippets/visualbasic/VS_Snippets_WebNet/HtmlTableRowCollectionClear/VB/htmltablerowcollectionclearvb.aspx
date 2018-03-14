<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)
 
    Dim i As Integer
    Dim j As Integer
    Dim row As HtmlTableRow
    Dim cell As HtmlTableCell

    ' Clear the rows from the table.
    Table1.Rows.Clear()

    ' Create a new table.
    ' Iterate through the rows.
    For j = 0 To 4

      ' Create a new row and add it to the Rows collection.
      row = New HtmlTableRow()

      ' Provide a different background color for alternating rows.
      If (j Mod 2) = 1 Then
        row.BgColor = "Gray"
      End If

      ' Iterate through the cells of a row.
      For i = 0 To 4
            
        ' Create a new cell and add it to the Cells collection.
        cell = New HtmlTableCell()
        cell.Controls.Add(New LiteralControl("row " & _
                          j.ToString() & _
                          ", cell " & _
                          i.ToString()))
        row.Cells.Add(cell)
      Next i
      Table1.Rows.Add(row)
           
    Next j
      
  End Sub

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