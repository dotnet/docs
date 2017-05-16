<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)

    Dim i As Integer
    Dim j As Integer

    ' Iterate through the rows of the table.
    For i = 0 To Table1.Rows.Count - 1

      ' Iterate through the cells of a row.
      For j = 0 To Table1.Rows(i).Cells.Count - 1

        ' Update the properties of each cell. 
        Table1.Rows(i).Cells(j).BgColor = BgColorSelect.Value
        Table1.Rows(i).Cells(j).BorderColor = BorderColorSelect.Value
        Table1.Rows(i).Cells(j).Height = HeightSelect.Value
        Table1.Rows(i).Cells(j).Width = WidthSelect.Value
            
      Next j

    Next i

  End Sub

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
               Cell 1.
            </td>
            <td>
               Cell 2.
            </td>
         </tr>
         <tr>
            <td>
               Cell 3.
            </td>
            <td>
               Cell 4.
            </td>
         </tr>

      </table>

      <hr />

      Select the display settings for the cells in the table: <br /><br />

      BgColor:
      <select id="BgColorSelect" 
              runat="server">

         <option value="Red">Red</option>
         <option value="Blue">Blue</option>
         <option value="Green">Green</option>
         <option value="Black">Black</option>
         <option value="White" selected="selected">White</option>
        
      </select>

      &nbsp;&nbsp;

      BorderColor:
      <select id="BorderColorSelect" 
              runat="server">

         <option value="Red">Red</option>
         <option value="Blue">Blue</option>
         <option value="Green">Green</option>
         <option value="Black" selected="selected">Black</option>
         <option value="White">White</option>

      </select>

      <br /><br />

      Height:
      <select id="HeightSelect" 
              runat="server">

         <option value="0">0</option>
         <option value="100">100</option>
         <option value="150">150</option>
         <option value="200">200</option>
         <option value="250">250</option>

      </select>

      &nbsp;&nbsp;

      Width:
      <select id="WidthSelect" 
              runat="server">

         <option value="0">0</option>
         <option value="200">200</option>
         <option value="250">250</option>
         <option value="300">300</option>
         <option value="350">350</option>

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