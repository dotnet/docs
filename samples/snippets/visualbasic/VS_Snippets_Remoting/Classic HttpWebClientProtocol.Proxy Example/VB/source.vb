Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Net
Imports System.Web.Services.Protocols



Public Class Page1
    Inherits Page
    
    Private Sub Page_Load(sender As Object, e As EventArgs)
        ' <Snippet1>
        Dim math As New MyMath.Math()
        
        ' Set the proxy server to proxyserver, set the port to 80, and specify
        ' to bypass the proxy server for local addresses.
        Dim proxyObject As New WebProxy("http://proxyserver:80", True)
        math.Proxy = proxyObject
        
        ' Call the Add XML Web service method.
        Dim total As Integer = math.Add(8, 5)
        ' </Snippet1>
    End Sub 'Page_Load 

    Public Shared Sub Main

    End Sub
End Class 'Page1

Namespace MyMath
	Public Class Math 
		Inherits SoapHttpClientProtocol

		Public Function Add (num1 As Integer, num2 As Integer) As Integer
			Return num1 + num2
		End Function

	End Class
End Namespace