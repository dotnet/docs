imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected Text1 As TextBox
Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub MakeDataView()
    Dim view As DataView = New DataView

    view.Table = DataSet1.Tables("Suppliers")
    view.AllowDelete = True
    view.AllowEdit = True
    view.AllowNew = True
    view.RowFilter = "City = 'Berlin'"
    view.RowStateFilter = DataViewRowState.ModifiedCurrent
    view.Sort = "CompanyName DESC"
    
    ' Simple-bind to a TextBox control
    Text1.DataBindings.Add("Text", view, "CompanyName")
End Sub
' </Snippet1>

End Class
