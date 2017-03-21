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