' <Snippet4> 
Imports System
Imports System.Collections
Imports System.Configuration
Imports System.Web.DynamicData

Partial Public Class CustomAttributeValidation
    Inherits System.Web.UI.Page
    Protected _table As MetaTable

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        ' Register control with the data manager.
        DynamicDataManager1.RegisterControl(GridView1)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the table entity.
        _table = GridDataSource.GetTable()

        ' Assign title dynamically.
        Title = String.Concat( _
        "Customize <i>Phone</i> Data Field Validation", _
        "Using a Custom Attribute")
    End Sub
End Class
' </Snippet4> 
