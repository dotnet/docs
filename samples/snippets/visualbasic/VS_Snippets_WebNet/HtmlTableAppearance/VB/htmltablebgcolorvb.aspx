<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)

    ' Set the properties of the HtmlTable with the
    ' user selections.
    Table1.BgColor = BgColorSelect.Value
    Table1.Border = CInt(BorderSelect.Value)
    Table1.BorderColor = BorderColorSelect.Value
    Table1.Height = HeightSelect.Value
    Table1.Width = WidthSelect.Value
    
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
   <title>HtmlTable Example</title>
</head>
<body>

   <form id="form1" runat="server">

      <h3>HtmlTable Example</h3>

      <table id="Table1" 
             style="border-width:1; border-color:Black"
             runat="server">

         <tr>
            <th>
               Column 1
            </th>
            <th>
               Column 2
            </th>
            <th>
               Column 3
            </th>
         </tr>
         <tr>
            <td>
               Cell 1
            </td>
            <td>
               Cell 2
            </td>
            <td>
               Cell 3
            </td>
         </tr>
         <tr>
            <td>
               Cell 4
            </td>
            <td>
               Cell 5
            </td>
            <td>
               Cell 6
            </td>
         </tr>

      </table>
      
      <hr />

      Select the display settings: <br /><br />

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

      Border:
      <select id="BorderSelect" 
              runat="server">

         <option value="0">0</option>
         <option value="1" selected="selected">1</option>
         <option value="2">2</option>
         <option value="3">3</option>
         <option value="4">4</option>
         <option value="5">5</option>

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
             onserverclick ="Button_Click" 
             runat="server"/>

   </form>

</body>
</html>
<!--</Snippet1>-->