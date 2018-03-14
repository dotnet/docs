' System.Web.Services.Description.PortType

'  The following sample demonstrates the class 'PortType'. This sample reads 
'  the contents of a file 'MathService.wsdl' into a 'ServiceDescription' instance.
'  It gets the collection of 'PortType' instances from 'ServiceDescription'.
'  It removes a 'PortType' from the collection, creates a new 'PortType' and adds 
'  it into collection.The programs writes a new web service description 
'  file 'MathService_New.wsdl'.

' <Snippet1>
Imports System
Imports System.Web.Services.Description
Imports System.Xml
Imports Microsoft.VisualBasic

Class MyPortTypeClass
   Public Shared Sub Main()
      Try
         Dim myPortTypeCollection As PortTypeCollection
         Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read("MathService_vb.wsdl")

         myPortTypeCollection = myServiceDescription.PortTypes
         Dim noOfPortTypes As Integer = _
            myServiceDescription.PortTypes.Count
         Console.WriteLine(ControlChars.Newline & _
            "Total number of PortTypes : " & noOfPortTypes.ToString())

         Dim myPortType As PortType = _
            myPortTypeCollection("MathServiceSoap")
         myPortTypeCollection.Remove(myPortType)

         ' Create a new PortType.
         Dim myNewPortType As New PortType()
         myNewPortType.Name = "MathServiceSoap"
         Dim myOperationCollection As OperationCollection = _
            myServiceDescription.PortTypes(0).Operations
         Dim i As Integer
         For i = 0 To myOperationCollection.Count - 1
            Dim inputmsg As String = _
               myOperationCollection(i).Name & "SoapIn"
            Dim outputmsg As String = _
               myOperationCollection(i).Name & "SoapOut"
            Console.WriteLine("Operation = " & myOperationCollection(i).Name)
            myNewPortType.Operations.Add( _
               CreateOperation(myOperationCollection(i).Name, inputmsg, _
               outputmsg, myServiceDescription.TargetNamespace))
         Next i

         ' Add the PortType to the collection.
         myPortTypeCollection.Add(myNewPortType)
         noOfPortTypes = myServiceDescription.PortTypes.Count
         Console.WriteLine(ControlChars.Newline & _
            "Total Number of PortTypes : " & noOfPortTypes.ToString())
         myServiceDescription.Write("MathService_New.wsdl")
      Catch e As Exception
         Console.WriteLine("Exception: " & e.Message)
      End Try
   End Sub 'Main

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
End Class 'MyPortTypeClass
' </Snippet1>
