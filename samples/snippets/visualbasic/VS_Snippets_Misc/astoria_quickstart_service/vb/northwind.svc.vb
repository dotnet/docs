'<snippetNorthwindServiceFull>
Imports System.Data.Services
Imports System.Linq
Imports System.ServiceModel.Web

'<snippetDataServiceClass>
'<snippetServiceDefinition>
Public Class Northwind
    Inherits DataService(Of NorthwindEntities)
    '</snippetServiceDefinition>

    ' This method is called only once to initialize service-wide policies.
    Public Shared Sub InitializeService(ByVal config As DataServiceConfiguration)
        '<snippetAllReadConfig>
        ' Grant only the rights needed to support the client application.
        config.SetEntitySetAccessRule("Orders", EntitySetRights.AllRead _
             Or EntitySetRights.WriteMerge _
             Or EntitySetRights.WriteReplace)
        config.SetEntitySetAccessRule("Order_Details", EntitySetRights.AllRead _
            Or EntitySetRights.AllWrite)
        config.SetEntitySetAccessRule("Customers", EntitySetRights.AllRead)
        '</snippetAllReadConfig>
    End Sub
End Class
'</snippetDataServiceClass>
'</snippetNorthwindServiceFull>
