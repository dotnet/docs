' System.Web.Services.Description.ServiceDescription.PortTypes
' System.Web.Services.Description.ServiceDescription.CanRead

' The following example demonstrates the 'PortTypes' property
' and 'CanRead' method of 'ServiceDescription' class.
' The input to the program is a WSDL file 'MyWsdl_VB.wsdl'.
' This program checks the validity of WSDL file.One of the existing 
' port types is removed.A new PortType is defined and added to the 
' port types collection of the service description. A modified WSDL 
' is the output of the program.

Imports System
Imports System.Web.Services
Imports System.Web.Services.Description
Imports System.Xml

Namespace ServiceDescription1
   Class MyService

' <Snippet1>
' <Snippet2>
      Shared Sub Main()
         Dim myWsdlFileName As String = "MyWsdl_VB.wsdl"
         Dim myReader As New XmlTextReader(myWsdlFileName)
         If ServiceDescription.CanRead(myReader) Then
            
            Dim myDescription As ServiceDescription = _
               ServiceDescription.Read(myWsdlFileName)

            ' Remove the PortType at index 0 of the collection.
            Dim myPortTypeCollection As PortTypeCollection = _
               myDescription.PortTypes
            myPortTypeCollection.Remove(myDescription.PortTypes(0))

            ' Build a new PortType.
            Dim myPortType As New PortType()
            myPortType.Name = "Service1Soap"
            Dim myOperation As Operation = _
               CreateOperation("Add", "s0:AddSoapIn", "s0:AddSoapOut", "")
            myPortType.Operations.Add(myOperation)

            ' Add a new PortType to the PortType collection of 
            ' the ServiceDescription.
            myDescription.PortTypes.Add(myPortType)
            
            myDescription.Write("MyOutWsdl.wsdl")
            Console.WriteLine("New WSDL file generated successfully.")
         Else
            Console.WriteLine("This file is not a WSDL file.")
         End If
      End Sub 'Main
       
      ' Creates an Operation for a PortType.
      Public Shared Function CreateOperation(operationName As String, _
         inputMessage As String, outputMessage As String, _
         targetNamespace As String) As Operation

         Dim myOperation As New Operation()
         myOperation.Name = operationName
         Dim input As OperationMessage = _
            CType(New OperationInput(), OperationMessage)
         input.Message = New XmlQualifiedName(inputMessage, targetNamespace)
         Dim output As OperationMessage = _
            CType(New OperationOutput(), OperationMessage)
         output.Message = New XmlQualifiedName(outputMessage, targetNamespace)
         myOperation.Messages.Add(input)
         myOperation.Messages.Add(output)
         Return myOperation
      End Function 'CreateOperation
' </Snippet2>
' </Snippet1>
   End Class 'MyService 
End Namespace 'ServiceDescription1 
