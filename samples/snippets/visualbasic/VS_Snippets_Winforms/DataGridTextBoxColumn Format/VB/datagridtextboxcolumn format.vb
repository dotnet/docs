Imports System
Imports System.Globalization
Imports System.Windows.Forms
' <Snippet1>
Public Class Form1:Inherits Form
private myDataGrid as DataGrid    
    Public Shared Sub Main()
        Dim t As New Form1()
        ' Write a purchase order.
    End Sub
Private Sub ChangeColumnCultureInfo()
   ' Create a new CultureInfo object using the 
   ' the locale ID for Italy. 
   Dim ItalyCultureInfo As CultureInfo = New _
   CultureInfo(&H0410)
   ' Cast a column that holds numeric values to the   
   ' DataGridTextBoxColumn type, and set the FormatInfo
   ' property to the new CultureInfo object. 
   Dim myGridTextBoxColumn As DataGridTextBoxColumn = _
   CType( myDataGrid.TableStyles("Orders"). _
   GridColumnStyles("OrderAmount"), DataGridTextBoxColumn)
   myGridTextBoxColumn.FormatInfo = ItalyCultureInfo
   myGridTextBoxColumn.Format = "c"
End Sub
' </Snippet1>    
End Class


