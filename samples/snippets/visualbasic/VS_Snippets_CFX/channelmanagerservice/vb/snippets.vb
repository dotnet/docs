Imports System
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.Workflow.Runtime
Imports System.Workflow.Runtime.Hosting
Imports System.ServiceModel.Description
Imports System.Collections.Specialized
Imports System.ServiceModel.Channels

Namespace ChannelManagerServiceSnippets
	Friend Class snippets
		Inherits ServiceHostBase
		Private Sub Container0()
            ' ChannelManagerService.ChannelManagerService.
			Dim workflowRuntime As New WorkflowRuntime()
			'<snippet0>
			' Add ChannelManager.
			Dim channelmgr As New ChannelManagerService()
			workflowRuntime.AddService(channelmgr)
			'</snippet0>
		End Sub
		Private Sub Container1()
			Dim contextFileName As String
			Dim workflowRuntime As New WorkflowRuntime()
			Dim localServiceHost As LocalServiceHost = Nothing
			Dim contextFileExtension As String = Nothing
            ' ChannelManagerService.ChannelManagerService(IList).
			'<snippet1>
			contextFileName = localServiceHost.Description.ServiceType.Name & contextFileExtension

            ' add local client endpoints.
			workflowRuntime = Me.Description.Behaviors.Find(Of WorkflowRuntimeBehavior)().WorkflowRuntime
			workflowRuntime.AddService(New ChannelManagerService(localServiceHost.ClientEndpoints))

			localServiceHost.Open()

			'</snippet1>
		End Sub
		Private Sub Container2()
            ' ChannelManagerService.ChannelManagerService(NameValueCollection).
			'<snippet2>
            Dim parameters As New NameValueCollection()
            With parameters
                .Add("idleTimeout", TimeSpan.FromMinutes(10).ToString())
                .Add("leaseTimeout", TimeSpan.FromMinutes(1).ToString())
                .Add("maxIdleChannelsPerEndpoint", "10")
            End With
            Dim service As New ChannelManagerService(parameters)
            '</snippet2>
        End Sub
		Private Sub Container3()
            ' ChannelManagerService.ChannelManagerService(ChannelPoolSettings).
			'<snippet3>
            Dim settings As New ChannelPoolSettings()
            With settings
                .IdleTimeout = TimeSpan.FromMinutes(10)
                .LeaseTimeout = TimeSpan.FromMinutes(1)
                .MaxOutboundChannelsPerEndpoint = 10
            End With
			Dim service As New ChannelManagerService(settings)
			'</snippet3>
		End Sub
		Private Sub Container4()
            ' ChannelManagerService.ChannelManagerService(ChannelPoolSettings, Ilist).
			Dim contractDescription As ContractDescription = Nothing
			'<snippet4>
            Dim settings As New ChannelPoolSettings()
            With settings
                settings.IdleTimeout = TimeSpan.FromMinutes(10)
                settings.LeaseTimeout = TimeSpan.FromMinutes(1)
                settings.MaxOutboundChannelsPerEndpoint = 10
            End With
			Dim endpoints As IList(Of ServiceEndpoint) = New List(Of ServiceEndpoint)()
			endpoints.Add(New ServiceEndpoint(contractDescription))
			Dim service As New ChannelManagerService(settings, endpoints)
			'</snippet4>
		End Sub

		Private Class LocalServiceHost
			Inherits ServiceHost
			Public Sub New(ByVal singletonInstance As Object, ParamArray ByVal baseAddresses() As Uri)
				MyBase.New(singletonInstance, baseAddresses)
			End Sub

			Private clientEndpoints_Renamed As IList(Of ServiceEndpoint) = Nothing
			Friend ReadOnly Property ClientEndpoints() As IList(Of ServiceEndpoint)
				Get
					Return clientEndpoints_Renamed
				End Get
			End Property
		End Class


        Protected Overrides Function _
        CreateDescription(<System.Runtime.InteropServices.Out()> ByRef implementedContracts As IDictionary(Of String, ContractDescription)) As ServiceDescription
            Throw New NotImplementedException()
        End Function
	End Class
End Namespace
