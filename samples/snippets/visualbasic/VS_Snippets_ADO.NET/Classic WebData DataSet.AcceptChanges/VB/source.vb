imports System
imports System.Data
imports System.Windows.Forms

Public Class Form1: Inherits Form

' <Snippet1>
Private Sub AcceptChanges()
   Dim myDataSet As DataSet
   myDataSet = new DataSet()

   ' Not shown: methods to fill the DataSet with data.
   Dim t As DataTable

   t = myDataSet.Tables("Suppliers")

   ' Add a DataRow to a table.
   Dim myRow As DataRow
   myRow = t.NewRow()
   myRow("CompanyID") = "NWTRADECO"
   myRow("CompanyName") = "NortWest Trade Company"

   ' Add the row.
   t.Rows.Add( myRow )

   ' Calling AcceptChanges on the DataSet causes AcceptChanges to be
   ' called on all subordinate objects.
   myDataSet.AcceptChanges()
End Sub
' </Snippet1>

End Class