' <Snippet4> 
Imports System
Imports System.Collections
Imports System.Configuration
Imports System.Web.DynamicData

Partial Public Class CustomValidation
    Inherits System.Web.UI.Page
    Protected _table1 As MetaTable, _table2 As MetaTable

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        ' Register data controls with the data manager.
        DynamicDataManager1.RegisterControl(GridView1)
        DynamicDataManager1.RegisterControl(GridView2)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the table entities.
        _table1 = GridDataSource.GetTable()
        _table2 = GridDataSource2.GetTable()

        ' Assign title dynamically.
        Title = String.Concat("Customize Validation of the ", _
                              _table1.Name, " and ", _table2.Name, " Tables")

    End Sub
End Class
' </Snippet4> 
