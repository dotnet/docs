Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel.Web
Imports System.ServiceModel
Imports System.ServiceModel.Activation

Namespace WebServiceHostFactorySnippets
	Public Class MyWebServiceHostFactory
		Inherits WebServiceHostFactory
		Protected Overrides Overloads Function CreateServiceHost(ByVal t As Type, ByVal baseAddresses() As Uri) As ServiceHost
			Return New MyWebServiceHost(t, baseAddresses)
		End Function
	End Class

	Public Class MyWebServiceHost
		Inherits WebServiceHost
		Public Sub New(ByVal serviceType As Type, ParamArray ByVal baseAddresses() As Uri)
			MyBase.New(serviceType, baseAddresses)
		End Sub
	End Class
End Namespace
