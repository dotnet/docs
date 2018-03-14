' System.Web.Services.Description.MimeTextBinding
' System.Web.Services.Description.MimeTextBinding()
' System.Web.Services.Description.MimeTextMatch()
' System.Web.Services.Description.MimeTextMatch.Name
' System.Web.Services.Description.MimeTextMatch.Type
' System.Web.Services.Description.MimeTextMatch.Pattern
' System.Web.Services.Description.MimeTextMatch.IgnoreCase
' System.Web.Services.Description.MimeTextBinding.Matches

'   This program demostrates constructor and 'Matches' property 
'   of 'MimeTextBinding' class and 'Name', 'Type', 'Pattern', 
'   'IgnoreCase' properties of 'MimeTextMatch' class.
'   It takes 'MimeText_Binding_Match_8_Input_vb.wsdl' as an
'   input file which does not contain 'Binding' object that supports 
'   'HttpPost'. A text pattern 'TITLE&gt;(.*?)&lt;' with text name 
'   as 'Title' and with type name set, is added to the wsdl file. Finally the  
'   modified ServiceDescription is written to 'MimeText_Binding_Match_8_Output_vb.wsdl'.

' <Snippet1>
Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml

Class MyTextBinding
   Public Shared Sub Main()
      Try
         Dim myServiceDescription As ServiceDescription = _
               ServiceDescription.Read("MimeText_Binding_Match_8_Input_vb.wsdl")

         ' Create a Binding.
         Dim myBinding As New Binding()

         ' Initialize the Name property of the Binding.
         myBinding.Name = "MimeText_Binding_MatchServiceHttpPost"
         Dim myXmlQualifiedName As _
               New XmlQualifiedName("s0:MimeText_Binding_MatchServiceHttpPost")
         myBinding.Type = myXmlQualifiedName

         ' Create an HttpBinding.
         Dim myHttpBinding As New HttpBinding()
         myHttpBinding.Verb = "POST"

         ' Add the HttpBinding to the Binding.
         myBinding.Extensions.Add(myHttpBinding)

         ' Create an OperationBinding.
         Dim myOperationBinding As New OperationBinding()
         myOperationBinding.Name = "AddNumbers"

         Dim myHttpOperationBinding As New HttpOperationBinding()
         myHttpOperationBinding.Location = "/AddNumbers"

         ' Add the HttpOperationBinding to the OperationBinding.
         myOperationBinding.Extensions.Add(myHttpOperationBinding)

         ' Create an InputBinding.
         Dim myInputBinding As New InputBinding()
         Dim postMimeContentbinding As New MimeContentBinding()
         postMimeContentbinding.Type = "application/x-www-form-urlencoded"
         myInputBinding.Extensions.Add(postMimeContentbinding)

         ' Add the InputBinding to the OperationBinding.
         myOperationBinding.Input = myInputBinding
' <Snippet8>
' <Snippet7>
' <Snippet6>
' <Snippet5>
' <Snippet4>
' <Snippet3>
' <Snippet2>
         ' Create an OutputBinding.
         Dim myOutputBinding As New OutputBinding()

         ' Create a MimeTextBinding.
         Dim myMimeTextBinding As New MimeTextBinding()

         ' Create a MimeTextMatch.
         Dim myMimeTextMatch As New MimeTextMatch()
         Dim myMimeTextMatchCollection As MimeTextMatchCollection

         ' Initialize properties of the MimeTextMatch.
         myMimeTextMatch.Name = "Title"
         myMimeTextMatch.Type = "*/*"
         myMimeTextMatch.Pattern = "'TITLE&gt;(.*?)&lt;"
         myMimeTextMatch.IgnoreCase = True

         ' Initialize a MimeTextMatchCollection.
         myMimeTextMatchCollection = myMimeTextBinding.Matches

         ' Add the MimeTextMatch to the MimeTextMatchCollection.
         myMimeTextMatchCollection.Add(myMimeTextMatch)
         myOutputBinding.Extensions.Add(myMimeTextBinding)

         ' Add the OutputBinding to the OperationBinding.
         myOperationBinding.Output = myOutputBinding
' </Snippet2>
' </Snippet3>
' </Snippet4>
' </Snippet5>
' </Snippet6>
' </Snippet7>
' </Snippet8>
         ' Add the OutputBinding to the OperationBinding.
         myOperationBinding.Output = myOutputBinding

         ' Add the OperationBinding to the Binding.
         myBinding.Operations.Add(myOperationBinding)

         ' Add the Binding to the BindingCollection of the ServiceDescription.
         myServiceDescription.Bindings.Add(myBinding)

         ' Write the ServiceDescription as a WSDL file.
         myServiceDescription.Write("MimeText_Binding_Match_8_Output_vb.wsdl")
         Console.WriteLine("WSDL file named " & _
            "'MimeText_Binding_Match_8_Output_vb.wsdl' was" & _
            " created successfully.")
      Catch e As Exception
         Console.WriteLine("Exception: {0}", e.Message)
      End Try
   End Sub 'Main
End Class 'MyTextBinding
' </Snippet1>
