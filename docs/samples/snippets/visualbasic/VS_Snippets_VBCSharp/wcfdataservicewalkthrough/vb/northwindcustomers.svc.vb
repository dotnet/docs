Imports System.Data.Services
Imports System.Data.Services.Common
Imports System.Linq
Imports System.ServiceModel.Web

Public Class NorthwindCustomers
    ' TODO: replace [[class name]] with your data class name
    ' <Snippet1>
    Inherits DataService(Of northwindEntities)
    ' </Snippet1>
    ' This method is called only once to initialize service-wide policies.
    Public Shared Sub InitializeService(ByVal config As DataServiceConfiguration)
        ' <Snippet2>
        config.SetEntitySetAccessRule("*", EntitySetRights.All)
        ' </Snippet2>
        config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2
    End Sub

End Class
