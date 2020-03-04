<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)

    Dim i As Integer

    ' Iterate through the rows of the table.
    For i = 0 To Table1.Rows.Count - 1
       
      ' Update the properties of each row. 
      Table1.Rows(i).Align = AlignSelect.Value
      Table1.Rows(i).VAlign = VAlignSelect.Value

    Next i

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
   <title>HtmlTableRow Example</title>
</head>
<body>

   <form id="form1" runat="server">

      <h3>HtmlTableRow Example</h3>

      <table id="Table1" 
             style="border-width:1; border-color:Black"
             runat="server">

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