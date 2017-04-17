'<Snippet1>
<%@ WebService Language="VB" Class="SoapDocumentMethodSample" %>
	
Imports System.Web.Services
Imports System.Web.Services.Protocols

Public Class SoapDocumentMethodSample

   <WebMethod(),SoapDocumentMethod(ResponseNamespace :="http://www.contoso.com",ResponseElementName := "MyCustomResponseElement")> _
   Public Function  ResponseDocument(numentries as Integer) As Integer()
	Dim intarray(numentries - 1) as Integer
        Dim i as Integer
        For i = 0 To numentries - 1
           intarray(i) = i
        Next
        Return intarray
   End Function
End Class
'</Snippet1>