'<Snippet2>
Imports System.Web.DynamicData
Imports System.Web.Routing
Imports System.Web.UI.WebControls.Expressions

Class List
    Inherits Page

    Protected table As MetaTable
    
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        table = DynamicDataRouteHandler.GetRequestMetaTable(Context)
        GridView1.SetMetaTable(table, table.GetColumnValuesFromRoute(Context))
        GridDataSource.EntityTypeName = table.EntityType.AssemblyQualifiedName
        If table.EntityType <> table.RootEntityType Then
            GridQueryExtender.Expressions.Add(New OfTypeExpression(table.EntityType))
        End If
    End Sub
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Title = table.DisplayName
        
    
        ' Disable various options if the table is readonly
        If table.IsReadOnly Then
            GridView1.Columns(0).Visible = False
            InsertHyperLink.Visible = False
            GridView1.EnablePersistedSelection = False
        End If
    End Sub
    
    Protected Sub Label_PreRender(ByVal sender As Object, ByVal e As EventArgs)
        Dim label = CType(sender, Label)
        Dim dynamicFilter = CType(label.FindControl("DynamicFilter"), DynamicFilter)
        Dim fuc = CType(dynamicFilter.FilterTemplate, QueryableFilterUserControl)
        If fuc IsNot Nothing AndAlso fuc.FilterControl IsNot Nothing Then
            label.AssociatedControlID = fuc.FilterControl.GetUniqueIDRelativeTo(label)
        End If
    End Sub
    
    Protected Overrides Sub OnPreRenderComplete(ByVal e As EventArgs)
        Dim routeValues As New RouteValueDictionary(GridView1.GetDefaultValues)
        InsertHyperLink.NavigateUrl = table.GetActionPath(PageAction.Insert, routeValues)
        MyBase.OnPreRenderComplete(e)
    End Sub
    
    Protected Sub DynamicFilter_FilterChanged(ByVal sender As Object, ByVal e As EventArgs)
        GridView1.PageIndex = 0
    End Sub


'<Snippet3>
    ' Create route information based on the
    ' foreign-key specified in the 
    ' DynamicRouteExpression page markup. 
    Protected Function GetRouteInformation() As String

        ' Retrieve the current data item.
        Dim productItem = CType(GetDataItem(), Product)

        If productItem IsNot Nothing Then

            Dim rvd As New RouteValueDictionary()
            rvd.Add("ProductCategoryID", productItem.ProductCategoryID)

            Dim routePath As String = table.GetActionPath(PageAction.List, rvd)

            Return routePath

        End If

        Return String.Empty
    End Function

    ' Get the name of the foreign-key category. 
    Protected Function GetProductCategory() As String
        ' Retrieves the current data item.
        Dim productItem = CType(GetDataItem(), Product)

        If productItem IsNot Nothing Then
            Return productItem.ProductCategory.Name
        End If
        Return String.Empty
    End Function
'</Snippet3>

End Class
'</Snippet2>