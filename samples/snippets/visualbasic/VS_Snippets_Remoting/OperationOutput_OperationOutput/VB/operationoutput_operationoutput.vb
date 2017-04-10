' System.Web.Services.Description.OperationOutput
' System.Web.Services.Description.OperationOutput.OperationOutput

' The following example demonstrates the usage of the 'OperationOutput'
' class and its constructor 'OperationOutput'. It creates a
' 'ServiceDescription' object by reading the file 'AddNumbersIn_cs.wsdl' and
' then creates 'AddNumbersOut_cs.wsdl' file which corresponds to added
' attributes in the 'ServiceDescription' instance.

' <Snippet1>
Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml

Class MyOperationOutputSample

   Public Shared Sub Main()
      Try
         Dim myDescription As ServiceDescription = _
            ServiceDescription.Read("AddNumbersIn_vb.wsdl")

         ' Add the ServiceHttpPost binding.
         Dim myBinding As New Binding()
         myBinding.Name = "ServiceHttpPost"
         Dim myXmlQualifiedName As New XmlQualifiedName("s0:ServiceHttpPost")
         myBinding.Type = myXmlQualifiedName
         Dim myHttpBinding As New HttpBinding()
         myHttpBinding.Verb = "POST"
         myBinding.Extensions.Add(myHttpBinding)

         ' Add the operation name AddNumbers.
         Dim myOperationBinding As New OperationBinding()
         myOperationBinding.Name = "AddNumbers"
         Dim myOperation As New HttpOperationBinding()
         myOperation.Location = "/AddNumbers"
         myOperationBinding.Extensions.Add(myOperation)

         ' Add the input binding.
         Dim myInput As New InputBinding()
         Dim postMimeContentbinding As New MimeContentBinding()
         postMimeContentbinding.Type = "application/x-www-form-urlencoded"
         myInput.Extensions.Add(postMimeContentbinding)

         ' Add the InputBinding to the OperationBinding.
         myOperationBinding.Input = myInput

         ' Add the ouput binding.
         Dim myOutput As New OutputBinding()
         Dim postMimeXmlbinding As New MimeXmlBinding()
         postMimeXmlbinding.Part = "Body"
         myOutput.Extensions.Add(postMimeXmlbinding)

         ' Add the OutPutBinding to the OperationBinding.
         myOperationBinding.Output = myOutput

         myBinding.Operations.Add(myOperationBinding)
         myDescription.Bindings.Add(myBinding)

         ' Add the port definition.
         Dim postPort As New Port()
         postPort.Name = "ServiceHttpPost"
         postPort.Binding = New XmlQualifiedName("s0:ServiceHttpPost")
         Dim postAddressBinding As New HttpAddressBinding()
         postAddressBinding.Location = "http://localhost/Service_vb.asmx"
         postPort.Extensions.Add(postAddressBinding)
         myDescription.Services(0).Ports.Add(postPort)

         ' Add the post port type definition.
         Dim postPortType As New PortType()
         postPortType.Name = "ServiceHttpPost"
         Dim postOperation As New Operation()
         postOperation.Name = "AddNumbers"
         Dim postInput As OperationMessage = _
            CType(New OperationInput(), OperationMessage)
         postInput.Message = New XmlQualifiedName("s0:AddNumbersHttpPostIn")
' <Snippet2>
         Dim postOutput As New OperationOutput()
         postOutput.Message = New XmlQualifiedName("s0:AddNumbersHttpPostOut")

         postOperation.Messages.Add(postInput)
         postOperation.Messages.Add(postOutput)
         postPortType.Operations.Add(postOperation)
' </Snippet2>
         myDescription.PortTypes.Add(postPortType)

         ' Add the first message information.
         Dim postMessage1 As New Message()
         postMessage1.Name = "AddNumbersHttpPostIn"
         Dim postMessagePart1 As New MessagePart()
         postMessagePart1.Name = "firstnumber"
         postMessagePart1.Type = New XmlQualifiedName("s:string")

         ' Add the second message information.
         Dim postMessagePart2 As New MessagePart()
         postMessagePart2.Name = "secondnumber"
         postMessagePart2.Type = New XmlQualifiedName("s:string")
         postMessage1.Parts.Add(postMessagePart1)
         postMessage1.Parts.Add(postMessagePart2)
         Dim postMessage2 As New Message()
         postMessage2.Name = "AddNumbersHttpPostOut"

         ' Add the third message information.
         Dim postMessagePart3 As New MessagePart()
         postMessagePart3.Name = "Body"
         postMessagePart3.Element = New XmlQualifiedName("s0:int")
         postMessage2.Parts.Add(postMessagePart3)

         myDescription.Messages.Add(postMessage1)
         myDescription.Messages.Add(postMessage2)

         ' Write the 'ServiceDescription' as a WSDL file.
         myDescription.Write("AddNumbersOut_vb.wsdl")
         Console.WriteLine("WSDL file named AddNumberOut_vb.Wsdl" &  _
            " created successfully.")
      Catch e As Exception
         Console.WriteLine("Exception caught!!!")
         Console.WriteLine("Source : " & e.Source.ToString())
         Console.WriteLine("Message : " & e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'MyOperationOutputSample
' </Snippet1>
