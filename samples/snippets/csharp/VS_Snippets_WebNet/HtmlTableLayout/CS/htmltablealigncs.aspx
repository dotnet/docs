<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Button_Click(Object sender, EventArgs e)
  {

    // Set the HtmlTable properties according to the
    // user selections.
    Table1.CellSpacing = Convert.ToInt32(SpacingSelect.Value);
    Table1.CellPadding = Convert.ToInt32(PaddingSelect.Value);
    Table1.Align = AlignSelect.Value;

  }

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
      
      <br /><br /><br /><br /><br /><br /><br /><br />
      
      <hr />

      Select the display settings: <br /><br />

      Align:
      <select id="AlignSelect" 
              runat="server">

         <option value="Left">Left</option>
         <option value="Center">Center</option>
         <option value="Right">Right</option>
        
      </select>

      &nbsp;&nbsp;

      CellPadding:
      <select id="PaddingSelect" 
              runat="server">

         <option value="0">0</option>
         <option value="1">1</option>
         <option value="2">2</option>
         <option value="3">3</option>
         <option value="4">4</option>
         <option value="5">5</option>

      </select>

      &nbsp;&nbsp;

      CellSpacing:
      <select id="SpacingSelect" 
              runat="server">

         <option value="0">0</option>
         <option value="1">1</option>
         <option value="2">2</option>
         <option value="3">3</option>
         <option value="4">4</option>
         <option value="5">5</option>

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