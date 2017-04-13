' System.Web.Services.Description.OperationMessage
' System.Web.Services.Description.OperationMessage.OperationMessage
' System.Web.Services.Description.OperationMessage.Message
' System.Web.Services.Description.OperationMessage.Operation

' The following example demonstrates the usage of the 'OperationMessage'
' class, its constructor and the properties 'Message' and 'Operation'.
' The input to the program is a WSDL file 'MathService_input_cs.wsdl' without
' the input message of 'Add' operation for the SOAP
' protocol. In this example a new input message for the 'Add' operation is created.
' The input message in the ServiceDescription instance is loaded with values for
' 'InputMessage'. The instance is then written to 'MathService_new_cs.wsdl'.
'

' <Snippet1>
Imports System
Imports System.Xml
Imports System.Web.Services
Imports System.Web.Services.Description

Class MyOperationMessageSample

   Shared Sub Main()
      Try
         Dim myDescription As ServiceDescription = _
            ServiceDescription.Read("MathService_input_vb.wsdl")
         Dim myPortTypeCollection As PortTypeCollection = _
            myDescription.PortTypes

         ' Get the OperationCollection for the SOAP protocol.
         Dim myOperationCollection As OperationCollection = _
            myPortTypeCollection(0).Operations

         ' Get the OperationMessageCollection for the Add operation.
         Dim myOperationMessageCollection As OperationMessageCollection =  _
               myOperationCollection(0).Messages

' <Snippet2>
' <Snippet4>
' <Snippet3>
         Dim myInputOperationMessage As OperationMessage = _
            CType(New OperationInput(), OperationMessage)
         Dim myXmlQualifiedName As New XmlQualifiedName("AddSoapIn", _
            myDescription.TargetNamespace)
         myInputOperationMessage.Message = myXmlQualifiedName
' </Snippet3>
         myOperationMessageCollection.Insert(0, myInputOperationMessage)
         ' Display the operation name of the InputMessage.
         Console.WriteLine("The operation name is " & _
            myInputOperationMessage.Operation.Name)

' </Snippet4>
' </Snippet2>
         ' Add the OperationMessage to the collection.
         myDescription.Write("MathService_new_vb.wsdl")
      Catch e As Exception
         Console.WriteLine("Exception caught!!!")
         Console.WriteLine("Source : " & e.Source.ToString())
         Console.WriteLine("Message : " & e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'MyOperationMessageSample
' </Snippet1>
