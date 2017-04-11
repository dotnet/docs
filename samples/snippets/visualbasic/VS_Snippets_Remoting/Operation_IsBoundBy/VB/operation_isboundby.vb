' System.Web.Services.Description.Operation.IsBoundBy

' The following program demonstrates the 'IsBoundBy' method of 
' 'Operation' class. It takes "Operation_IsBoundBy_Input_VB.wsdl"
' as input which does not contain 'PortType' and 'Binding' objects
' supporting 'HttpPost'.It then adds those objects and writes into
' 'Operation_IsBoundBy_Output_VB.wsdl'.

Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml

Class MyOperationClass
   
   Public Shared Sub Main()
      Dim myServiceDescription As ServiceDescription = ServiceDescription.Read _
                                 ("Operation_IsBoundBy_Input_VB.wsdl")
      ' Create the 'Binding' object.
      Dim myBinding As New Binding()
      myBinding.Name = "MyOperationIsBoundByServiceHttpPost"
      Dim myXmlQualifiedName As New XmlQualifiedName("s0:OperationServiceHttpPost")
      myBinding.Type = myXmlQualifiedName
      ' Create the 'HttpBinding' object.
      Dim myHttpBinding As New HttpBinding()
      myHttpBinding.Verb = "POST"
      ' Add the 'HttpBinding' to the 'Binding'.
      myBinding.Extensions.Add(myHttpBinding)
      ' Create the 'OperationBinding' object.
      Dim myOperationBinding As New OperationBinding()
      myOperationBinding.Name = "AddNumbers"
      
      Dim myHttpOperationBinding As New HttpOperationBinding()
      myHttpOperationBinding.Location = "/AddNumbers"
      ' Add the 'HttpOperationBinding' to 'OperationBinding'.
      myOperationBinding.Extensions.Add(myHttpOperationBinding)
      
      ' Create the 'InputBinding' object.
      Dim myInputBinding As New InputBinding()
      Dim myPostMimeContentBinding As New MimeContentBinding()
      myPostMimeContentBinding.Type = "application/x-www-form-urlencoded"
      myInputBinding.Extensions.Add(myPostMimeContentBinding)
      ' Add the 'InputBinding' to 'OperationBinding'.
      myOperationBinding.Input = myInputBinding
      ' Create the 'OutputBinding' object.
      Dim myOutputBinding As New OutputBinding()
      Dim myPostMimeXmlBinding As New MimeXmlBinding()
      myPostMimeXmlBinding.Part = "Body"
      myOutputBinding.Extensions.Add(myPostMimeXmlBinding)
      
      ' Add the 'OutPutBinding' to 'OperationBinding'.
      myOperationBinding.Output = myOutputBinding
      
      ' Add the 'OperationBinding' to 'Binding'.
      myBinding.Operations.Add(myOperationBinding)
      
      ' Add the 'Binding' to 'BindingCollection' of 'ServiceDescription'.
      myServiceDescription.Bindings.Add(myBinding)
      
      ' Create a a 'PortType' object.
      Dim myPostPortType As New PortType()
      myPostPortType.Name = "OperationServiceHttpPost"
' <Snippet1>
      Dim myPostOperation As New Operation()
      myPostOperation.Name = myOperationBinding.Name
      Console.WriteLine("'Operation' instance uses 'OperationBinding': " + _
                                 myPostOperation.IsBoundBy(myOperationBinding).ToString())
' </Snippet1>
      Dim myOperationMessage As OperationMessage = CType(New OperationInput(), OperationMessage)
      myOperationMessage.Message = New XmlQualifiedName("s0:AddNumbersHttpPostIn")
      Dim myOperationMessage1 As OperationMessage = CType(New OperationOutput(), OperationMessage)
      myOperationMessage1.Message = New XmlQualifiedName("s0:AddNumbersHttpPostOut")
      
      myPostOperation.Messages.Add(myOperationMessage)
      myPostOperation.Messages.Add(myOperationMessage1)
      
      ' Add the 'Operation' to 'PortType'.
      myPostPortType.Operations.Add(myPostOperation)
      
      ' Adds the 'PortType' to 'PortTypeCollection' of 'ServiceDescription'.
      myServiceDescription.PortTypes.Add(myPostPortType)
      
      ' Write the 'ServiceDescription' as a WSDL file.
      myServiceDescription.Write("Operation_IsBoundBy_Output_VB.wsdl")
      Console.WriteLine("WSDL file with name 'Operation_IsBoundBy_Output_VB.wsdl' " + _
                                                   "created Successfully")
   End Sub 'Main
End Class 'MyOperationClass