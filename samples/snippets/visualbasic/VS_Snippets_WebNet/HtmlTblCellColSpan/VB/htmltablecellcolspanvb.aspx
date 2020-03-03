<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
            <td colspan="2">
               Cell 1.
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

   </form>

</body>
</html>
<!--</Snippet1>-->