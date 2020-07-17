' <Snippet101> 

Imports System.Windows.Automation
Imports System.Windows.Automation.Provider

Namespace ClientSideProviderAssembly
	' The assembly must implement a UIAutomationClientSideProviders class, 
	' and the namespace must be the same as the name of the DLL, so that 
	' UI Automation can find the table of descriptors. In this example, 
	' the DLL would be "ClientSideProviderAssembly.dll"

	Friend NotInheritable Class UIAutomationClientSideProviders
		''' <summary>
		''' Implementation of the static ClientSideProviderDescriptionTable field. 
		''' In this case, only a single provider is listed in the table.
		''' </summary>
		Public Shared ClientSideProviderDescriptionTable() As ClientSideProviderDescription = { New ClientSideProviderDescription(New ClientSideProviderFactoryCallback(AddressOf ConsoleProvider.Create), "ConsoleWindowClass") }
					' Method that creates the provider object.
					' Class of window that will be served by the provider.
	End Class

	Friend Class ConsoleProvider
		Implements IRawElementProviderSimple
		Private providerHwnd As IntPtr

		Public Sub New(ByVal hwnd As IntPtr)
			providerHwnd = hwnd
		End Sub

		Friend Shared Function Create(ByVal hwnd As IntPtr, ByVal idChild As Integer, ByVal idObject As Integer) As IRawElementProviderSimple
			' This provider doesn't expose children, so never expects 
			' nonzero values for idChild.
			If idChild <> 0 Then
				Return Nothing
			Else
				Return New ConsoleProvider(hwnd)
			End If

		End Function

		Private Shared Function Create(ByVal hwnd As IntPtr, ByVal idChild As Integer) As IRawElementProviderSimple
			' Something is wrong if idChild is not 0.
			If idChild <> 0 Then
				Return Nothing
			Else
				Return New ConsoleProvider(hwnd)
			End If
		End Function

		#Region "IRawElementProviderSimple"

		' This is a skeleton implementation. The only real functionality 
		' at this stage is to return the name of the element and the host 
		' window provider, which can supply other properties.

		Private ReadOnly Property IRawElementProviderSimple_ProviderOptions() As ProviderOptions Implements IRawElementProviderSimple.ProviderOptions
			Get
				Return ProviderOptions.ClientSideProvider
			End Get
		End Property

		Private ReadOnly Property HostRawElementProvider() As IRawElementProviderSimple Implements IRawElementProviderSimple.HostRawElementProvider
			Get
				Return AutomationInteropProvider.HostProviderFromHandle(providerHwnd)
			End Get
		End Property

		Private Function GetPropertyValue(ByVal propertyId As Integer) As Object Implements IRawElementProviderSimple.GetPropertyValue
			If propertyId = AutomationElementIdentifiers.NameProperty.Id Then
				Return "Custom Console Window"
			Else
				Return Nothing
			End If

		End Function

		Private Function GetPatternProvider(ByVal iid As Integer) As Object Implements IRawElementProviderSimple.GetPatternProvider
			Return Nothing
		End Function
		#End Region ' IRawElementProviderSimple
	End Class
End Namespace
' </Snippet101>