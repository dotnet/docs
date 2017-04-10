
Imports System
Imports System.Xml
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Description

Namespace Program
	Friend Class Snippets
		Private Sub Snippet1()
			' <Snippet1>
			Dim binding As New CustomBinding()
			Dim bpCol As New BindingParameterCollection()
			Dim context As New BindingContext(binding, bpCol)
			' </Snippet1>
		End Sub

		Private Sub Snippet2()
			' <Snippet2>
			Dim binding As New CustomBinding()
			Dim bpCol As New BindingParameterCollection()
			Dim baseAddress As New Uri("http://MyServer/Base")
			Dim relAddress As String = "MyService"
			Dim context As New BindingContext(binding, bpCol, baseAddress, relAddress, ListenUriMode.Explicit)
			' </Snippet2>
		End Sub

		Private Sub Snippet3()
			' <Snippet3>
			Dim binding As New CustomBinding()
			Dim bpCol As New BindingParameterCollection()
			Dim context As New BindingContext(binding, bpCol)
			Dim binding2 As Binding = context.Binding
			' </Snippet3>
		End Sub

		Private Sub Snippet4()
			' <Snippet4>
			Dim binding As New CustomBinding()
			Dim bpCol As New BindingParameterCollection()
			Dim context As New BindingContext(binding, bpCol)
			Dim bindingParams As BindingParameterCollection = context.BindingParameters
			' </Snippet4>
		End Sub

		Private Sub Snippet5()
			' <Snippet5>
			Dim binding As New CustomBinding()
			Dim bpCol As New BindingParameterCollection()
			Dim context As New BindingContext(binding, bpCol)
			Dim baseAddress As Uri = context.ListenUriBaseAddress
			' </Snippet5>
		End Sub

		Private Sub Snippet6()
			' <Snippet6>
			Dim binding As New CustomBinding()
			Dim bpCol As New BindingParameterCollection()
			Dim context As New BindingContext(binding, bpCol)
			Dim mode As ListenUriMode = context.ListenUriMode
			' </Snippet6>
		End Sub

		Private Sub Snippet7()
			' <Snippet7>
			Dim binding As New CustomBinding()
			Dim bpCol As New BindingParameterCollection()
			Dim context As New BindingContext(binding, bpCol)
			Dim relAddress As String = context.ListenUriRelativeAddress
			' </Snippet7>
		End Sub

		Private Sub Snippet8()
			' <Snippet8>
			Dim binding As New CustomBinding()
			Dim bpCol As New BindingParameterCollection()
			Dim context As New BindingContext(binding, bpCol)
			Dim bindingElements As BindingElementCollection = context.RemainingBindingElements
			' </Snippet8>
		End Sub

		Private Sub Snippet9()
			' <Snippet9>
			Dim binding As New CustomBinding()
			Dim bpCol As New BindingParameterCollection()
			Dim context As New BindingContext(binding, bpCol)
			context.BuildInnerChannelFactory(Of IDuplexChannel)()
			' </Snippet9>
		End Sub

		Private Sub Snippet10()
			' <Snippet10>
			Dim binding As New CustomBinding()
			Dim bpCol As New BindingParameterCollection()
			Dim context As New BindingContext(binding, bpCol)
			context.BuildInnerChannelListener(Of IDuplexChannel)()
			' </Snippet10>
		End Sub

		Private Sub Snippet11()
			' <Snippet11>
			Dim binding As New CustomBinding()
			Dim bpCol As New BindingParameterCollection()
			Dim context As New BindingContext(binding, bpCol)
			context.CanBuildInnerChannelFactory(Of IDuplexChannel)()
			' </Snippet11>
		End Sub

		Private Sub Snippet12()
			' <Snippet12>
			Dim binding As New CustomBinding()
			Dim bpCol As New BindingParameterCollection()
			Dim context As New BindingContext(binding, bpCol)
			context.CanBuildInnerChannelListener(Of IDuplexChannel)()
			' </Snippet12>
		End Sub

		Private Sub Snippet13()
			' <Snippet13>
			Dim binding As New CustomBinding()
			Dim bpCol As New BindingParameterCollection()
			Dim context As New BindingContext(binding, bpCol)
			Dim clonedContext As BindingContext = context.Clone()
			' </Snippet13>
		End Sub

		Private Sub Snippet14()
			' <Snippet14>
			Dim binding As New CustomBinding()
			Dim bpCol As New BindingParameterCollection()
			Dim context As New BindingContext(binding, bpCol)
			Dim quotas As XmlDictionaryReaderQuotas = context.GetInnerProperty(Of XmlDictionaryReaderQuotas)()
			' </Snippet14>
		End Sub

	End Class
End Namespace
