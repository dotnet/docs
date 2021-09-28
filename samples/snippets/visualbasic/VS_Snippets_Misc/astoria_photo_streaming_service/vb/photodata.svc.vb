Imports System.Data.Services
Imports System.Data.Services.Common
Imports System.Linq
Imports System.ServiceModel.Web
Imports System.Data.Services.Providers
Imports PhotoService
Imports System.ServiceModel

'<System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults:=True)> _
'<snippetPhotoServiceStreamingProvider>
Partial Public Class PhotoData
    Inherits DataService(Of PhotoDataContainer)
    Implements IServiceProvider

    ' This method is called only once to initialize service-wide policies.
    Public Shared Sub InitializeService(ByVal config As DataServiceConfiguration)
        config.SetEntitySetAccessRule("PhotoInfo", _
            EntitySetRights.ReadMultiple Or _
            EntitySetRights.ReadSingle Or _
            EntitySetRights.AllWrite)

        ' Named streams require version 3 of the OData protocol.
        config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3
    End Sub
#Region "IServiceProvider Members"
    Public Function GetService(ByVal serviceType As Type) As Object _
    Implements IServiceProvider.GetService
        If serviceType Is GetType(IDataServiceStreamProvider) _
            Or serviceType Is GetType(IDataServiceStreamProvider) Then
            Return New PhotoServiceStreamProvider(Me.CurrentDataSource)
        End If
        Return Nothing
    End Function
#End Region
End Class
'</snippetPhotoServiceStreamingProvider>
