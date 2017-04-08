imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms

public class Form1
Inherits Form

Shared Sub Main()
End Sub
' <Snippet1>
  Private Sub AddTables(myDataGrid As DataGrid, _
  myDataSet As DataSet )
      Dim t As DataTable 
      For Each t in myDataSet.Tables
         Dim myGridTableStyle As DataGridTableStyle  = new _
         DataGridTableStyle()
   	     myGridTableStyle.MappingName = t.TableName
   	     myDataGrid.TableStyles.Add(myGridTableStyle)
         ' Note that DataGridColumnStyle objects will
         ' be created automatically for the first DataGridTableStyle
         ' when you add it to the GridTableStylesCollection.*/
      Next
   End Sub
   Private Sub PrintGridStyleInfo(myDataGrid As DataGrid )
      Dim myGridStyle As DataGridTableStyle
      Dim myColumnStyle As DataGridColumnStyle
      
      for each myGridStyle in _
      myDataGrid.TableStyles
         Console.WriteLine(myGridStyle.MappingName)
         for each myColumnStyle in myGridStyle.GridColumnStyles
   	    Console.WriteLine(myColumnStyle.MappingName)
         Next
      Next
   End Sub    
' </Snippet1>
End Class
