' System.Web.Services.Description.MimeXmlBinding
' System.Web.Services.Description.MimeXmlBinding.MimeXmlBinding()
' System.Web.Services.Description.MimeXmlBinding.Part

' The following program demonstrates constructor and 'Part'property
' of 'MimeXmlBinding' class. This program takes 'MimeXmlBinding_Part_3_Input_VB.wsdl'
' as input, which does not contain 'Binding' object that supports 'HttpPost'.
' It sets message part property to 'Body' on which 'MimeXmlBinding' is 
' applied and finally writes into 'MimeXmlBinding_Part_3_Output_VB.wsdl'.    

' <Snippet1>
Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml

Class MyXmlBinding
   
   Public Shared Sub Main()
      Try
         Dim myDescription As ServiceDescription = ServiceDescription.Read _
                                       ("MimeXmlBinding_Part_3_Input_VB.wsdl")
         ' Create the 'Binding' object.
         Dim myBinding As New Binding()
         ' Initialize 'Name' property of 'Binding' class.
         myBinding.Name = "MimeXmlBinding_Part_3_ServiceHttpPost"
         Dim myXmlQualifiedName As New XmlQualifiedName("s0:MimeXmlBinding_Part_3_ServiceHttpPost")
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
         Dim myMimeContentBinding As New MimeContentBinding()
         myMimeContentBinding.Type = "application/x-www-form-urlencoded"
         myInputBinding.Extensions.Add(myMimeContentBinding)
         ' Add the 'InputBinding' to 'OperationBinding'.
         myOperationBinding.Input = myInputBinding
' <Snippet2>
' <Snippet3>
         ' Create an OutputBinding.
         Dim myOutputBinding As New OutputBinding()
         Dim myMimeXmlBinding As New MimeXmlBinding()

         ' Initialize the Part property of the MimeXmlBinding. 
         myMimeXmlBinding.Part = "Body"

         ' Add the MimeXmlBinding to the OutputBinding.
         myOutputBinding.Extensions.Add(myMimeXmlBinding)
' </Snippet3>
' </Snippet2>
         ' Add the 'OutPutBinding' to 'OperationBinding'.
         myOperationBinding.Output = myOutputBinding
         ' Add the 'OperationBinding' to 'Binding'.
         myBinding.Operations.Add(myOperationBinding)
         ' Add the 'Binding' to 'BindingCollection' of 'ServiceDescription'.
         myDescription.Bindings.Add(myBinding)
         ' Write the 'ServiceDescription' as a WSDL file.
         myDescription.Write("MimeXmlBinding_Part_3_Output_VB.wsdl")
         Console.WriteLine("WSDL file with name 'MimeXmlBinding_Part_3_Output_VB.wsdl' is" + _
                                                                     " created successfully.")
      Catch e As Exception
         Console.WriteLine("Exception: {0}", e.Message)
      End Try
   End Sub 'Main
End Class 'MyXmlBinding
' </Snippet1>
