' System.Web.Services.Description Operation.ParameterOrderString
' System.Web.Services.Description Operation.ParameterOrder

' The following program demonstrates the 'ParameterOrderString' and
' 'ParameterOrder' properties of 'Operation' class. It collects the
' message part names from the input WSDL file and sets to the
' 'ParameterOrderString'. It then displays the same using 'ParameterOrder'
' property.

Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml

Class MyOperationClass

   Public Shared Sub Main()
      Try
         Dim myDescription As ServiceDescription = _
                              ServiceDescription.Read("Operation_2_Input_VB.wsdl")
         Dim myBinding As New Binding()
         myBinding.Name = "Operation_2_ServiceHttpPost"
         Dim myQualifiedName As New XmlQualifiedName("s0:Operation_2_ServiceHttpPost")
         myBinding.Type = myQualifiedName
         Dim myHttpBinding As New HttpBinding()
         myHttpBinding.Verb = "POST"
         ' Add the 'HttpBinding' to the 'Binding'.
         myBinding.Extensions.Add(myHttpBinding)
         Dim myOperationBinding As New OperationBinding()
         myOperationBinding.Name = "AddNumbers"
         Dim myHttpOperationBinding As New HttpOperationBinding()
         myHttpOperationBinding.Location = "/AddNumbers"
         ' Add the 'HttpOperationBinding' to 'OperationBinding'.
         myOperationBinding.Extensions.Add(myHttpOperationBinding)
         Dim myInputBinding As New InputBinding()
         Dim myPostMimeContentbinding As New MimeContentBinding()
         myPostMimeContentbinding.Type = "application/x-www-form-urlencoded"
         myInputBinding.Extensions.Add(myPostMimeContentbinding)
         ' Add the 'InputBinding' to 'OperationBinding'.
         myOperationBinding.Input = myInputBinding
         Dim myOutputBinding As New OutputBinding()
         Dim myPostMimeXmlbinding As New MimeXmlBinding()
         myPostMimeXmlbinding.Part = "Body"
         myOutputBinding.Extensions.Add(myPostMimeXmlbinding)
         ' Add the 'OutPutBinding' to 'OperationBinding'.
         myOperationBinding.Output = myOutputBinding
         ' Add the 'OperationBinding' to 'Binding'.
         myBinding.Operations.Add(myOperationBinding)
         ' Add the 'Binding' to 'BindingCollection' of 'ServiceDescription'.
         myDescription.Bindings.Add(myBinding)
         Dim myPostPort As New Port()
         myPostPort.Name = "Operation_2_ServiceHttpPost"
         myPostPort.Binding = New XmlQualifiedName("s0:Operation_2_ServiceHttpPost")
         Dim myPostAddressBinding As New HttpAddressBinding()
         myPostAddressBinding.Location = "http://localhost/Operation_2/Operation_2_Service.vb.asmx"
         ' Add the 'HttpAddressBinding' to the 'Port'.
         myPostPort.Extensions.Add(myPostAddressBinding)
         ' Add the 'Port' to 'PortCollection' of 'ServiceDescription'.
         myDescription.Services(0).Ports.Add(myPostPort)
         Dim myPostPortType As New PortType()
         myPostPortType.Name = "Operation_2_ServiceHttpPost"
         Dim myPostOperation As New Operation()
         myPostOperation.Name = "AddNumbers"
         Dim myPostOperationInput As OperationMessage = _
                                            CType(New OperationInput(), OperationMessage)
         myPostOperationInput.Message = New XmlQualifiedName("s0:AddNumbersHttpPostIn")
         Dim myPostOperationOutput As OperationMessage = _
                                            CType(New OperationOutput(), OperationMessage)
         myPostOperationOutput.Message = New XmlQualifiedName("s0:AddNumbersHttpPostout")
         myPostOperation.Messages.Add(myPostOperationInput)
         myPostOperation.Messages.Add(myPostOperationOutput)
         ' Add the 'Operation' to 'PortType'.
         myPostPortType.Operations.Add(myPostOperation)
         ' Adds the 'PortType' to 'PortTypeCollection' of 'ServiceDescription'.
         myDescription.PortTypes.Add(myPostPortType)
         Dim myPostMessage1 As New Message()
         myPostMessage1.Name = "AddNumbersHttpPostIn"
         Dim myPostMessagePart1 As New MessagePart()
         myPostMessagePart1.Name = "firstnumber"
         myPostMessagePart1.Type = New XmlQualifiedName("s:string")
         Dim myPostMessagePart2 As New MessagePart()
         myPostMessagePart2.Name = "secondnumber"
         myPostMessagePart2.Type = New XmlQualifiedName("s:string")
         ' Add the 'MessagePart' objects to 'Messages'.
         myPostMessage1.Parts.Add(myPostMessagePart1)
         myPostMessage1.Parts.Add(myPostMessagePart2)
         Dim myPostMessage2 As New Message()
         myPostMessage2.Name = "AddNumbersHttpPostout"
         Dim myPostMessagePart3 As New MessagePart()
         myPostMessagePart3.Name = "Body"
         myPostMessagePart3.Element = New XmlQualifiedName("s0:int")
         ' Add the 'MessagePart' to 'Message'.
         myPostMessage2.Parts.Add(myPostMessagePart3)
         ' Add the 'Message' objects to 'ServiceDescription'.
         myDescription.Messages.Add(myPostMessage1)
         myDescription.Messages.Add(myPostMessage2)
         ' Write the 'ServiceDescription' as a WSDL file.
         myDescription.Write("Operation_2_Output_VB.wsdl")
         Console.WriteLine(" 'Operation_2_Output_VB.wsdl' file created Successfully")
' <Snippet1>
' <Snippet2>
         Dim myString As String = Nothing
         Dim myOperation As New Operation()
         myDescription = ServiceDescription.Read("Operation_2_Input_VB.wsdl")
         Dim myMessage(myDescription.Messages.Count) As Message

         ' Copy the messages from the service description.
         myDescription.Messages.CopyTo(myMessage, 0)
         Dim i As Integer
         For i = 0 To myDescription.Messages.Count - 1
            Dim myMessagePart(myMessage(i).Parts.Count) As MessagePart

            ' Copy the message parts into a MessagePart.
            myMessage(i).Parts.CopyTo(myMessagePart, 0)
            Dim j As Integer
            For j = 0 To (myMessage(i).Parts.Count) - 1
               myString += myMessagePart(j).Name
               myString += " "
            Next j
         Next i

         ' Set the ParameterOrderString equal to the list of 
         ' message part names.
         myOperation.ParameterOrderString = myString
         Dim myString1 As String() = myOperation.ParameterOrder
         Dim k As Integer = 0
         Console.WriteLine("The list of message part names is as follows:")
         While k < 5
            Console.WriteLine(myString1(k))
            k += 1
         End While
' </Snippet2>
' </Snippet1>
      Catch e As Exception
         Console.WriteLine("The following Exception is raised : " + e.Message)
      End Try
   End Sub 'Main
End Class 'MyOperationClass
