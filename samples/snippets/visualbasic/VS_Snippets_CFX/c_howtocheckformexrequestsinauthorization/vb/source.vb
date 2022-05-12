Imports System.Security.Cryptography.X509Certificates
Imports System.IdentityModel.Claims
Imports System.IdentityModel.Policy
Imports System.ServiceModel
Imports System.ServiceModel.Security
Imports System.ServiceModel.Security.Tokens
Imports System.ServiceModel.Description
Imports System.ServiceModel.Dispatcher
Imports System.ServiceModel.Channels
Imports System.Security.Permissions

Namespace Microsoft.Samples
    Public Class test
        Shared Sub Main()
            Console.WriteLine("Starting")
        End Sub

    End Class

    '<snippet1>
    Class MyAuthorizationManager
        Inherits ServiceAuthorizationManager
        Protected Overrides Function CheckAccessCore(ByVal operationContext As OperationContext) As Boolean

            ' Allow MEX requests through.
            With operationContext
                If .EndpointDispatcher.ContractName = ServiceMetadataBehavior.MexContractName AndAlso _
                   .EndpointDispatcher.ContractNamespace = "http://schemas.microsoft.com/2006/04/mex" AndAlso _
                   .IncomingMessageHeaders.Action = "http://schemas.xmlsoap.org/ws/2004/09/transfer/Get" Then
                    Return True
                End If
            End With

            ' Code not shown: Perform authorization checks for non-MEX requests
            Return False

        End Function
    End Class
    '</snippet1>

End Namespace
