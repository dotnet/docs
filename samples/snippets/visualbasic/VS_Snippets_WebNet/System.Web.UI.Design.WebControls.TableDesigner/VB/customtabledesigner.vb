Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Web.UI.WebControls
Imports System.web.UI.Design
Imports System.Web.UI.Design.WebControls
Imports Examples.AspNet

Namespace Examples.AspNet.Design
' <snippet1>
' Create a class, named StyledTableDesigner,
' that derives from the TableDesigner class.
' This class displays a class named StyledTable
' at design time.
Public Class StyledTableDesigner
   Inherits TableDesigner
   
' <snippet2>   
   ' Override the GetDesignTimeHtml method to display
   ' placeholder text at design time for the 
   ' rows and cells of the StyledTable class.
   Public Overrides Function GetDesignTimeHtml() As String
       Dim sTable As StyledTable = CType(Component, StyledTable)
       Dim designTimeHTML As String
       Dim rows As TableRowCollection = sTable.Rows
       Dim cellsWithDummyContents As ArrayList = Nothing
      
       Dim emptyTable As Boolean = rows.Count = 0
       Dim emptyRows As Boolean = False
       Dim counter As Integer = 1
       Dim numcells As Integer = 2
       
       Try     
           ' Create two cells to display
           ' in a row at design time.
           If emptyTable Then
               Dim row As TableRow = New TableRow()
               rows.Add(row)
         
               Dim i As Integer
               For i = 0 To numcells - 1
                   Dim c As TableCell = New TableCell()
                   c.Text = "Cell #" & counter.ToString()
                   counter += 1
                   rows(0).Cells.Add(c)
               Next i
           Else
               emptyRows = True
               Dim j As Integer
               For j = 0 To rows.Count - 1
                   If rows(j).Cells.Count <> 0 Then
                       emptyRows = False
                       Exit For
                   End If
               Next j
               If emptyRows = True Then
                   Dim k As Integer
                   For k = 0 To numcells - 1
                       Dim c As TableCell = New TableCell()
                       c.Text = "Cell #" & counter.ToString()
                       counter += 1
                       rows(0).Cells.Add(c)
                   Next k
                End If
           End If
      
           If emptyTable = False Then
               ' If the rows and cells were defined by the user, but the
               ' cells remain empty this code defines a string to display 
               ' in them at design time.
               Dim row As TableRow
               For Each row In rows
                   Dim c As TableCell
                   For Each c In row.Cells
                       If ((c.Text.Length = 0) AndAlso (c.HasControls() = False)) Then
                          If cellsWithDummyContents Is Nothing Then
                              cellsWithDummyContents = New ArrayList()
                          End If
                          cellsWithDummyContents.Add(c)
                          c.Text = "Cell #" & counter.ToString()
                          counter += 1
                       End If
                   Next c
               Next row
           End If
           ' Retrieve the design-time HTML for the StyledTable class.
           designTimeHTML = MyBase.GetDesignTimeHtml()

       Finally
           ' If the StyledTable was empty before the dummy text was added,
           ' restore it to that state.
           If emptyTable Then
               rows.Clear()
           Else
               ' Clear the cells that were empty before the dummy text 
               ' was added.
               If Not (cellsWithDummyContents Is Nothing) Then
                   Dim c As TableCell
                   For Each c In  cellsWithDummyContents
                       c.Text = [String].Empty
                   Next c
               End If
               If emptyRows Then
                   rows(0).Cells.Clear()
               End If
           End If
      
       End Try
       Return designTimeHTML
   End Function
' </snippet2>   

End Class
' </snippet1>
End Namespace


