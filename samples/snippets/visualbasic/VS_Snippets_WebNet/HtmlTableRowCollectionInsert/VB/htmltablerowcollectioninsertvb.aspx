<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    Dim i As Integer
    Dim j As Integer
    Dim row As HtmlTableRow
    Dim cell As HtmlTableCell

    ' Get the number of rows and columns selected by the user.
    Dim numrows As Integer = CInt(Select1.Value)
    Dim numcells As Integer = CInt(Select2.Value)

    ' Iterate through the rows.
    For j = 0 To numrows - 1

      ' Create a new row and add it to the Rows collection.
      row = New HtmlTableRow()

      ' Provide a different background color for alternating rows.
      If (j Mod 2) = 1 Then
        row.BgColor = "Gainsboro"
      End If

      ' Iterate through the cells of a row.
      For i = 0 To numcells - 1
           
        ' Create a new cell and add it to the Cells collection.
        cell = New HtmlTableCell()
        cell.Controls.Add(New LiteralControl("row " & _
                                          j.ToString() & _
                                          ", cell " & _
                                          i.ToString()))
        row.Cells.Insert(i, cell)
            
      Next i

      Table1.Rows.Insert(j, row)
         
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

      <table id="Table1" 
             runat="server"
             cellspacing="0" 
             style="padding:5; border-width:1; border-color:Black"/>
       
      <hr />

      Select the number of rows and columns to create: <br /><br />

      Table rows:
      <select id="Select1" 
              runat="server">

         <option value="1">1</option>
         <option value="2">2</option>
         <option value="3">3</option>
         <option value="4">4</option>
         <option value="5">5</option>

      </select>

      &nbsp;&nbsp;

      Table cells:
      <select id="Select2" 
              runat="server">

         <option value="1">1</option>
         <option value="2">2</option>
         <option value="3">3</option>
         <option value="4">4</option>
         <option value="5">5</option>

      </select>
       
      <br /><br />
  
      <input type="submit" 
             value="Generate Table" 
             runat="server"/>

   </form>

</body>
</html>
<!--</Snippet1>-->