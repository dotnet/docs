' System.Web.Services.Protocols.SoapHeader.EncodedMustUnderstand

' This program demonstrates the 'EncodedMustUnderstand' property of
' the 'SoapHeader' class. This example calls two webservice methods,
' namely 'WebMethod1' for which the property 'DidUnderstand' is set
' to true and 'WebMethod2' for which the property 'DidUnderstand'
' is set to false. The property 'EncodedMustUnderstand' is set to '1'
' for the client soapheader. The client calls the method 'WebMethod2' 
' whose 'DidUnderstand' property is set to false and hence a 'SoapHeaderException'
' is thrown.

Imports System

Public Class MySoapHeader_EncodedMustUnderstand
    
    Public Shared Sub Main()
        Try
' <Snippet1>
            ' MyHeader class inherits from the SoapHeader class.
            Dim customHeader As New MyHeader()
            customHeader.MyValue = "Header value for MyValue"

            ' Set the EncodedMustUnderstand property to true.
            customHeader.EncodedMustUnderstand = "1"

            Dim myWebService As New WebService_SoapHeader_EncodedMustUnderstand()
            myWebService.MyHeaderValue = customHeader
            Dim results As String = myWebService.MyWebMethod1()
            Console.WriteLine(results)
            Try
                results = myWebService.MyWebMethod2()
            Catch myException As Exception
                Console.WriteLine("Exception raised in MyWebMethod2.")
                Console.WriteLine("Message: " & myException.Message)
            End Try
' </Snippet1>
        Catch e As Exception
            Console.WriteLine("Exception caught!")
            Console.WriteLine("Source: " + e.Source)
            Console.WriteLine("Message: " + e.Message)
        End Try
    End Sub 'Main
End Class 'MySoapHeader_EncodedMustUnderstand
