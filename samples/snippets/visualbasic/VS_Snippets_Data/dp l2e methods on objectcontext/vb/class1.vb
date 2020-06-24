Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
Imports System.Reflection
Imports System.Linq.Expressions

'<snippet2>
Partial Public Class AdventureWorksEntities
    Inherits ObjectContext

    <EdmFunction("AdventureWorksModel", "GetProductRevenue")>
    Public Function GetProductRevenue(ByVal details As _
                    IQueryable(Of SalesOrderDetail)) As _
                    System.Nullable(Of Decimal)
        Return Me.QueryProvider.Execute(Of System.Nullable(Of Decimal)) _
            (Expression.[Call](Expression.Constant(Me), _
            DirectCast(MethodInfo.GetCurrentMethod(), MethodInfo), _
            Expression.Constant(details, GetType(IQueryable(Of SalesOrderDetail)))))
    End Function
End Class
'</snippet2>

'<snippet5> 
Public Class [MyClass]
    <EdmFunction("AdventureWorksModel", "GetProductRevenue")> _
    Public Shared Function GetProductRevenue(ByVal details As _
                IQueryable(Of SalesOrderDetail)) As _
                System.Nullable(Of Decimal)
        Return details.Provider.Execute(Of System.Nullable(Of Decimal)) _
            (Expression.[Call](DirectCast(MethodInfo.GetCurrentMethod(), MethodInfo), _
            Expression.Constant(details, GetType(IQueryable(Of SalesOrderDetail)))))
    End Function
End Class
'</snippet5> 

'<snippet8>
Partial Public Class AdventureWorksEntities
    Inherits ObjectContext
    <EdmFunction("AdventureWorksModel", "GetDetailsById")> _
    Public Function GetDetailsById(ByVal productId As Integer) _
            As IQueryable(Of SalesOrderDetail)
        Return Me.QueryProvider.CreateQuery(Of SalesOrderDetail) _
            (Expression.[Call](Expression.Constant(Me), _
             DirectCast(MethodInfo.GetCurrentMethod(), MethodInfo), _
             Expression.Constant(productId, GetType(Integer))))
    End Function
End Class
'</snippet8>
