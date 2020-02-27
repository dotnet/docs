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
      Table1.Rows(i).BgColor = BgColorSelect.Value
      Table1.Rows(i).BorderColor = BorderColorSelect.Value
      Table1.Rows(i).Height = HeightSelect.Value

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

      Select the display settings for the rows in the table: <br /><br />

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
       
      <br /><br />
  
      <input id="Button1" type="button" 
             value="Generate Table"
             onserverclick="Button_Click" 
             runat="server"/>

   </form>

</body>
</html>
<!--</Snippet1>-->