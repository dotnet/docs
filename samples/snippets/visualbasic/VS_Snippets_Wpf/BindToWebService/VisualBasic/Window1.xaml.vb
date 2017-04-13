Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data

'<SnippetNamespace>
' 1. Include the web service namespace
Imports BindtoContentService.com.microsoft.msdn.services
'</SnippetNamespace>
Namespace BindtoContentService
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits System.Windows.Window
		Public Sub New()
			InitializeComponent()
		End Sub

		' Handler for the Windows Loaded event 
		Private Sub OnLoad(ByVal sender As Object, ByVal e As RoutedEventArgs)
'<SnippetWebServiceCall>
			' 2. Set up the request object
			' To use the MSTP web service, we need to configure and send a request
			' In this example, we create a simple request that has the ID of the XmlReader.Read method page
			Dim request As New getContentRequest()
			request.contentIdentifier = "abhtw0f1"

			' 3. Create the proxy
			Dim proxy As New ContentService()

			' 4. Call the web service method and set the DataContext of the Window
			' (GetContent returns an object of type getContentResponse)
			Me.DataContext = proxy.GetContent(request)
'</SnippetWebServiceCall>
		End Sub
	End Class
End Namespace