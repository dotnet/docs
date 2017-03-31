' System.Web.Services.Description.PortType.Operations
' System.Web.Services.Description.PortType.PortType()
' System.Web.Services.Description.PortType.Name

' The following sample demonstrates the properties 'Operations','Name' and constructor
' 'PortType()' of class 'PortType'.This sample reads the contents of a file 'MathService.wsdl'
' into a 'ServiceDescription' instance. It gets the collection of 'PortType'
' instances from 'ServiceDescription'. It removes a 'PortType' from the collection, creates a 
' new 'PortType' and adds it into collection.The programs writes a new web service description 
' file 'MathService_New.wsdl'.

' <Snippet1>
Imports System
Imports System.Web.Services.Description
Imports System.Xml
Imports Microsoft.VisualBasic

Class MyPortTypeClass
   Public Shared Sub Main()
      Try
' <Snippet2>
' <Snippet3>
         Dim myPortTypeCollection As PortTypeCollection
         Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read("MathService_VB.wsdl")
         
         myPortTypeCollection = myServiceDescription.PortTypes
         Dim noOfPortTypes As Integer = myServiceDescription.PortTypes.Count
         Console.WriteLine( _
            ControlChars.Newline & "Total number of PortTypes : " & _
            noOfPortTypes.ToString())
         
         Dim myPortType As PortType = myPortTypeCollection("MathServiceSoap")
         myPortTypeCollection.Remove(myPortType)
         
         ' Create a new PortType.
         Dim myNewPortType As New PortType()
         myNewPortType.Name = "MathServiceSoap"
         Dim myOperationCollection As OperationCollection = _
            myServiceDescription.PortTypes(0).Operations
         Dim i As Integer
         Dim inputMsg As String
         Dim outputMsg As String
         For i = 0 To myOperationCollection.Count - 1
            inputMsg = myOperationCollection(i).Name & "SoapIn"
            outputMsg = myOperationCollection(i).Name & "SoapOut"
            Console.WriteLine(" Operation = " & myOperationCollection(i).Name)
            myNewPortType.Operations.Add( _
               CreateOperation(myOperationCollection(i).Name, inputMsg, _
               outputMsg, myServiceDescription.TargetNamespace))
         Next i
         ' Add the PortType to the collection.
         myPortTypeCollection.Add(myNewPortType)
         noOfPortTypes = myServiceDescription.PortTypes.Count
         Console.WriteLine( _
            ControlChars.Newline & "Total number of PortTypes : " & _
            noOfPortTypes.ToString())
         myServiceDescription.Write("MathService_New.wsdl")
' </Snippet3>
' </Snippet2>
      Catch e As Exception
         Console.WriteLine("Exception:" + e.Message.ToString())
      End Try
   End Sub 'Main
   
   Public Shared Function CreateOperation(operationName As String, inputMessage As String, _
                           outputMessage As String, targetNamespace As String) As Operation
      Dim myOperation As New Operation()
      myOperation.Name = operationName
      Dim input As OperationMessage = CType(New OperationInput(), OperationMessage)
      input.Message = New XmlQualifiedName(inputMessage, targetNamespace)
      Dim output As OperationMessage = CType(New OperationOutput(), OperationMessage)
      output.Message = New XmlQualifiedName(outputMessage, targetNamespace)
      myOperation.Messages.Add(input)
      myOperation.Messages.Add(output)
      Return myOperation
   End Function 'CreateOperation
End Class 'MyPortTypeClass
' </Snippet1>
