<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server" >
  
  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    ' Create an instance of an HtmlTable control.
    Dim table As HtmlTable = New HtmlTable()
    table.Border = 1
    table.CellPadding = 3

    ' Populate the HtmlTable control by adding rows to it.
    Dim rowcount As Integer
    Dim cellcount As Integer
          
    ' Create the rows of the table.
    For rowcount = 0 To 4

      ' Create a new HtmlTableRow control.
      Dim row As HtmlTableRow = New HtmlTableRow()
            
      ' Add cells to the HtmlTableRow control. 
      For cellcount = 0 To 3
          
        ' Define a new HtmlTableCell control.
        Dim cell As HtmlTableCell

        ' Create table header cells for the first row.
        If rowcount <= 0 Then
             
          cell = New HtmlTableCell("th")
           
        Else
               
          cell = New HtmlTableCell()
               
        End If

        ' Create the text for the cell.
        cell.Controls.Add(New LiteralControl( _
          "row " & rowcount.ToString() & ", " & _
          "column " & cellcount.ToString()))

        ' Add the cell to the HtmlTableRow Cells collection.
        row.Cells.Add(cell)
               
      Next cellcount

      ' Add the row to the HtmlTable Rows collection.
      table.Rows.Add(row)
          
    Next rowcount
 
    ' Add the control to the Controls collection of the 
    ' PlaceHolder control.
    Place.Controls.Clear()
    Place.Controls.Add(table)
         
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
   <title>HtmlTable Example</title>
</head>  
<body>

   <form id="form1" runat="server">
  
      <h3> HtmlTable Example </h3> 
  
      <asp:PlaceHolder id="Place" 
                       runat="server"/>
  
   </form>

</body>
</html>
 
<!--</Snippet1>-->
