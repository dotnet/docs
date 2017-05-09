'  System.Web.Services.Description.HttpBinding.HttpBinding()
'  System.Web.Services.Description.HttpBinding.Namespace
'  System.Web.Services.Description.HttpAddressBinding.HttpAddressBinding()

'  The following program demonstrates the constructor, field 'Namespace' of
'  class 'HttpBinding' and constructor of class 'HttpAddressBinding'. This program writes all 'HttpPost' binding      related information to the input wsdl file and genrates an output file which is later on compiled using wsdl       tool.

Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml

Class MyHttpBindingClass
   
   Public Shared Sub Main()
      Dim myDescription As ServiceDescription = _
                 ServiceDescription.Read("HttpBinding_ctor_Input_VB.wsdl")
' <Snippet1>       
' <Snippet2>    
      ' Create 'Binding' object.
      Dim myBinding As New Binding()
      myBinding.Name = "MyHttpBindingServiceHttpPost"
      Dim qualifiedName As New XmlQualifiedName("s0:MyHttpBindingServiceHttpPost")
      myBinding.Type = qualifiedName
      ' Create 'HttpBinding' object.
      Dim myHttpBinding As New HttpBinding()
      myHttpBinding.Verb = "POST"
      Console.WriteLine("HttpBinding Namespace : " + HttpBinding.Namespace)
' </Snippet2> 
      ' Add 'HttpBinding' to 'Binding'.
      myBinding.Extensions.Add(myHttpBinding)
' </Snippet1>
      ' Create 'OperationBinding' object.
      Dim myOperationBinding As New OperationBinding()
      myOperationBinding.Name = "AddNumbers"
      Dim myOperation As New HttpOperationBinding()
      myOperation.Location = "/AddNumbers"
      ' Add 'HttpOperationBinding' to 'OperationBinding'.
      myOperationBinding.Extensions.Add(myOperation)
      ' Create 'InputBinding' object.
      Dim myInput As New InputBinding()
      Dim postMimeContentbinding As New MimeContentBinding()
      postMimeContentbinding.Type = "application/x-www-form-urlencoded"
      myInput.Extensions.Add(postMimeContentbinding)
      ' Add 'InputBinding' to 'OperationBinding'.
      myOperationBinding.Input = myInput
      ' Create 'OutputBinding' object.
      Dim myOutput As New OutputBinding()
      Dim postMimeXmlbinding As New MimeXmlBinding()
      postMimeXmlbinding.Part = "Body"
      myOutput.Extensions.Add(postMimeXmlbinding)
      ' Add 'OutPutBinding' to 'OperationBinding'.
      myOperationBinding.Output = myOutput
      ' Add 'OperationBinding' to 'Binding'.
      myBinding.Operations.Add(myOperationBinding)
      ' Add 'Binding' to 'BindingCollection' of 'ServiceDescription'.
      myDescription.Bindings.Add(myBinding)
' <Snippet3>
      ' Create a 'Port' object.
      Dim postPort As New Port()
      postPort.Name = "MyHttpBindingServiceHttpPost"
      postPort.Binding = New XmlQualifiedName("s0:MyHttpBindingServiceHttpPost")
      ' Create 'HttpAddressBinding' object.
      Dim postAddressBinding As New HttpAddressBinding()
      postAddressBinding.Location = _
                     "http://localhost/HttpBinding_ctor/HttpBinding_ctor_Service.vb.asmx"
      ' Add 'HttpAddressBinding' to 'Port'.
      postPort.Extensions.Add(postAddressBinding)
' </Snippet3>
      ' Add 'Port' to 'PortCollection' of 'ServiceDescription'.
      myDescription.Services(0).Ports.Add(postPort)
      ' Write 'ServiceDescription' as a WSDL file.
      myDescription.Write("HttpBinding_ctor_Output_VB.wsdl")
      Console.WriteLine _
          ("WSDL file with name 'HttpBinding_ctor_Output_VB.wsdl' file created Successfully")
   End Sub 'Main
End Class 'MyHttpBindingClass