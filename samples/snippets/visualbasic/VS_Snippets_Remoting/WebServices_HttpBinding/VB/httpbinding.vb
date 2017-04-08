' System.Web.Services.HttpBinding;System.Web.Services.HttpBinding.Verb;
' System.Web.Services.HttpAddressBinding;System.Web.Services.HttpAddressBinding.Location;
'
' * The following example demonstrates the 'HttpBinding()' constructor 
'  and 'Verb' property of class 'HttpBinding' and 'HttpAddressBinding()
' ' constructor and 'Location' property of class 'HttpAddressBinding'. 
'  It creates a 'ServiceDescription' instance by using the
'  static read method of 'ServiceDescription' by passing the 
' 'AddNumbers1.wsdl' name as an argument.It creates  a 'Binding' object 
'  and adds that binding object to 'ServiceDescription'. 
'  It adds the 'PortType',Messages to the 'ServiceDescription' object. 
'  Finally it writes the 'ServiceDescrption' as a WSDL file with name 
' 'AddNumbers.wsdl.
  
Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml



Class [MyClass]
   
   Public Shared Sub Main()
      Dim myDescription As ServiceDescription = ServiceDescription.Read("AddNumbers1.wsdl")
      
      ' Create the 'Binding' object.
      Dim myBinding As New Binding()
      myBinding.Name = "Service1HttpPost"
      Dim qualifiedName As New XmlQualifiedName("s0:Service1HttpPost")
      myBinding.Type = qualifiedName
      
      ' <Snippet1>
      ' <Snippet2>
      ' Create the 'HttpBinding' object.
      Dim myHttpBinding As New HttpBinding()
      
      myHttpBinding.Verb = "POST"
      ' Add the 'HttpBinding' to the 'Binding'.
      myBinding.Extensions.Add(myHttpBinding)
      ' </Snippet2>
      ' </Snippet1>
      
      ' Create the 'OperationBinding' object.            
      Dim myOperationBinding As New OperationBinding()
      myOperationBinding.Name = "AddNumbers"
      
      Dim myOperation As New HttpOperationBinding()
      myOperation.Location = "/AddNumbers"
      ' Add the 'HttpOperationBinding' to 'OperationBinding'.
      myOperationBinding.Extensions.Add(myOperation)
      
      ' Create the 'InputBinding' object.
      Dim myInput As New InputBinding()
      Dim postMimeContentbinding As New MimeContentBinding()
      postMimeContentbinding.Type = "application/x-www-form-urlencoded"
      myInput.Extensions.Add(postMimeContentbinding)
      ' Add the 'InputBinding' to 'OperationBinding'.
      myOperationBinding.Input = myInput
      ' Create the 'OutputBinding' object.
      Dim myOutput As New OutputBinding()
      Dim postMimeXmlbinding As New MimeXmlBinding()
      postMimeXmlbinding.Part = "Body"
      myOutput.Extensions.Add(postMimeXmlbinding)
      
      ' Add the 'OutPutBinding' to 'OperationBinding'.          
      myOperationBinding.Output = myOutput
      
      ' Add the 'OperationBinding' to 'Binding'.
      myBinding.Operations.Add(myOperationBinding)
      
      ' Add the 'Binding' to 'BindingCollection' of 'ServiceDescription'.
      myDescription.Bindings.Add(myBinding)
      
      ' Create  a 'Port' object.
      Dim postPort As New Port()
      postPort.Name = "Service1HttpPost"
      postPort.Binding = New XmlQualifiedName("s0:Service1HttpPost")
      
      ' <Snippet3>
      ' <Snippet4>
      ' Create the 'HttpAddressBinding' object.
      Dim postAddressBinding As New HttpAddressBinding()
      
      postAddressBinding.Location = "http://localhost/Service1.asmx"
      
      ' Add the 'HttpAddressBinding' to the 'Port'.
      postPort.Extensions.Add(postAddressBinding)
      ' </Snippet4>
      ' </Snippet3>
      
      ' Add the 'Port' to 'PortCollection' of 'ServiceDescription'.
      myDescription.Services(0).Ports.Add(postPort)
      
      ' Create a a 'PortType' object.
      Dim postPortType As New PortType()
      postPortType.Name = "Service1HttpPost"
      
      Dim postOperation As New Operation()
      postOperation.Name = "AddNumbers"
      
      Dim postInput As OperationMessage = CType(New OperationInput(), OperationMessage)
      postInput.Message = New XmlQualifiedName("s0:AddNumbersHttpPostIn")
      Dim postOutput As OperationMessage = CType(New OperationOutput(), OperationMessage)
      postOutput.Message = New XmlQualifiedName("s0:AddNumbersHttpPostOut")
      
      postOperation.Messages.Add(postInput)
      postOperation.Messages.Add(postOutput)
      
      ' Add the 'Operation' to 'PortType'.
      postPortType.Operations.Add(postOperation)
      
      ' Adds the 'PortType' to 'PortTypeCollection' of 'ServiceDescription'.
      myDescription.PortTypes.Add(postPortType)
      
      ' Create  the 'Message' object.
      Dim postMessage1 As New Message()
      postMessage1.Name = "AddNumbersHttpPostIn"
      ' Create the 'MessageParts'.         
      Dim postMessagePart1 As New MessagePart()
      postMessagePart1.Name = "firstnumber"
      postMessagePart1.Type = New XmlQualifiedName("s:string")
      
      Dim postMessagePart2 As New MessagePart()
      postMessagePart2.Name = "secondnumber"
      postMessagePart2.Type = New XmlQualifiedName("s:string")
      ' Add the 'MessagePart' objects to 'Messages'.  
      postMessage1.Parts.Add(postMessagePart1)
      postMessage1.Parts.Add(postMessagePart2)
      
      ' Create another 'Message' object.
      Dim postMessage2 As New Message()
      postMessage2.Name = "AddNumbersHttpPostOut"
      
      Dim postMessagePart3 As New MessagePart()
      postMessagePart3.Name = "Body"
      postMessagePart3.Element = New XmlQualifiedName("s0:int")
      ' Add the 'MessagePart' to 'Message'
      postMessage2.Parts.Add(postMessagePart3)
      
      ' Add the 'Message' objects to 'ServiceDescription'. 
      myDescription.Messages.Add(postMessage1)
      myDescription.Messages.Add(postMessage2)
      
      ' Write the 'ServiceDescription' as a WSDL file.
      myDescription.Write("AddNumbers.wsdl")
      Console.WriteLine("WSDL file with name 'AddNumber.Wsdl' file created Successfully")
   End Sub 'Main
End Class '[MyClass]