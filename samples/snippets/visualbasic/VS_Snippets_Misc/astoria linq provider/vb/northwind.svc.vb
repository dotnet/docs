Imports System.Data.Services
Imports System.Linq
Imports System.ServiceModel.Web

Public Class Northwind
    Inherits DataService(Of NorthwindDataContext)

    ' This method is called only once to initialize service-wide policies.
    Public Shared Sub InitializeService(ByVal config As DataServiceConfiguration)
        '<snippetEnableAccess>
        config.SetEntitySetAccessRule("Customers", EntitySetRights.ReadMultiple)
        config.SetEntitySetAccessRule("Orders", EntitySetRights.AllRead _
                                    Or EntitySetRights.WriteMerge)
        config.SetEntitySetAccessRule("Order_Details", EntitySetRights.AllRead _
                                    Or EntitySetRights.AllWrite)
        config.SetEntitySetAccessRule("Products", EntitySetRights.ReadMultiple)
        '</snippetEnableAccess>
    End Sub
End Class
