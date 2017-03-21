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