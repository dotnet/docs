<%@ WebService Language="VB" Class="PriceWebService" %>

Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Collections.Generic

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class PriceWebService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    '<Snippet31>
    <WebMethod()> _
    Public Function GetPrices() As Product()
        Dim context As New AdventureWorksDataContext()
        Dim productsToReturn As New List(Of Product)
        Dim randomNumber = New Random()

        For Each p As Product In context.Products
            If p.ProductID Mod 10 = randomNumber.Next(10) Then
                p.ListPrice = p.ListPrice + 1000
                productsToReturn.Add(p)
            End If
        Next
        Return productsToReturn.ToArray
    End Function
    '</Snippet31>
End Class