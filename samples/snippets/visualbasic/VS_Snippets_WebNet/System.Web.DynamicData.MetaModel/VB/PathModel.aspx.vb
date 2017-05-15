' <Snippet2>
Imports System
Imports System.Collections
Imports System.Configuration
Imports System.Data
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Xml.Linq
Imports System.Web.DynamicData

Partial Public Class PathModel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        DynamicDataManager1.RegisterControl(GridDataSource1)
    End Sub

    ' <Snippet22>
    ' Get the data model. 
    Public Function GetModel(ByVal defaultModel As Boolean) As MetaModel
        Dim model As MetaModel

        If defaultModel Then
            model = MetaModel.[Default]
        Else
            model = MetaModel.GetModel(GetType(AdventureWorksLTDataContext))
        End If
        Return model
    End Function
    ' </Snippet22>

    ' <Snippet23>
    ' Get the registered action path.
    Public Function EvaluateActionPath() As String
        Dim tableName As String = LinqDataSource1.TableName

        Dim model As MetaModel = GetModel(False)

        Dim actionPath As String = model.GetActionPath(tableName, System.Web.DynamicData.PageAction.List, GetDataItem())
        Return actionPath
    End Function
    ' </Snippet23>
End Class
' </Snippet2>
