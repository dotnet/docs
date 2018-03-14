' System.Web.Sevices.Description.OperationFlow
' System.Web.Sevices.Description.OperationFlow.None
' System.Web.Sevices.Description.OperationFlow.OneWay
' System.Web.Sevices.Description.OperationFlow.Notification
' System.Web.Sevices.Description.OperationFlow.SolicitResponse
' System.Web.Sevices.Description.OperationFlow.RequestResponse

' The following example demonstrates the usage of the 'OperationFlow'
' Enumeration, its members 'None', 'OneWay', 'Notification',
' 'SolicitResponse', 'RequestResponse'. The input to the program is a
' WSDL file 'MathService_input_vb.wsdl'  It creates a new file
' 'MathService_new_vb.wsdl' by adding the operation messages
' 'OperationInput' and 'OperationOutput' in such way that all members of
' the 'OperationFlow' enumeration are generated.

' <Snippet1>
Imports System
Imports System.Xml
Imports System.Web.Services
Imports System.Web.Services.Description


Class MyOperationFlowSample
   
   Public Shared Sub Main()
      Try
         Dim myDescription As ServiceDescription = _
            ServiceDescription.Read("MathService_Input_vb.wsdl")
         Dim myPortTypeCollection As PortTypeCollection = _
            myDescription.PortTypes

         ' Get the OperationCollection for SOAP protocol.
         Dim myOperationCollection As OperationCollection = _
            myPortTypeCollection(0).Operations
         ' Get the OperationMessageCollection for the Add operation.
         Dim myOperationMessageCollection As OperationMessageCollection = _
            myOperationCollection(0).Messages

         ' Indicate that the endpoint or service receives no 
         ' transmissions (None).
         Console.WriteLine("myOperationMessageCollection does not " & _
            "contain any operation messages.")
         DisplayOperationFlowDescription(myOperationMessageCollection.Flow)
         Console.WriteLine()
         
         ' Indicate that the endpoint or service receives a message (OneWay).
         Dim myInputOperationMessage As OperationMessage = _
            CType(New OperationInput(), OperationMessage)
         Dim myXmlQualifiedName As New XmlQualifiedName("AddSoapIn", _
            myDescription.TargetNamespace)
         myInputOperationMessage.Message = myXmlQualifiedName
         myOperationMessageCollection.Add(myInputOperationMessage)
         Console.WriteLine("myOperationMessageCollection contains " & _
            "only input operation messages.")
         DisplayOperationFlowDescription(myOperationMessageCollection.Flow)
         Console.WriteLine()
         
         myOperationMessageCollection.Remove(myInputOperationMessage)
         
         ' Indicate that an endpoint or service sends a message (Notification).
         Dim myOutputOperationMessage As OperationMessage = _
            CType(New OperationOutput(), OperationMessage)
         Dim myXmlQualifiedName1 As New XmlQualifiedName("AddSoapOut", _
            myDescription.TargetNamespace)
         myOutputOperationMessage.Message = myXmlQualifiedName1
         myOperationMessageCollection.Add(myOutputOperationMessage)
         Console.WriteLine("myOperationMessageCollection contains only " & _
            "output operation messages.")
         DisplayOperationFlowDescription(myOperationMessageCollection.Flow)
         Console.WriteLine()
         
         ' Indicate that an endpoint or service sends a message, then
         ' receives a correlated message (SolicitResponse).
         myOperationMessageCollection.Add(myInputOperationMessage)
         Console.WriteLine("myOperationMessageCollection contains " & _
            "an output operation message first, then " & _
            "an input operation message.")
         DisplayOperationFlowDescription(myOperationMessageCollection.Flow)
         Console.WriteLine()
         
         ' Indicate that an endpoint or service receives a message,
         ' then sends a correlated message (RequestResponse).
         myOperationMessageCollection.Remove(myInputOperationMessage)
         myOperationMessageCollection.Insert(0, myInputOperationMessage)
         Console.WriteLine("myOperationMessageCollection contains " & _
            "an input operation message first, then " & _
            "an output operation message.")
         DisplayOperationFlowDescription(myOperationMessageCollection.Flow)
         Console.WriteLine()
         
         myDescription.Write("MathService_new_vb.wsdl")
         Console.WriteLine( _
            "The file MathService_new_vb.wsdl was successfully written.")
      Catch e As Exception
         Console.WriteLine("Exception caught!!!")
         Console.WriteLine("Source : " & e.Source.ToString())
         Console.WriteLine("Message : " & e.Message.ToString())
      End Try
   End Sub 'Main
   ' <Snippet2>
   ' <Snippet3>
   ' <Snippet4>
   ' <Snippet5>
   ' <Snippet6>
   Public Shared Sub DisplayOperationFlowDescription(myOperationFlow As OperationFlow)
      Select Case myOperationFlow
         Case OperationFlow.None
            Console.WriteLine("Indicates that the endpoint or service " & _
               "receives no transmissions (None).")
         Case OperationFlow.OneWay
            Console.WriteLine("Indicates that the endpoint or service " & _
               "receives a message (OneWay).")
         Case OperationFlow.Notification
            Console.WriteLine("Indicates that the endpoint or service " & _
               "sends a message (Notification).")
         Case OperationFlow.SolicitResponse
            Console.WriteLine("Indicates that the endpoint or service " & _
               "sends a message, then receives a correlated message " & _
               "(SolicitResponse).")
          Case OperationFlow.RequestResponse
            Console.WriteLine("Indicates that the endpoint or service " & _
               "receives a message, then sends a correlated message " & _
               "(RequestResponse).")
      End Select
   End Sub 'DisplayOperationFlowDescription
' </Snippet6>
' </Snippet5>
' </Snippet4>
' </Snippet3>
' </Snippet2>
End Class 'MyOperationFlowSample
' </Snippet1>
