' System.Web.Services.Description.OperationFaultCollection.Add

' The following example demonstrates the 'Add' method of the
' 'OperationFaultCollection' class. Based on 'StockQuote_vb.wsdl', the program generates a WSDL file
' 'StockQuoteNew_vb.wsdl' which contains 'Fault' information written out.

Imports System
Imports System.Web.Services.Description
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic

Public Class MyFaultCollectionSample
   Public Shared Sub Main()
      Try
         ' Read the 'StockQuote.wsdl' file as input.
         Dim myServiceDescription As ServiceDescription = _
                              ServiceDescription.Read("StockQuote_vb.wsdl")
         Dim myPortTypeCollection As PortTypeCollection = _
                                             myServiceDescription.PortTypes
         Dim myPortType As PortType = myPortTypeCollection(0)
         Dim myOperationCollection As OperationCollection = _
                                                      myPortType.Operations
         Dim myOperation As Operation = myOperationCollection(0)

' <Snippet1>
         Dim myOperationFaultCollection As OperationFaultCollection = myOperation.Faults
         Dim myOperationFault As New OperationFault()
         myOperationFault.Name = "ErrorString"
         myOperationFault.Message = New XmlQualifiedName("s0:GetTradePriceStringFault")
         myOperationFaultCollection.Add(myOperationFault)
' </Snippet1>

         Console.WriteLine("Added OperationFault with Name: " + _
                                                     myOperationFault.Name)
         myOperationFault = New OperationFault()
         myOperationFault.Name = "ErrorInt"
         myOperationFault.Message = _
                           New XmlQualifiedName("s0:GetTradePriceIntFault")
         myOperationFaultCollection.Add(myOperationFault)

         Console.WriteLine("Added Second OperationFault with Name: " + _
                                                      myOperationFault.Name)
         myServiceDescription.Write("StockQuoteNew_vb.wsdl")
         Console.WriteLine(ControlChars.NewLine + _
                           "The file 'StockQuoteNew_vb.wsdl' is created" + _
                           " successfully.")
      Catch e As Exception
         Console.WriteLine("Exception caught!!!")
         Console.WriteLine("Source : " + e.Source)
         Console.WriteLine("Message : " + e.Message)
      End Try
   End Sub 
End Class 