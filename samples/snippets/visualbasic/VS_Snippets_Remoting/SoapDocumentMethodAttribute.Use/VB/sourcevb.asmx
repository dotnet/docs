' <Snippet1>
<%@ WebService Language="VB" Class="ShoppingCart" %>
 
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Services.Description
Imports System

Public Class ShoppingCart
        
    ' Specify that the XML Web service method uses encoded SOAP messages.
    <SoapDocumentMethod(Use:=SoapBindingUse.Encoded), _
     WebMethod()> _
    Public Sub PlaceOrder(O as OrderItem)
        
        ' Process the order on the back end.
    End Sub
End Class

Public Class OrderItem
  Public Count As Integer
  Public Description as String
  Public OrderDate as DateTime
  Public CustomerID as Long
  Public Cost as Decimal

End Class
' </Snippet1>
