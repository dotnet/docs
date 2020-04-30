Imports System.Data.Services
Imports System.Linq
Imports System.ServiceModel.Web

'<snippetDataServiceDef>
Public Class Northwind
    Inherits DataService(Of NorthwindEntities)
    '</snippetDataServiceDef>

    '<snippetDataServiceConfigComplete>
    ' This method is called only once to initialize service-wide policies.
    Public Shared Sub InitializeService(ByVal config As DataServiceConfiguration)
        '<snippetDataServiceConfig>
        ' Set the access rules of feeds exposed by the data service, which is
        ' based on the requirements of client applications.
        config.SetEntitySetAccessRule("Customers", EntitySetRights.AllRead)
        config.SetEntitySetAccessRule("Employees", EntitySetRights.ReadSingle)
        config.SetEntitySetAccessRule("Orders", EntitySetRights.AllRead _
            Or EntitySetRights.WriteAppend _
            Or EntitySetRights.WriteMerge)
        config.SetEntitySetAccessRule("Order_Details", EntitySetRights.All)
        config.SetEntitySetAccessRule("Products", EntitySetRights.ReadMultiple)
        '</snippetDataServiceConfig>

        '<snippetDataServiceConfigPaging>
        ' Set page size defaults for the data service.
        config.SetEntitySetPageSize("Orders", 20)
        config.SetEntitySetPageSize("Order_Details", 50)
        config.SetEntitySetPageSize("Products", 50)

        ' Paging requires v2 of the OData protocol.
        config.DataServiceBehavior.MaxProtocolVersion = _
            System.Data.Services.Common.DataServiceProtocolVersion.V2
        '</snippetDataServiceConfigPaging>
    End Sub
    '</snippetDataServiceConfigComplete>
End Class
