' System.Web.Services.Description.Operation
' System.Web.Services.Description.Operation.Operation
' System.Web.Services.Description.Operation.Messages
' System.Web.Services.Description.Operation.Name
' System.Web.Services.Description.Operation.PortType

' The following program demonstrates 'Operation' class, its contructor
' and 'Messages','Name' and 'PortType' properties. It reads the file 
' 'Operation_5_Input_VB.wsdl' which does not have 'PortType' object  that
' supports 'HttpPost'. It adds a 'PortType' object that supports 'HttpPost'
' protocol and writes into 'Operation_5_Output_VB.wsdl'.

' <Snippet1>
Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml

Class MyOperationClass
   
   Public Shared Sub Main()
      Dim myDescription As ServiceDescription = ServiceDescription.Read("Operation_5_Input_VB.wsdl")
      ' Create a 'PortType' object.
      Dim myPortType As New PortType()
      myPortType.Name = "OperationServiceHttpPost"
      Dim myOperation As Operation = CreateOperation("AddNumbers", "s0:AddNumbersHttpPostIn", _
                                                                     "s0:AddNumbersHttpPostOut")
      myPortType.Operations.Add(myOperation)
' <Snippet5>      
      ' Get the PortType of the Operation. 
      Dim myPort As PortType = myOperation.PortType
        Console.WriteLine( _
           "The port type of the operation is: " & myPort.Name)
' </Snippet5>
      ' Add the 'PortType's to 'PortTypeCollection' of 'ServiceDescription'.
      myDescription.PortTypes.Add(myPortType)
      
      ' Write the 'ServiceDescription' as a WSDL file.
      myDescription.Write("Operation_5_Output_VB.wsdl")
      Console.WriteLine("WSDL file with name 'Operation_5_Output_VB.wsdl'" + _ 
                           "file created Successfully")
   End Sub 'Main
   
   Public Shared Function CreateOperation(myOperationName As String, myInputMesg As String, _
                                                         myOutputMesg As String) As Operation
' <Snippet2>
' <Snippet3>
' <Snippet4>
      ' Create an Operation.
      Dim myOperation As New Operation()
      myOperation.Name = myOperationName
      Dim myInput As OperationMessage = _
         CType(New OperationInput(), OperationMessage)
      myInput.Message = New XmlQualifiedName(myInputMesg)
      Dim myOutput As OperationMessage = _
         CType(New OperationOutput(), OperationMessage)
      myOutput.Message = New XmlQualifiedName(myOutputMesg)

      ' Add messages to the OperationMessageCollection.
      myOperation.Messages.Add(myInput)
      myOperation.Messages.Add(myOutput)
      Console.WriteLine("Operation name is: " & myOperation.Name)
' </Snippet4>
' </Snippet3>
' </Snippet2>
      Return myOperation
   End Function 'CreateOperation 
End Class 'MyOperationClass 
' </Snippet1>
