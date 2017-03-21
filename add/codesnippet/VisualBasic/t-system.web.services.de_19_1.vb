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

         Dim myInputOperationMessage As OperationMessage = _
            CType(New OperationInput(), OperationMessage)
         Dim myXmlQualifiedName As New XmlQualifiedName("AddSoapIn", _
            myDescription.TargetNamespace)
         myInputOperationMessage.Message = myXmlQualifiedName
         myOperationMessageCollection.Insert(0, myInputOperationMessage)
         ' Display the operation name of the InputMessage.
         Console.WriteLine("The operation name is " & _
            myInputOperationMessage.Operation.Name)

         ' Add the OperationMessage to the collection.
         myDescription.Write("MathService_new_vb.wsdl")
      Catch e As Exception
         Console.WriteLine("Exception caught!!!")
         Console.WriteLine("Source : " & e.Source.ToString())
         Console.WriteLine("Message : " & e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'MyOperationMessageSample