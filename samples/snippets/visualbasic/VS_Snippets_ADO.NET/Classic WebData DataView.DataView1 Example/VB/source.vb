imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected Combo1 As ComboBox
Protected DataGrid1 As DataGrid
Protected DataSet1 As DataSet

' <Snippet1>
Private Sub MakeDataView()
    Dim view As DataView
    view = New DataView(DataSet1.Tables("Suppliers"))

    ' Bind a ComboBox control to the DataView.
    Combo1.DataSource = view
    Combo1.DisplayMember = "Suppliers.CompanyName"
End Sub
' </Snippet1>

End Class
