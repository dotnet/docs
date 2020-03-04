<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)
 
    ' Remove the first row from the table.
    Dim row As HtmlTableRow = Table1.Rows(0)
    Table1.Rows.Remove(row)

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
   <title>HtmlTableRowCollectionExample</title>
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
             value="Remove First Row from Table"
             onserverclick="Button_Click" 
             runat="server"/>

   </form>

</body>
</html>
<!--</Snippet1>-->