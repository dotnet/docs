' <Snippet201> 

Imports System
Imports System.Windows.Automation
Imports System.Windows.Automation.Provider
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.IO


Namespace CSClientProviderImplementation
    Friend Class CSClientSideImplementationProgram
        <DllImport("kernel32.dll")>
        Shared Function GetConsoleWindow() As IntPtr
        End Function


        Shared Sub Main(ByVal args() As String)

            ClientSettings.RegisterClientSideProviders(UIAutomationClientSideProviders.ClientSideProviderDescriptionTable)

            Dim hwnd As IntPtr = GetConsoleWindow()

            ' Get an AutomationElement that represents the window. 
            Dim elementWindow As AutomationElement = AutomationElement.FromHandle(hwnd)
            Console.WriteLine("Found UI Automation client-side provider for:")

            ' The name property is furnished by the client-side provider.
            Console.WriteLine(elementWindow.Current.Name)
            Console.WriteLine()

            Console.WriteLine("Press any key to exit.")
            Console.ReadLine()
        End Sub
    End Class ' CSClientSideImplementationProgram class


    Friend Class UIAutomationClientSideProviders
        ''' <summary>
        ''' Implementation of the static ClientSideProviderDescriptionTable field. 
        ''' In this case,only a single provider is listed in the table.
        ''' </summary>
        ' Method that creates the provider object.
        ' Class of window that will be served by the provider.
        Public Shared ClientSideProviderDescriptionTable() As ClientSideProviderDescription = {New ClientSideProviderDescription(AddressOf WindowProvider.Create, "ConsoleWindowClass")}
    End Class

    Friend Class WindowProvider
        Implements IRawElementProviderSimple
        Private providerHwnd As IntPtr

        Public Sub New(ByVal hwnd As IntPtr)
            providerHwnd = hwnd
        End Sub

        Friend Shared Function Create(ByVal hwnd As IntPtr, ByVal idChild As Integer, ByVal idObject As Integer) As IRawElementProviderSimple
            Return Create(hwnd, idChild)
        End Function

        Private Shared Function Create(ByVal hwnd As IntPtr, ByVal idChild As Integer) As IRawElementProviderSimple
            ' Something is wrong if idChild is not 0.
            If idChild <> 0 Then
                Return Nothing
            Else
                Return New WindowProvider(hwnd)
            End If
        End Function

#Region "IRawElementProviderSimple"

        ' This is a skeleton implementation. The only real functionality at this stage 
        ' is to return the name of the element and the host window provider, which can 
        ' supply other properties.

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

        Private Function GetPropertyValue(ByVal aid As Integer) As Object Implements IRawElementProviderSimple.GetPropertyValue
            If AutomationProperty.LookupById(aid) Is AutomationElementIdentifiers.NameProperty Then
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
' </Snippet201>
